using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAppTemplate.Repo.Interface
{
    /// <summary>
    /// Interface IUnitOfWork
    /// </summary>
    /// <seealso cref="System.IDisposable" />
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Gets or sets the data base context.
        /// </summary>
        /// <value>The data base context.</value>
        DbContext DataBaseContext { get; set; }

        /// <summary>
        /// Saves the changes.
        /// </summary>
        /// <returns>System.Int32.</returns>
        int SaveChanges();
    }
}
