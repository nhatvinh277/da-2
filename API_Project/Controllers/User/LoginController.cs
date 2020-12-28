using API_Project.Assets;
using API_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace API_Project.Controllers
{
    public class LoginController : ControllerBase
    {
        private readonly DA2_DBContext _context;
        private IConfiguration _config;
        public LoginController()
        {
            DbContextOptions<DA2_DBContext> options = new DbContextOptions<DA2_DBContext>();
            _context = new DA2_DBContext(options);
        }

        public LoginController(IConfiguration configLogin)
        {
            DbContextOptions<DA2_DBContext> options = new DbContextOptions<DA2_DBContext>();
            _context = new DA2_DBContext(options);
            _config = configLogin;
        }

        public LoginData AuthenticateUser(string username, string password)
        {
            DBAccount account = null;
            DBUser user = null;
            var userRoles = new List<long>();
            try
            {
                username = username.ToLower();
                account = _context.DBAccount.Where(x => (x.Username.ToString().ToLower().Equals(username.ToString().ToLower()))).FirstOrDefault();

                if (account == null)
                {
                    return new LoginData
                    {
                        isEnableError = true,
                        isMessageError = "Tài khoản hoặc mật khẩu không chính xác."
                    };
                };

                user = _context.DBUser.Where(x => (x.IdUser == account.IdUser && !x.IsDelete)).FirstOrDefault();

                bool pwh = false;


                pwh = (password + account.Salt).ToMD5().Equals(account.Password) ? true : false;

                if (pwh)
                {
                    // Lấy quyền của account
                    LoginData result = new LoginData
                    {
                        Id = user.IdUser.Value,
                        IdAccount = account.IdAccount.Value,
                        UserName = account.Username,
                        Fullname = user.Fullname,
                        isEnableError = false,
                        isMessageError = string.Empty,
                    };

                    result.Token = GenerateJSONWebToken(result);
                    return result;
                }
                return new LoginData
                {
                    isEnableError = true,
                    isMessageError = "Tài khoản hoặc mật khẩu không chính xác."
                };
            }
            catch (Exception ex)
            {
                return new LoginData
                {
                    isEnableError = true,
                    isMessageError = "Hệ thống đang gặp sự cố. Vui lòng quay lại sau."
                };
            }

        }

        public string RefreshJSONWebToken(LoginData account)
        {
            //var permissions = (from per in _context.PqPermission
            //                   join ap in _context.PqAccountPermit on per.Code equals ap.Code into AccountPermission
            //                   from accPer in AccountPermission.DefaultIfEmpty()
            //                   where accPer.UserName.ToString().Equals(account.UserName.ToString()) && per != null
            //                   select per.Code
            //                                                  ).Union(
            //                                                      from per in _context.PqPermission
            //                                                      join gp in _context.PqGroupPermit on per.Code equals gp.Code into GroupPermission
            //                                                      from grPer in GroupPermission.DefaultIfEmpty()
            //                                                      join g in _context.PqGroupAccount on grPer.IdGroup equals g.IdGroup into Group
            //                                                      from grp in Group.DefaultIfEmpty()
            //                                                      join ga in _context.PqGroupAccount on grp.UserName equals ga.UserName into GroupAccount
            //                                                      from groupaccount in GroupAccount.DefaultIfEmpty()
            //                                                      where groupaccount.UserName.ToString().Equals(account.UserName.ToString()) && per != null
            //                                                      select per.Code
            //                                                  )
            //                                                  .Distinct().ToList();
            //account.Rules = permissions;
            account.Token = GenerateJSONWebToken(account);
            return account.Token;
        }

        private string GenerateJSONWebToken(LoginData userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>();

            LoginData account = new LoginData
            {
                Id = userInfo.Id,
                IdAccount = userInfo.IdAccount,
                UserName = userInfo.UserName,
                //Rules = userInfo.Rules,
                Fullname = userInfo.Fullname,
            };


            claims.Add(new Claim(JwtRegisteredClaimNames.Sub, account.UserName));
            claims.Add(new Claim("user", (account == null) ? null : JsonConvert.SerializeObject(account)));
            claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));


            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(10),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //public string GenerateJSONWebTokenDevice(SysRequestLogin device)
        //{
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var claims = new List<Claim>();

        //    claims.Add(new Claim("device", (device == null) ? null : JsonConvert.SerializeObject(device)));
        //    claims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));

        //    var token = new JwtSecurityToken(_config["Jwt:Issuer"],
        //      _config["Jwt:Issuer"],
        //      claims,
        //      expires: DateTime.Now.AddYears(10),
        //      signingCredentials: credentials);

        //    return new JwtSecurityTokenHandler().WriteToken(token);
        //}

        private static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        private static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }

        public LoginData _GetInfoUser(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            try
            {
                token = token.Replace("Bearer ", string.Empty);

                var tokenS = handler.ReadJwtToken(token) as JwtSecurityToken;
                LoginData account = JsonConvert.DeserializeObject<LoginData>(tokenS.Claims.First(claim => claim.Type == "user").Value);


                account.Token = token;

                return account;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public List<string> _GetAllRuleUser(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            try
            {
                token = token.Replace("Bearer ", string.Empty);

                var tokenS = handler.ReadJwtToken(token) as JwtSecurityToken;

                List<string> rules = new List<string>();

                foreach (var r in tokenS.Claims.Where(x => x.Type == "http://schemas.microsoft.com/ws/2008/06/identity/claims/role").ToList())
                {
                    rules.Add(r.Value);
                }
                return rules;

            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public LoginData _GetFullInfoUser(string token)
        {
            var handler = new JwtSecurityTokenHandler();
            try
            {
                token = token.Replace("Bearer ", string.Empty);

                var tokenS = handler.ReadJwtToken(token) as JwtSecurityToken;
                LoginData account = JsonConvert.DeserializeObject<LoginData>(tokenS.Claims.First(claim => claim.Type == "user").Value);

                //LoginData account = new LoginData
                //{
                //    UserName = tokenS.Claims.First(claim => claim.Type == "username").Value,
                //    Id = (long)Convert.ToDouble(tokenS.Claims.First(claim => claim.Type == "id").Value),
                //    Rules = JsonConvert.DeserializeObject<List<string>>(tokenS.Claims.First(claim => claim.Type == "userroles").Value),
                //    FirstName = tokenS.Claims.First(claim => claim.Type == "firstname").Value,
                //    LastName = tokenS.Claims.First(claim => claim.Type == "lastname").Value,
                //};
                account.Token = token;

                return account;

            }
            catch (Exception ex)
            {
                return null;
            }

        }

        private const string PASSWORD_ED = "JeeHR_DPSSecurity435";

        public string GetHeader(HttpRequest request)
        {
            try
            {
                Microsoft.Extensions.Primitives.StringValues headerValues;
                request.Headers.TryGetValue("Authorization", out headerValues);
                return headerValues.FirstOrDefault();
            }
            catch (Exception ex)
            {
                return string.Empty;
            }

        }

        public string GetLastCode_JWT(string Token)
        {
            return Token.Substring(Token.LastIndexOf('.') + 1);
        }

        public class UserModel
        {
            public string username { get; set; }
            public string password { get; set; }
        }
    }
}
