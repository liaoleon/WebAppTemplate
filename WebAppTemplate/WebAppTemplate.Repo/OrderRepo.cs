using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppTemplate.Repo.Interface;

namespace WebAppTemplate.Repo
{
    public class OrderRepo : IOrderRepo
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly DbSet<Orders> _dbOrder;
        private readonly DbSet<Order_Details> _dbOrderDetails;

        public OrderRepo(IUnitOfWork unitOfWork) {
            _unitOfWork = unitOfWork;
            _dbOrder = _unitOfWork.DataBaseContext.Set<Orders>();
            _dbOrderDetails = _unitOfWork.DataBaseContext.Set<Order_Details>();
        }
        public void Add(Orders model)
        {
            _dbOrder.Add(model);
        }

        public void Delete(int id)
        {
            var order = _dbOrder.Find(id);
            _dbOrder.Remove(order);
            var orderDetail = _dbOrderDetails.Where(x => x.OrderID == id);
            _dbOrderDetails.RemoveRange(orderDetail);
        }

        public void Edit(Orders model)
        {
            _unitOfWork.DataBaseContext.Entry(model).State = EntityState.Modified;

        }

        public IQueryable<Orders> GetAll()
        {
            return _dbOrder;
        }

        public Orders GetByID(int OrderID)
        {
            return _dbOrder.Find(OrderID);
        }
    }
}
