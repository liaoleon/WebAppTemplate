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
            model.CustomerID = "ALFKI";
            model.EmployeeID = 1;
            _orderRepo.Add(model);
        }

        public void Delete(int id)
        {
            _orderRepo.Delete(id);
        }

        public void Edit(Orders model)
        {
            _orderRepo.Edit(model);
        }

        public List<Orders> GetAll()
        {
            return _orderRepo.GetAll().Take(30).ToList();
        }

        public Orders GetByID(int OrderID)
        {
            return _orderRepo.GetByID(OrderID);
        }
    }
}
