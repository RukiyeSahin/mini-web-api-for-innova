using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using mini.API.Models;
using mini.DTO.Requests;
using mini.Models.Entities;
using mini.Services.Business;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace mini.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private ICustomerService customerService;

        public CustomersController(ICustomerService customerService)
        {
            this.customerService = customerService;
        }
        [HttpPost]
        public async Task<IActionResult> AddNewCustomer(AddCustomerRequest request)
        {
            if (ModelState.IsValid)
            {
                Guid lastCustomerId = await customerService.AddCustomer(request);
                return Created(string.Empty, lastCustomerId);


            }
            return BadRequest(ModelState);

        }

        [HttpPost("Login")]
        
        public async Task<IActionResult> Login(UserLoginModel user)
        {
            var existingUser = await customerService.ValidateCustomer(user.UserName, user.Password);
            if (existingUser != null)
            {
                if (ModelState.IsValid)
                {

                    Claim[] claims = new Claim[]
                    {
                        new Claim(ClaimTypes.Name, user.UserName),
                        new Claim(ClaimTypes.Role,existingUser.Role),
                        new Claim(JwtRegisteredClaimNames.Birthdate,existingUser.BirthDate.ToString())

                    };

                    var issuer = "innovapp";
                    var audience = "innovapp";
                    var securityKey = "donulmez* aksamin*ufkundayiz * vakit * cok * gec";

                    var signinSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
                    var credential = new SigningCredentials(signinSecurityKey, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(issuer: issuer,
                                                     audience: audience,
                                                     claims: claims,
                                                     notBefore: DateTime.UtcNow,
                                                     expires: DateTime.Now.AddHours(1),
                                                     signingCredentials: credential);

                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });


                 
                }
                return BadRequest(ModelState);
            }

            return BadRequest("Kullanıcı adı ya da şifre yanlış");
        }
    }
}
