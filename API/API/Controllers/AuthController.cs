using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Model;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly UserManager<Utilizador> _userManager;
    private readonly SignInManager<Utilizador> _signInManager;
    private readonly IConfiguration _config;

    public AuthController(UserManager<Utilizador> userManager, SignInManager<Utilizador> signInManager, IConfiguration config)
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _config = config;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] RegisterDTO dto)
    {
        var user = new Utilizador
        {
            UserName = dto.Email,
            Email = dto.Email,
            Nome = dto.Nome,
            DataNascimento = dto.DataNascimento,
            Morada = dto.Morada,
            Genero = dto.Genero,
            Telefone = dto.Telefone,
            EstadoDoUtilizador = true
        };

        var result = await _userManager.CreateAsync(user, dto.Password);

        if (!result.Succeeded)
        {
            var errors = result.Errors.Select(e => e.Description);
            return BadRequest(new { Erros = errors });
        }

        var createdUser = await _userManager.FindByEmailAsync(user.Email);
        if (createdUser == null)
            return StatusCode(500, "Erro interno: utilizador não foi criado.");

        var papel = dto.Papel?.Trim();
        if (papel is not ("Utente" or "Administrador" or "Administrativo"))
            return BadRequest(new { message = "Papel inválido. Deve ser: Utente, Administrador ou Administrativo." });

        await _userManager.AddToRoleAsync(createdUser, papel);

        return Ok(new { message = "Utilizador registado com sucesso." });
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDTO dto)
    {
        var user = await _userManager.FindByEmailAsync(dto.Email);
        if (user == null)
            return Unauthorized("Credenciais inválidas");

        var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
        if (!result.Succeeded)
            return Unauthorized("Credenciais inválidas");

        var token = await GerarToken(user);

        return Ok(new
        {
            token,
            user = new
            {
                user.Id,
                user.UserName,
                user.Email
            }
        });
    }

    private async Task<string> GerarToken(Utilizador user)
    {
        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Email, user.Email),
            new Claim(ClaimTypes.Name, user.UserName)
        };

        var roles = await _userManager.GetRolesAsync(user);
        claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JwtSettings:SecretKey"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = creds
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
