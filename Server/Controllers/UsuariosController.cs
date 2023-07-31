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
    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login([FromBody] Sesion login)
    {
        LoginDTO sesionDTO = new LoginDTO();

        if (login.Correo == "admin@gmail.com" && login.Clave == "admin")
        {
            sesionDTO.Nombre = "admin";
            sesionDTO.Correo = login.Correo;
            sesionDTO.Rol = "Administrador";
        }
        else
        {
            sesionDTO.Nombre = "empleado";
            sesionDTO.Correo = login.Correo;
            sesionDTO.Rol = "Empleado";
        }

        return StatusCode(StatusCodes.Status200OK, sesionDTO);
    }
}