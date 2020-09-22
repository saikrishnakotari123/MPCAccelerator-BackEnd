#region Namespace
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MPCA.Contracts;
using MPCA.Entities.DataTransferObjects;
using MPCA.Entities.Models; 
#endregion

namespace MPCA.API.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class SitesController : ControllerBase
    {
        #region Instance Variable
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="SitesController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        public SitesController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        #endregion

        #region Controller API
        // GET: api/Sites
        /// <summary>
        /// Gets the sites by tenant.
        /// </summary>
        /// <param name="tenantId">The tenant identifier.</param>
        /// <param name="skip">The skip.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Site>>> GetSitesByTenant(Guid tenantId, int? skip, int? take)
        {
            try
            {
                var sites = _repository.Site.GetSitesByTenant(tenantId);
                _logger.LogInfo($"Returned all tenants from database.");

                var sitesResult = _mapper.Map<IEnumerable<SiteDto>>(sites);
                return Ok(sitesResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllTenants action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/Sites/5
        /// <summary>
        /// Gets the site by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Site>> GetSiteById(Guid id)
        {
            try
            {
                var site = _repository.Site.GetSiteById(id);
                if (site == null)
                {
                    _logger.LogError($"Site with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned Site with id: {id}");

                    var siteResult = _mapper.Map<SiteDto>(site);
                    return Ok(siteResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetSiteById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        } 
        #endregion
    }
}
