#region Namespace
using AutoMapper;
using MPCA.Entities.DataTransferObjects;
using MPCA.Entities.Models; 
#endregion

namespace MPCA.API
{
    /// <summary>
    /// Mapping Profile
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<Site, SiteDto>();

            CreateMap<Tenant, TenantDto>();

            CreateMap<TenantForCreationDto, Tenant>();

            CreateMap<TenantForUpdateDto, Tenant>();
       
        }
    }
}
