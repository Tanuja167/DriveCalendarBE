using DriveCalendarBE.Entities;
using DriveCalendarBE.Entities.Constants;
using DriveCalendarBE.Entities.DTO;
using DriveCalendarBE.Repository.Interfaces;
using DriveCalendarBE.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace DriveCalendarBE.Services
{
    public class UsersService:IUsersService
    {
        private readonly IUsersRepository repo;
        private readonly IConfiguration configuration;
        public UsersService(IUsersRepository repo, IConfiguration configuration)
        {
            this.repo = repo;
            this.configuration = configuration;
        }
        public string Encrypt(string pass)
        {
            try
            {
                string textToEncrypt = pass;
                string ToReturn = "";
                string publickey = "abcdefgh";
                string secretkey = "hgfedcba";
                byte[] secretkeyByte = { };
                secretkeyByte = System.Text.Encoding.UTF8.GetBytes(secretkey);
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = System.Text.Encoding.UTF8.GetBytes(textToEncrypt);
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateEncryptor(publickeybyte, secretkeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    ToReturn = Convert.ToBase64String(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex.InnerException);
            }
        }
        public string Decrypt(string pass)
        {
            try
            {
                string textToDecrypt = pass;
                string ToReturn = "";
                string publickey = "abcdefgh";
                string privatekey = "hgfedcba";
                byte[] privatekeyByte = { };
                privatekeyByte = System.Text.Encoding.UTF8.GetBytes(privatekey);
                byte[] publickeybyte = { };
                publickeybyte = System.Text.Encoding.UTF8.GetBytes(publickey);
                MemoryStream ms = null;
                CryptoStream cs = null;
                byte[] inputbyteArray = new byte[textToDecrypt.Replace(" ", "+").Length];
                inputbyteArray = Convert.FromBase64String(textToDecrypt.Replace(" ", "+"));
                using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
                {
                    ms = new MemoryStream();
                    cs = new CryptoStream(ms, des.CreateDecryptor(publickeybyte, privatekeyByte), CryptoStreamMode.Write);
                    cs.Write(inputbyteArray, 0, inputbyteArray.Length);
                    cs.FlushFinalBlock();
                    Encoding encoding = Encoding.UTF8;
                    ToReturn = encoding.GetString(ms.ToArray());
                }
                return ToReturn;
            }
            catch (Exception ae)
            {
                throw new Exception(ae.Message, ae.InnerException);
            }
        }

        public int Register(Users users)
        {
            users.RoleId = Convert.ToInt32(users.RoleId);
            users.Password = Encrypt(users.Password);
            return repo.Register(users);
        }

        public LoginOutput Login(Users users)
        {
            

            var user = repo.Login(users);
            if (user != null)
            {
                user.Password = Decrypt(user.Password);
                if (user.Password == users.Password)
                {
                    var token = GenerateJsonWebTokenExtension(user);
                    return new LoginOutput() { Token=token,UserId= user.UserId,RoleId= user.RoleId,UserName= user.UserName};
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }

        }
        private string GenerateJsonWebTokenExtension(Users user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Email,user.EmailId),
                new Claim(ClaimTypes.Role,user.RoleId.ToString()),
                new Claim("UserId",user.UserId.ToString()),
                new Claim(ClaimTypes.Actor,user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
            };

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials: credentials
                );
            var encodeToeken = new JwtSecurityTokenHandler().WriteToken(token);

            return encodeToeken;
        }

        public List<UserOutPutDTO> GetUserOfPE()
        {
            return repo.GetUserOfPE();
        }
        /*
        created by mudassar date 11/3/23
        discription:for creating the function of  update for user in service class

         */
        public int UpdateUsers(Users users)
        {
            users.Password = Encrypt(users.Password);
            return repo.UpdateUsers(users);
        }
        /*
            created by mudassar date 11/4/23
            discription:for creating the function of  update for user in user class
         */
        public int DeleteUser(int id)
        {
            return repo.DeleteUser(id);
        }



        //public IEnumerable<Dto> GetUserList()
        //{
        //    return repo.GetUserList();
        //}

        //IEnumerable<Dto> IUsersService.GetUserList()
        //{
        //    return repo.GetUserList();
        //}

       public IEnumerable<UserDto> GetAllStudentList()
        {
            return repo.GetAllStudentList();
        }
      public IEnumerable<Users> GetUsers() 
        {
            return repo.GetUsers();
        }
    }
}
