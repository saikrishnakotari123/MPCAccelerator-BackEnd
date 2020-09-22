#region Namespace
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MPCA.Contracts;
using MPCA.Entities.DataTransferObjects;
using MPCA.Entities.Models; 
#endregion

namespace MPCA.API.Controllers
{
    /// <summary>
    /// Tenants Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TenantsController : ControllerBase
    {
        #region Instance Variable
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="TenantsController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        public TenantsController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }
        #endregion

        #region Controller API
        // GET: api/Tenants
        /// <summary>
        /// Gets the tenants.
        /// </summary>
        /// <param name="skip">The skip.</param>
        /// <param name="take">The take.</param>
        /// <returns></returns>
        [HttpGet]
        //[Authorize(Policy = "CanReadTenant")]
        public async Task<ActionResult<IEnumerable<Tenant>>> GetAllTenants()
        {
            try
            {
                var tenants = _repository.Tenant.GetAllTenants();
                _logger.LogInfo($"Returned all tenants from database.");

                var tenantsResult = _mapper.Map<IEnumerable<TenantDto>>(tenants);
                return Ok(tenantsResult);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllTenants action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // GET: api/Tenants/5
        /// <summary>
        /// Gets the tenant.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpGet("{id}", Name = "GetTenantById")]
      //  [Authorize(Policy = "CanReadTenant")]
        public async Task<ActionResult<Tenant>> GetTenantById(Guid id)
        {
            try
            {
                var Tenant = _repository.Tenant.GetTenantById(id);
                if (Tenant == null)
                {
                    _logger.LogError($"Tenant with id: {id}, hasn't been found in db.");
                    return NotFound();
                }
                else
                {
                    _logger.LogInfo($"Returned Tenant with id: {id}");

                    var ownerResult = _mapper.Map<TenantDto>(Tenant);
                    return Ok(ownerResult);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetTenantById action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }


        // PUT: api/Tenants/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Puts the tenant.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="tenant">The tenant.</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTenant(Guid id, Tenant tenant)
        {
            if (id != tenant.TenantId)
            {
                return BadRequest();
            }

            try
            {
                // await _repository.Tenant.CreateTenant(tenant);
                _repository.Tenant.UpdateTenant(tenant);
                _repository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TenantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Tenants
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        /// <summary>
        /// Creates the tenant.
        /// </summary>
        /// <param name="tenant">The tenant.</param>
        /// <returns></returns>
        [HttpPost]
       // [Authorize(Policy = "CanWriteTenant")]
        public async Task<ActionResult<Tenant>> CreateTenant(TenantForCreationDto tenant)
        {
            try
            {
                if (tenant == null)
                {
                    _logger.LogError("Tenant object sent from client is null.");
                    return BadRequest("Tenant object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid tenant object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var tenantEntity = _mapper.Map<Tenant>(tenant);

                _repository.Tenant.CreateTenant(tenantEntity);
                _repository.Save();

                var createdTenant = _mapper.Map<TenantDto>(tenantEntity);

                return CreatedAtRoute("GetTenantById", new { id = createdTenant.TenantId }, createdTenant);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside CreateTenant action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }

        }

        /// <summary>
        /// Updates the tenant.
        /// </summary>
        /// <param name="tenant">The tenant.</param>
        /// <returns></returns>
        [HttpPut]
      //  [Authorize(Policy = "CanWriteTenant")]
        public async Task<ActionResult<Tenant>> UpdateTenant(TenantForUpdateDto tenant)
        {
            try
            {
                if (tenant == null)
                {
                    _logger.LogError("Tenant object sent from client is null.");
                    return BadRequest("Tenant object is null");
                }

                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid tenant object sent from client.");
                    return BadRequest("Invalid model object");
                }

                var tenantEntity = _repository.Tenant.GetTenantById(tenant.TenantId);
                if (tenantEntity == null)
                {
                    _logger.LogError($"Tenant with id: {tenant.TenantId}, hasn't been found in db.");
                    return NotFound();
                }

                _mapper.Map(tenant, tenantEntity);

                _repository.Tenant.UpdateTenant(tenantEntity);
                _repository.Save();
                return CreatedAtRoute("GetTenantById", new { id = tenantEntity.TenantId }, tenantEntity);
                //return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside UpdateTenant action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }

        // DELETE: api/Tenants/5
        /// <summary>
        /// Deletes the tenant.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
       // [Authorize(Policy = "CanDeleteTenant")]
        public async Task<ActionResult<Tenant>> DeleteTenant(Guid id)
        {
            try
            {
                var tenant = _repository.Tenant.GetTenantById(id);
                if (tenant == null)
                {
                    _logger.LogError($"Tenant with id: {id}, hasn't been found in db.");
                    return NotFound();
                }

                //if (_repository.Site.GetSitesByTenant(id))
                //{
                //    _logger.LogError($"Cannot delete tenant with id: {id}. It has related sites. Delete those sites first");
                //    return BadRequest("Cannot delete tenant. It has related sites. Delete those sites first");
                //}

                _repository.Tenant.DeleteTenant(tenant);
                _repository.Save();

                return NoContent();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside DeleteTenant action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        #endregion

        #region Methods
        /// <summary>Tenants the exists.</summary>
        /// <param name="id">The identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        private bool TenantExists(Guid id)
        {
            return _repository.Tenant.IsTenantExists(id);
        } 
        #endregion
    }
}
