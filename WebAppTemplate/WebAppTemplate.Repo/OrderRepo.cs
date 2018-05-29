using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppTemplate.Repo.Interface;

namespace WebAppTemplate.Repo
{
    public class OrderRepo : IOrderRepo
    {
        public void Add(Orders model)
        {
            using (var db = new NorthwindEntities()) {
                db.Orders.Add(model);
                db.SaveChanges();
            }
        }

        public void Delete(int id)
        {
            using (var db = new NorthwindEntities())
            {
                var order = db.Orders.Find(id);
                db.Orders.Remove(order);
                db.SaveChanges();
            }
        }

        public void Update(Orders model)
        {
            using (var db = new NorthwindEntities())
            {
                var order = db.Orders.Find(model.OrderID);
                order.ShipName = model.ShipName;
                db.SaveChanges();
            }
        }

        public IQueryable<Orders> GetAll()
        {
            using (var db = new NorthwindEntities())
            {
                return db.Orders;
            }
        }
    }
}
