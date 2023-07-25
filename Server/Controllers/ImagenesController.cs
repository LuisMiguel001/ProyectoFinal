using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProyectoFinal.Shared.Models;

namespace ProyectoFinal.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ImagenesController : ControllerBase
{
	private readonly IWebHostEnvironment img;

	public ImagenesController(IWebHostEnvironment img)
	{
		this.img = img;
	}

	[HttpPost]
	public async Task Post([FromBody] Imagenes[] files)
	{
		foreach (var file in files)
		{
			var buf = Convert.FromBase64String(file.base64data);
			await System.IO.File.WriteAllBytesAsync(img.ContentRootPath + System.IO.Path.DirectorySeparatorChar + Guid.NewGuid().ToString("N") + "-" + file.fileName, buf);
		}
	}
}

