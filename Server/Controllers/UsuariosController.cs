using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Server.DAL;
using ProyectoFinal.Shared.Models;

namespace ProyectoFinal.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly LibrosContext _context;

    public UsuariosController(LibrosContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Login>>> GetUsuarios()
    {
        if (_context.Login == null)
        {
            return NotFound();
        }
        return await _context.Login.ToListAsync();
    }

    [HttpGet("GetRoles")]
    public async Task<ActionResult<IEnumerable<Roles>>> GetRoles()
    {

        var roles = await _context.Roles.ToListAsync();
        if (roles == null || roles.Count == 0)
        {
            return NotFound();
        }
        return Ok(roles);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Login>> GetUsuarios(int id)
    {
        if (_context.Login == null)
        {
            return NotFound();
        }
        var Usuarios = await _context.Login.FindAsync(id);

        if (Usuarios == null)
        {
            return NotFound();
        }

        return Usuarios;
    }

    public bool UsuarioExiste(int id)
    {
        return (_context.Login?.Any(u => u.LoginId == id)).GetValueOrDefault();
    }
    [HttpPost]

    public async Task<ActionResult<Login>> GetUsuarios(Login Usuarios)
    {
        if (!UsuarioExiste(Usuarios.LoginId))
            _context.Login.Add(Usuarios);
        else
            _context.Login.Update(Usuarios);
        await _context.SaveChangesAsync();
        return Ok(Usuarios);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUsuario(int id)
    {
        if (_context.Login == null)
        {
            return NotFound();
        }
        var Usuarios = await _context.Login.FindAsync(id);
        if (Usuarios == null)
        {
            return NotFound();
        }
        _context.Login.Remove(Usuarios);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpPost("AuthenticateUser")]
    public ActionResult<bool> AuthenticateUser([FromBody] Login loginModel)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid login data");
            }

            var user = _context.Login.FirstOrDefault(u => u.Email == loginModel.Email);

            if (user == null)
            {
                return NotFound("User not found.");
            }

            bool isPasswordValid = VerifyPassword(loginModel.Password, user.PasswordHash, user.Salt);

            if (!isPasswordValid)
            {
                return BadRequest("Invalid password.");
            }

            return Ok(true);
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error: {ex.Message}");
        }
    }

    private bool VerifyPassword(string password, string savedPasswordHash, string salt)
    {
        string hashedPassword = PasswordHashHelper.GetHashedPassword(password, salt);

        return hashedPassword == savedPasswordHash;
    }
}