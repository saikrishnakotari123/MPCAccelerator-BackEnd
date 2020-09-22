using MPCA.Contracts;
using MPCA.Entities;
using MPCA.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MPCA.Repositories
{
    public class RoleRepository : RepositoryBase<Role>, IRoleRepository
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="UserInfoRepository"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        public RoleRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
        }
        #endregion

        #region Method        
        /// <summary>
        /// Gets the user information by identifier.
        /// </summary>
        /// <param name="roleId">The role identifier.</param>
        /// <returns></returns>
        public Role GetRoleById(Guid roleId)
        {
            return FindByCondition(role => role.ID.Equals(roleId))
                .FirstOrDefault();
        }
        /// <summary>
        /// Gets all role.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Role> GetAllRole()
        {
            return FindAll()
                 .OrderBy(t => t.RoleName)
                 .ToList();
        }
        /// <summary>
        /// Creates the role information.
        /// </summary>
        /// <param name="role">The role.</param>
        public void CreateRole(Role role)
        {
            Create(role);
        }
        /// <summary>
        /// Updates the role information.
        /// </summary>
        /// <param name="role">The role.</param>
        public void UpdateRole(Role role)
        {
            Update(role);
        }
        /// <summary>
        /// Deletes the role information.
        /// </summary>
        /// <param name="role">The role.</param>
        public void DeleteRole(Role role)
        {
            Delete(role);
        }
        #endregion

    }
}
