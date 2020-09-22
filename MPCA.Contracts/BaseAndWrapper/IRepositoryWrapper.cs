namespace MPCA.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    public interface IRepositoryWrapper
    {
        /// <summary>
        /// Gets the tenant.
        /// </summary>
        /// <value>
        /// The tenant.
        /// </value>
        ITenantRepository Tenant { get; }

        /// <summary>
        /// Gets the site.
        /// </summary>
        /// <value>
        /// The site.
        /// </value>
        ISiteRepository Site { get; }

        /// <summary>
        /// Gets the user information.
        /// </summary>
        /// <value>
        /// The user information.
        /// </value>
        IUserInfoRepository UserInfo { get; }

        /// <summary>
        /// Gets the role.
        /// </summary>
        /// <value>
        /// The role.
        /// </value>
        IRoleRepository Role { get; }

        /// <summary>
        /// Saves this instance.
        /// </summary>
        void Save();
    }
}
