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
        private readonly NorthwindEntities _db = new NorthwindEntities();
        public void Add(Orders model)
        {
            _db.Orders.Add(model);
            _db.SaveChanges();
        }

        public void Delete(int id)
        {
            var order = _db.Orders.Find(id);
            _db.Orders.Remove(order);
            _db.SaveChanges();

        }

        public void Edit(Orders model)
        {
            _db.Entry(model).State = EntityState.Modified;
            _db.SaveChanges();

        }

        public List<Orders> GetAll()
        {
            return _db.Orders.Take(30).ToList();
        }

        public Orders GetByID(int OrderID)
        {
            return _db.Orders.Find(OrderID);
        }
    }
}
