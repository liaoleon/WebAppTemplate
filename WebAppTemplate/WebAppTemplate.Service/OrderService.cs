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
        public OrderService(IOrderRepo orderRepo)
        {
            _orderRepo = orderRepo;
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
            return _orderRepo.GetAll().Take(30).ToList();
        }

        public Orders GetByID(int OrderID)
        {
            if (OrderID < 0) {
                throw new ArgumentOutOfRangeException(nameof(OrderID));
            }
            return _orderRepo.Find(OrderID);
        }
    }
}
