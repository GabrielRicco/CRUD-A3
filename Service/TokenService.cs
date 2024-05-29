using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Dto;
using Microsoft.IdentityModel.Tokens;
using Repositories;

namespace Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _configuration;
    private readonly IUserRepository _userRepository;
    public TokenService(IConfiguration configuration, IUserRepository userRepository)
    {
        _configuration = configuration;
        _userRepository = userRepository;
    }
    public string GenerateToken(Login user)
    {
        var userDataBase = _userRepository.GetByUsernameAsync(user.Username);

        if(user.Username != userDataBase.Result.Username || user.Password != userDataBase.Result.Password)
        {
            return string.Empty;
        }

        var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"] ?? string.Empty));
        var issuer = _configuration["Jwt:Issuer"];
        var audience = _configuration["Jwt:Audience"];

        var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

        var tokenOptions = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            claims: new []
            {
                new Claim(type: ClaimTypes.Name, userDataBase.Result.Username),
                new Claim(type: ClaimTypes.Role, userDataBase.Result.Role),
            },
            expires:DateTime.Now.AddHours(2),
            signingCredentials: signinCredentials
        );

        var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

        return token;
    }
}