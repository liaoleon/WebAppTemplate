using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppTemplate.Repo;
using WebAppTemplate.Repo.Interface;
using WebAppTemplate.Service.Interface;

namespace WebAppTemplate.Service
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepo _orderRepo;
        private readonly IOrder_DetailsRepo _order_DetailsRepo;
        public OrderService(IOrderRepo orderRepo, IOrder_DetailsRepo order_DetailsRepo)
        {
            _orderRepo = orderRepo;
            _order_DetailsRepo = order_DetailsRepo;
        }

        public void Add(Orders model)
        {
            if (model == null) {
                throw new ArgumentNullException(nameof(model));
            }
            model.CustomerID = "ALFKI";
            model.EmployeeID = 1;
            _orderRepo.Add(model);
        }

        public void Delete(int OrderID)
        {
            if (OrderID < 0) {
                throw new ArgumentOutOfRangeException(nameof(OrderID));
            }
            var order = _orderRepo.Find(OrderID);
            _orderRepo.Delete(order);
            var orderDetail = _order_DetailsRepo.Where(x => x.OrderID == OrderID);
            _order_DetailsRepo.RemoveRange(orderDetail);
        }

        public void Edit(Orders model)
        {
            if (model == null) {
                throw new ArgumentNullException(nameof(model));
            }
            _orderRepo.Update(model);
        }

        public List<Orders> GetAll()
        {
            return _orderRepo.GetAll().OrderByDescending(x=>x.OrderID).Take(30).ToList();
        }

        public Orders GetByID(int OrderID)
        {
            if (OrderID < 0) {
                throw new ArgumentOutOfRangeException(nameof(OrderID));
            }
            return _orderRepo.Find(OrderID);
        }

        public List<Order_Details> GetDetails(int OrderID)
        {
            if (OrderID < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(OrderID));
            }
            return _order_DetailsRepo.Where(x => x.OrderID == OrderID).ToList();
        }
    }
}
