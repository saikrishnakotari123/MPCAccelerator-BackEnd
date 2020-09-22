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
    /// User Info Repository
    /// </summary>
    /// <seealso cref="MPCA.Repositories.RepositoryBase{MPCA.Entities.Models.UserInfo}" />
    /// <seealso cref="MPCA.Contracts.IUserInfoRepository" />
    public class UserInfoRepository : RepositoryBase<UserInfo>, IUserInfoRepository
    {
        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="UserInfoRepository"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        public UserInfoRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets all user information.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserInfo> GetAllUserInfo()
        {
            return FindAll()
                .OrderBy(t => t.UserName)
                .ToList();
        }

        /// <summary>
        /// Gets the user information by email password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        public UserInfo GetUserInfoByEmailPassword(string email, string password)
        {
            return FindByCondition(userInfo => userInfo.Email.Equals(email))
                .FirstOrDefault();

            //return FindByCondition(userInfo => userInfo.Email.Equals(email) && userInfo.Password.Equals(password) )
            //    .FirstOrDefault();
        }

        /// <summary>
        /// Gets the user information by identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public UserInfo GetUserInfoById(Guid userId)
        {
            return FindByCondition(userInfo => userInfo.UserId.Equals(userId))
                .FirstOrDefault();
        }

        /// <summary>
        /// Creates the user information.
        /// </summary>
        /// <param name="userInfo">The user information.</param>
        public void CreateUserInfo(UserInfo userInfo)
        {
            Create(userInfo);
        }

        /// <summary>
        /// Updates the user information.
        /// </summary>
        /// <param name="userInfo">The user information.</param>
        public void UpdateUserInfo(UserInfo userInfo)
        {
            Update(userInfo);
        }

        /// <summary>
        /// Deletes the user information.
        /// </summary>
        /// <param name="userInfo">The user information.</param>
        public void DeleteUserInfo(UserInfo userInfo)
        {
            Delete(userInfo);
        } 
        #endregion
    }
}
