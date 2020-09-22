#region Namespace
using Microsoft.EntityFrameworkCore;
using MPCA.Entities.Models; 
#endregion

namespace MPCA.Entities
{
    /// <summary>
    /// Repository Context
    /// </summary>
    /// <seealso cref="Microsoft.EntityFrameworkCore.DbContext" />
    public class RepositoryContext : DbContext
    {
        #region Constructor 
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryContext"/> class.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public RepositoryContext(DbContextOptions options)
            : base(options)
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets the tenants.
        /// </summary>
        /// <value>
        /// The tenants.
        /// </value>
        public DbSet<Tenant> Tenants { get; set; }

        /// <summary>
        /// Gets or sets the sites.
        /// </summary>
        /// <value>
        /// The sites.
        /// </value>
        public DbSet<Site> Sites { get; set; }

        /// <summary>
        /// Gets or sets the user infos.
        /// </summary>
        /// <value>
        /// The user infos.
        /// </value>
        public DbSet<UserInfo> UserInfos { get; set; }

        /// <summary>
        /// Gets or sets the roles.
        /// </summary>
        /// <value>
        /// The roles.
        /// </value>
        public DbSet<Role> Roles { get; set; }

        #endregion
    }
}
