using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;
using webApiPostgrees.Model;

namespace webApiPostgrees.Controllers;

[Route("api/ConsultasBasicas")]
[ApiController]
public class SuscriptorController : ControllerBase
{
    private readonly AplicationDbContext dbContext;

    public SuscriptorController(AplicationDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

[HttpGet("ConsultarSuscriptores")]
public async Task<ActionResult<List<ResponseSuscriptor>>> ConsultarSuscriptores()
{
    var suscriptores = await dbContext.Suscriptores.ToListAsync();

    var responseList = new List<ResponseSuscriptor>();

    foreach (var suscriptor in suscriptores)
    {
        var point = new Point(suscriptor.Longitud, suscriptor.Latitud) { SRID = 4326 }; // Asume que estás usando el sistema de coordenadas WGS 84.

        var predioAsociado = await dbContext.Predios.FirstOrDefaultAsync(p => p.Geom.Contains(point));
        
        var responseSuscriptor = new ResponseSuscriptor
        {
            Id = suscriptor.Id,
            Nombre = suscriptor.Nombre,
            direccion = suscriptor.direccion,
            Latitud = suscriptor.Latitud,
            Longitud = suscriptor.Longitud,
            Estrato = predioAsociado?.Estrato ?? 0 // Usamos el operador ?. para manejar la posibilidad de que no se encuentre un predio asociado.
        };

        responseList.Add(responseSuscriptor);
    }

    return Ok(responseList);
}

    [HttpGet("consultarPredio")]
    public async Task<ActionResult<List<Predio>>> consultarPredio()
    {
        return await dbContext.Predios.ToListAsync();
    }

}
