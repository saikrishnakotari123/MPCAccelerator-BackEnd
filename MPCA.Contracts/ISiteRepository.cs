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
    /// <seealso cref="MPCA.Contracts.IRepositoryBase{MPCA.Entities.Models.Site}" />
    public interface ISiteRepository : IRepositoryBase<Site>
    {
        /// <summary>
        /// Gets the sites by tenant.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <returns></returns>
        IEnumerable<Site> GetSitesByTenant(Guid tenantId);

        /// <summary>
        /// Gets all sites.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Site> GetAllSites();

        /// <summary>
        /// Gets the site by identifier.
        /// </summary>
        /// <param name="siteId">The site identifier.</param>
        /// <returns></returns>
        public Site GetSiteById(Guid siteId);

        /// <summary>
        /// Creates the site.
        /// </summary>
        /// <param name="site">The site.</param>
        public void CreateSite(Site site);

        /// <summary>
        /// Updates the site.
        /// </summary>
        /// <param name="site">The site.</param>
        public void UpdateSite(Site site);

        /// <summary>
        /// Deletes the site.
        /// </summary>
        /// <param name="site">The site.</param>
        public void DeleteSite(Site site);
    }
}
