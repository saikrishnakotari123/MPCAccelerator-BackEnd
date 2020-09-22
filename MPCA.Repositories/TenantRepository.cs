#region Namespace
using Microsoft.EntityFrameworkCore;
using MPCA.Contracts;
using MPCA.Entities;
using MPCA.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
#endregion

namespace MPCA.Repositories
{
    /// <summary>
    /// Tenant Repository
    /// </summary>
    /// <seealso cref="MPCA.Repositories.RepositoryBase{MPCA.Entities.Models.Tenant}" />
    /// <seealso cref="MPCA.Contracts.ITenantRepository" />
    public class TenantRepository : RepositoryBase<Tenant>, ITenantRepository
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="TenantRepository"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        public TenantRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets all tenants.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Tenant> GetAllTenants()
        {
            return FindAll()
                .OrderBy(t => t.Name)
                .ToList();
        }

        /// <summary>
        /// Gets the tenant by identifier.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <returns></returns>
        public Tenant GetTenantById(Guid tenantId)
        {
            return FindByCondition(tenant => tenant.TenantId.Equals(tenantId))
                .FirstOrDefault();
        }

        /// <summary>
        /// Gets the tenant with details.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <returns></returns>
        public Tenant GetTenantWithDetails(Guid tenantId)
        {
            return FindByCondition(tenant => tenant.TenantId.Equals(tenantId))
                .Include(t => t.Sites)
                .FirstOrDefault();
        }

        /// <summary>
        /// Creates the tenant.
        /// </summary>
        /// <param name="tenant">The tenant.</param>
        public void CreateTenant(Tenant tenant)
        {
            Create(tenant);
        }

        /// <summary>
        /// Updates the tenant.
        /// </summary>
        /// <param name="tenant">The tenant.</param>
        public void UpdateTenant(Tenant tenant)
        {
            Update(tenant);
        }

        /// <summary>
        /// Deletes the tenant.
        /// </summary>
        /// <param name="tenant">The tenant.</param>
        public void DeleteTenant(Tenant tenant)
        {
            Delete(tenant);
        }

        /// <summary>
        /// Determines whether [is tenant exists] [the specified tenant identifier].
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <returns>
        /// <c>true</c> if [is tenant exists] [the specified tenant identifier]; otherwise, <c>false</c>.
        /// </returns>
        public bool IsTenantExists(Guid tenantId)
        {
            return IsExists(tenant => tenant.TenantId.Equals(tenantId));
        } 
        #endregion
    }
}
