using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Shared.Models;

namespace ProyectoFinal.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
	[HttpPost]
	[Route("Login")]
	public async Task<IActionResult> Login([FromBody] Libros login)
	{
		Sesion sesionDTO = new Sesion();

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

