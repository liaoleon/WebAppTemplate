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
    public class OrderRepo : GeneralRepo<Orders>, IOrderRepo
    {
        public OrderRepo(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
