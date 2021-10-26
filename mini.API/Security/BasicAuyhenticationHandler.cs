using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using mini.Services.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace mini.API.Security
{
    public class BasicAuthenticationHandler : AuthenticationHandler<BasicAuthenticationOption>
    {
        private ICustomerService customerService;

        public BasicAuthenticationHandler(IOptionsMonitor<BasicAuthenticationOption> optionsMonitor, ILoggerFactory logger, UrlEncoder encoder, ISystemClock clock, ICustomerService customerService) : base(optionsMonitor, logger, encoder, clock)
        {
            this.customerService = customerService;
        }

        protected override Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            //Gelen http request'inin içinde header kısmında "Basic kullaniciadi:sifre" biçiminde bir alan olmalıdır.
            if (!Request.Headers.ContainsKey("Authorization"))
            {
                return Task.FromResult(AuthenticateResult.NoResult());
            }

            if (!AuthenticationHeaderValue.TryParse(Request.Headers["Authorization"], out AuthenticationHeaderValue headerValue))
            {
                return Task.FromResult(AuthenticateResult.NoResult());

            }

            if (!headerValue.Scheme.Equals("Basic", StringComparison.OrdinalIgnoreCase))
            {
                return Task.FromResult(AuthenticateResult.NoResult());
            }

            var values = Convert.FromBase64String(headerValue.Parameter);
            var userNameAndPassword = Encoding.UTF8.GetString(values);
            var userName = userNameAndPassword.Split(':')[0];
            var password = userNameAndPassword.Split(':')[1];

            var user = Task.FromResult( customerService.ValidateCustomer(userName, password)).Result.Result;
            if (user == null)
            {
                return Task.FromResult(AuthenticateResult.Fail("Kullanıcı ya da şifre yanlış"));
            }

            Claim[] claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Role, user.Role)
            };
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, Scheme.Name);
            ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
            AuthenticationTicket ticket = new AuthenticationTicket(claimsPrincipal, headerValue.Scheme);

            return Task.FromResult(AuthenticateResult.Success(ticket));

        }
    }
}
