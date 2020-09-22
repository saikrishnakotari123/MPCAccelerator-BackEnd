#region Namespace
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
    /// Site repository
    /// </summary>
    /// <seealso cref="MPCA.Repositories.RepositoryBase{MPCA.Entities.Models.Site}" />
    /// <seealso cref="MPCA.Contracts.ISiteRepository" />
    public class SiteRepository : RepositoryBase<Site>, ISiteRepository
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SiteRepository"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        public SiteRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the sites by tenant.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <returns></returns>
        public IEnumerable<Site> GetSitesByTenant(Guid tenantId)
        {
            return FindByCondition(a => a.TenantId.Equals(tenantId)).ToList();
        }

        /// <summary>
        /// Gets all sites.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Site> GetAllSites()
        {
            return FindAll()
                .OrderBy(t => t.Name)
                .ToList();
        }

        /// <summary>
        /// Gets the site by identifier.
        /// </summary>
        /// <param name="siteId">The site identifier.</param>
        /// <returns></returns>
        public Site GetSiteById(Guid siteId)
        {
            return FindByCondition(site => site.SiteId.Equals(siteId))
                .FirstOrDefault();
        }

        /// <summary>
        /// Creates the site.
        /// </summary>
        /// <param name="site">The site.</param>
        public void CreateSite(Site site)
        {
            Create(site);
        }

        /// <summary>
        /// Updates the site.
        /// </summary>
        /// <param name="site">The site.</param>
        public void UpdateSite(Site site)
        {
            Update(site);
        }

        /// <summary>
        /// Deletes the site.
        /// </summary>
        /// <param name="site">The site.</param>
        public void DeleteSite(Site site)
        {
            Delete(site);
        } 
        #endregion
    }
}
