using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppTemplate.Repo.Interface;

namespace WebAppTemplate.Repo
{
    public class Order_DetailsRepo : GeneralRepo<Order_Details>, IOrder_DetailsRepo
    {
        public Order_DetailsRepo(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
    }
}
