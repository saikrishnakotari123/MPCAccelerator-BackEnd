#region Namespace
using MPCA.Contracts;
using MPCA.Entities; 
#endregion

namespace MPCA.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MPCA.Contracts.IRepositoryWrapper" />
    public class RepositoryWrapper : IRepositoryWrapper
    {
        #region Instance Variable       
        private RepositoryContext _repoContext;
        private ITenantRepository _tenant;
        private ISiteRepository _site;
        private IUserInfoRepository _userInfo;
        private IRoleRepository _role;
        #endregion

        #region Properties
        /// <summary>
        /// Gets the tenant.
        /// </summary>
        /// <value>
        /// The tenant.
        /// </value>
        public ITenantRepository Tenant
        {
            get
            {
                if (_tenant == null)
                {
                    _tenant = new TenantRepository(_repoContext);
                }
                return _tenant;
            }
        }

        /// <summary>
        /// Gets the site.
        /// </summary>
        /// <value>
        /// The site.
        /// </value>
        public ISiteRepository Site
        {
            get
            {
                if (_site == null)
                {
                    _site = new SiteRepository(_repoContext);
                }
                return _site;
            }
        }

        /// <summary>
        /// Gets the user information.
        /// </summary>
        /// <value>
        /// The user information.
        /// </value>
        public IUserInfoRepository UserInfo
        {
            get
            {
                if (_userInfo == null)
                {
                    _userInfo = new UserInfoRepository(_repoContext);
                }
                return _userInfo;
            }
        }

        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        public IRoleRepository Role
        {
            get
            {
                if (_role == null)
                {
                    _role = new RoleRepository(_repoContext);
                }
                return _role;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositoryWrapper"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        public RepositoryWrapper(RepositoryContext repositoryContext)
        {
            _repoContext = repositoryContext;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Saves this instance.
        /// </summary>
        public void Save()
        {
            _repoContext.SaveChanges();
        } 
        #endregion
    }
}
