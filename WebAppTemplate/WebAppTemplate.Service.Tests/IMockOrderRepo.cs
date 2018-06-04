using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppTemplate.Repo;
using WebAppTemplate.Repo.Interface;

namespace WebAppTemplate.Service.Tests
{
    public class IMockOrderRepo : IOrderRepo
    {
        public void Add(Orders model)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void Edit(Orders model)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
