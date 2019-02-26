﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using A1backend.ViewFolders;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using static A1backend.ViewFolders.ApplicationUser;

namespace A1backend.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;

        public AuthController(UserManager<IdentityUser> userManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _configuration = configuration;
        }
        //register
        [Route("register")]
        [HttpPost]
        public async Task<ActionResult> InsertUser([FromBody] ApplicationUser model)
        {
            model.SecurityStamp = Guid.NewGuid().ToString();
            //var user = new IdentityUser
            //{
            //Email = model.Email,
            //UserName = model.Email,
            //PasswordHash = model.Password,
            //FirstName = model.FirstName,
            //LastName = model.Lastname,
            //Country = model.Country,
            //PhoneNumber = model.PhoneNumber,


            //};
            var result = await _userManager.CreateAsync(model, model.PasswordHash);
            if (result.Succeeded)
            {
                await _userManager.AddToRoleAsync(model, "Member");
            }
            return Ok();
        }
        //login
        [Route("login")]
        [HttpPost]
        public async Task<ActionResult> Login([FromBody] ApplicationUser model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var claim = new[] {
        new Claim(JwtRegisteredClaimNames.Sub, user.UserName)
      };
                var signinKey = new SymmetricSecurityKey(
                  Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));

                int expiryInMinutes = Convert.ToInt32(_configuration["Jwt:ExpiryInMinutes"]);

                var token = new JwtSecurityToken(
                  issuer: _configuration["Jwt:Site"],
                  audience: _configuration["Jwt:Site"],
                  expires: DateTime.UtcNow.AddMinutes(expiryInMinutes),
                  signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
                );

                return Ok(
                  new
                  {
                      token = new JwtSecurityTokenHandler().WriteToken(token),
                      expiration = token.ValidTo
                  });
            }
            return Unauthorized();
        }
    }
}

