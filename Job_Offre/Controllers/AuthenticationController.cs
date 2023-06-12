using AutoMapper;
using Job_Offre.Entities;
using Job_Offre.Models.Dtos.UserDtos;
using Job_Offre.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace Job_Offre.Controllers
{
    [Route("api/authentiation")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public class AuthenticationRequestBody
        {
            public string? Email { get; set; }
            public string? Password { get; set; }
            public string? Role { get; set; }
        }

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IUserRepository UserRepository, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = UserRepository;
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _configuration = configuration;
        }
        [HttpPost("authenticate")]
        public async Task<ActionResult<string>> Authenticate(AuthenticationRequestBody authenticationRequestBody)
        {
            var user = await validateUserCredentials(authenticationRequestBody.Email,
                authenticationRequestBody.Password,
                authenticationRequestBody.Role);
            if (user == null)
            {
                Console.WriteLine("NotFiniteNumberException Found User");
                return Unauthorized();
            }
            //create a token :
            var securityKey = new SymmetricSecurityKey(
               Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForKey"]));
            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("userName", user.UserName));
            claimsForToken.Add(new Claim("userCode", user.UserCode.ToString()));
            claimsForToken.Add(new Claim("roleCode", user.RoleCode.ToString()!));
            //claimsForToken.Add(new Claim("userEmail", authenticationRequestBody.Email!));
            //claimsForToken.Add(new Claim("userEmail", authenticationRequestBody.Role!));

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials);

            Console.WriteLine($"--> claimsForToken = {claimsForToken}");
            Console.WriteLine($"--> signingCredentials = {signingCredentials}");

            var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
            string tokenToJson = JsonSerializer.Serialize(tokenToReturn);
            return Ok(tokenToJson);
            //return Ok(tokenToReturn);

        }

        private async Task<UserReadDto> validateUserCredentials(string? email, string? password, string? role)
        {
            var userDTO = new UserReadDto();
            int passwordLength = password!.Length;
            var usr = await _userRepository.GetUserByEmail(email!, role!);

            userDTO.UserPw = usr.UserPw;
            userDTO.UserName = usr.UserName;
            userDTO.UserCode = usr.UserCode;
            userDTO.RoleCode = usr.RoleCode;

            string result = Encoding.ASCII.GetString(userDTO.UserPw);
            string result2 = result.Substring(0, passwordLength);

            if (result2 == password)
            {
                return userDTO;
            }
            else
            {
                throw new Exception("mot de passe incorrecte");
            }
         
        }


    }   
}





//Le gestionnaire de paquets NuGet met à disposition plusieurs paquets vous permettant de générer votre propre jeton. 
//    Microsoft a mis en ligne le sien : "System.IdentityModel.Tokens.Jwt".Dans ce paquet, on retrouve la classe 
//    "SymmetricKey" qui permet de générer des clés sécurisées à partir d'un encodage. Le standard JWT en accepte plusieurs, 
//    notamment HMACSHA256.