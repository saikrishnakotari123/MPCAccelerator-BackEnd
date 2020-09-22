using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MPCA.Contracts;
using MPCA.Entities;
using MPCA.Entities.Models;

namespace MPCA.API.Controllers
{
    /// <summary>
    /// Token Controller
    /// </summary>
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ControllerBase" />
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        #region Instance Variable
        public IConfiguration _configuration;
        private ILoggerManager _logger;
        private IRepositoryWrapper _repository;
        private IMapper _mapper;
        private RepositoryContext _context;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="TokenController"/> class.
        /// </summary>
        /// <param name="logger">The logger.</param>
        /// <param name="repository">The repository.</param>
        /// <param name="mapper">The mapper.</param>
        /// <param name="configuration">The configuration.</param>
        public TokenController(ILoggerManager logger, IRepositoryWrapper repository, IMapper mapper, IConfiguration configuration)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
            _configuration = configuration;
        }
        #endregion

        #region Controller API
        /// <summary>
        /// Posts the specified user data.
        /// </summary>
        /// <param name="_userData">The user data.</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post(UserInfo _userData)
        {
            if (_userData != null && _userData.Email != null && _userData.Password != null)
            {
                var user = GetUser(_userData.Email, _userData.Password);

                if (user != null)
                {
                    //create claims details based on the user information
                    var claims = new[] {
                    new Claim(JwtRegisteredClaimNames.Sub, _configuration["Jwt:Subject"]),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                    new Claim("Id", user.UserId.ToString()),
                    new Claim("FirstName", user.FirstName),
                    new Claim("LastName", user.LastName),
                    new Claim("UserName", user.UserName),
                    new Claim("Email", user.Email)
                   };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims, expires: DateTime.UtcNow.AddDays(1), signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid credentials");
                }
            }
            else
            {
                return BadRequest();
            }
        }

        #endregion

        #region Methods
        /// <summary>
        /// Gets the user.
        /// </summary>
        /// <param name="email">The email.</param>
        /// <param name="password">The password.</param>
        /// <returns></returns>
        private UserInfo GetUser(string email, string password)
        {
            //var obj= await _context.UserInfos.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
            var obj = _repository.UserInfo.GetUserInfoByEmailPassword(email, password);
            return obj;
        } 
        #endregion
    }
}
