using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppTemplate.Repo;

namespace WebAppTemplate.Service.Interface
{
    interface IOrderService
    {
        List<Orders> GetAll();
        void Add(Orders model);
        void Edit(Orders model);
        void Delete(int id);

    }
}
