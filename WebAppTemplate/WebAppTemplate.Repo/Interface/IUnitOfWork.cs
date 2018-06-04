using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppTemplate.Repo.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext DataBaseContext { get; set; }

        int SaveChanges();
    }
}
