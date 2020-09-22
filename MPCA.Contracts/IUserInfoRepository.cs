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
    /// <seealso cref="MPCA.Contracts.IRepositoryBase{MPCA.Entities.Models.UserInfo}" />
    public interface IUserInfoRepository : IRepositoryBase<UserInfo>
    {
        /// <summary>
        /// Gets the user information by email password.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        UserInfo GetUserInfoByEmailPassword(string email, string password);

        /// <summary>
        /// Gets all user information.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserInfo> GetAllUserInfo();

        /// <summary>
        /// Gets the user information by identifier.
        /// </summary>
        /// <param name="userId">The user identifier.</param>
        /// <returns></returns>
        public UserInfo GetUserInfoById(Guid userId);

        /// <summary>
        /// Creates the user information.
        /// </summary>
        /// <param name="userInfo">The user information.</param>
        public void CreateUserInfo(UserInfo userInfo);

        /// <summary>
        /// Updates the user information.
        /// </summary>
        /// <param name="userInfo">The user information.</param>
        public void UpdateUserInfo(UserInfo userInfo);

        /// <summary>
        /// Deletes the user information.
        /// </summary>
        /// <param name="userInfo">The user information.</param>
        public void DeleteUserInfo(UserInfo userInfo);
    }
}
