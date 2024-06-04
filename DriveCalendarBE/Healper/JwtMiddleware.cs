using DriveCalendarBE.Services.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace DriveCalendarBE.Healper
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;
        public JwtMiddleware(RequestDelegate next,IOptions<AppSettings> appsetting)
        {
            _next = next;
            _appSettings = appsetting.Value;
        }

        public async Task Invoke(HttpContext context, IUsersService userService)
        {
            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token != null)
            {
                AttachUserToContext(context,userService,token); 
            }
            await _next(context);
        }
        private void AttachUserToContext(HttpContext context,IUsersService usersService,string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validateToken);
                var jwtToken = (JwtSecurityToken)validateToken;
                var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);
            }
            catch { }
        }
    }
}
