using Dto;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

namespace Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly ITokenService _tokenService;

    public AuthController(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpPost]
    public ActionResult Login(Login login)
    {
        var token = _tokenService.GenerateToken(login);
        
        if(token ==  "")
            return Unauthorized("Você não tem autorização!");

        return Ok(token);
    }
}