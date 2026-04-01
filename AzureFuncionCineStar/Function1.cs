using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using WebCinestar.Repositories;

namespace AzureFuncionCineStar;

public class Function1
{
    private readonly ILogger<Function1> _logger;
    private readonly CineRepo _CineRepo;
    private readonly PeliculaRepo _PeliRepo;
    public Function1(ILogger<Function1> logger, CineRepo CineRepo, PeliculaRepo PeliRepo)
    {
        _logger = logger;
        _CineRepo = CineRepo;
        _PeliRepo = PeliRepo;
    }

    [Function("GetCines")]
    public async Task<HttpResponseData> GetAllCines([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "cines")] HttpRequestData req)
    {
        _logger.LogInformation("Ejecutando consulta de cines...");
        var listaDeCines = _CineRepo.GetCines();
        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(listaDeCines);
        return response;
    }
    [Function("GetCine")]
    public async Task<HttpResponseData> GetCines([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "cine/{id}")] HttpRequestData req, int id)
    {
        _logger.LogInformation("Ejecutando consulta de cine...");
        var Cine = _CineRepo.GetCine(id);
        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(Cine);
        return response;
    }
    [Function("Peliculas")]
    public async Task<HttpResponseData> GetPeliculasEstado([HttpTrigger(AuthorizationLevel.Anonymous,"get", Route ="peliculas/estado/{id}")] HttpRequestData req, int id)
    {
        _logger.LogInformation("Ejecutando consulta de obtener Peliculas...");
        var peliculas = _PeliRepo.GetPeliculasByEstado(id);
        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(peliculas);
        return response;
    }
    public async Task<HttpResponseData> GetPelicula([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "pelicula/{id}")] HttpRequestData req, int id)
    {
        _logger.LogInformation("Ejecutando consulta de obtener Pelicula...");
        var pelicula= _PeliRepo.GetPeliculaById(id);
        var response = req.CreateResponse(HttpStatusCode.OK);
        await response.WriteAsJsonAsync(pelicula);
        return response;
    }

}