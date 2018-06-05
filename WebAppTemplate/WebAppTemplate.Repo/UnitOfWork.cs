using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAppTemplate.Repo.Interface;

namespace WebAppTemplate.Repo
{
    public class UnitOfWork : IUnitOfWork
    {
        private bool disposed = false;

        public DbContext DataBaseContext { get; set; }

        public UnitOfWork(DbContext dbContext)
        {
            this.DataBaseContext = dbContext;
        }

        public int SaveChanges()
        {
            return this.DataBaseContext.SaveChanges();
        }

        /// <summary>
        /// 執行與釋放 (Free)、釋放 (Release) 或重設 Unmanaged 資源相關聯之應用程式定義的工作。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="disposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;
            if (disposing)
            {
                DataBaseContext.Dispose();
            }
            disposed = true;
        }

        /// <summary>
        /// Finalizes an instance of the <see cref="UnitOfWork"/> class.
        /// </summary>
        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
