#region Namespace
using MPCA.Entities.Models;
using System;
using System.Collections.Generic; 
#endregion

namespace MPCA.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MPCA.Contracts.IRepositoryBase{MPCA.Entities.Models.Tenant}" />
    public interface ITenantRepository : IRepositoryBase<Tenant>
    {
        /// <summary>
        /// Gets all tenants.
        /// </summary>
        /// <returns></returns>
        IEnumerable<Tenant> GetAllTenants();

        /// <summary>
        /// Gets the tenant by identifier.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <returns></returns>
        Tenant GetTenantById(Guid tenantId);

        /// <summary>
        /// Gets the tenant with details.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <returns></returns>
        Tenant GetTenantWithDetails(Guid tenantId);

        /// <summary>
        /// Creates the tenant.
        /// </summary>
        /// <param name="tenant">The tenant.</param>
        void CreateTenant(Tenant tenant);

        /// <summary>
        /// Updates the tenant.
        /// </summary>
        /// <param name="tenant">The tenant.</param>
        void UpdateTenant(Tenant tenant);

        /// <summary>
        /// Deletes the tenant.
        /// </summary>
        /// <param name="tenant">The tenant.</param>
        void DeleteTenant(Tenant tenant);

        /// <summary>
        /// Determines whether [is tenant exists] [the specified tenant identifier].
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <returns>
        ///   <c>true</c> if [is tenant exists] [the specified tenant identifier]; otherwise, <c>false</c>.
        /// </returns>
        bool IsTenantExists(Guid tenantId);
    }
}
