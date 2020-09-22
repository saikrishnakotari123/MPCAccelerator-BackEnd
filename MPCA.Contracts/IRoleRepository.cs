using MPCA.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MPCA.Contracts
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="MPCA.Contracts.IRepositoryBase{MPCA.Entities.Models.Role}" />
    public interface IRoleRepository : IRepositoryBase<Role>
    {

        /// <summary>
        /// Gets all role.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Role> GetAllRole();
        /// <summary>
        /// Gets the user information by identifier.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns></returns>
         public Role GetRoleById(Guid roleId);
        /// <summary>
        /// Creates the role information.
        /// </summary>
        /// <param name="role">The role.</param>
        public void CreateRole(Role role);
        /// <summary>
        /// Updates the role information.
        /// </summary>
        /// <param name="role">The role.</param>
        public void UpdateRole(Role role);
        /// <summary>
        /// Deletes the role information.
        /// </summary>
        /// <param name="role">The role.</param>
        public void DeleteRole(Role role);

    }
}
