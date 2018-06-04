using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppTemplate.Repo;
using WebAppTemplate.Repo.Interface;

namespace WebAppTemplate.Service.Tests
{
    public class MockOrderRepo : IOrderRepo
    {
        public void Add(Orders model)
        {
          
        }

        public void Delete(int id)
        {
          
        }

        public void Edit(Orders model)
        {
          
        }

        public IQueryable<Orders> GetAll()
        {
            List<Orders> list = new List<Orders>();
            for (int i = 0; i < 30; i++)
            {
                list.Add(new Orders());
            }
            return list.AsQueryable();
        }

        public Orders GetByID(int OrderID)
        {
            return new Orders();
        }
    }
}
