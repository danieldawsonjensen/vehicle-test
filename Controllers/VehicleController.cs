using Microsoft.AspNetCore.Mvc;
using Model;
using Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text;
using System.Threading.Channels;
using System.Text.Json;
using System.Net;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class VehicleController : ControllerBase
{
    private static List<Vehicle> Vehicles = new List<Vehicle>()
    {
        new Vehicle
        {
            VehicleId = 1,
            VehicleBrand = "Mercedes",
            VehicleModel = "Mercedes X230",
            VehicleRegNr = "VJ30535",
            MilesDriven = 100
        },
        new Vehicle
        {
            VehicleId = 2,
            VehicleBrand = "Audi",
            VehicleModel = "Audi R8",
            VehicleRegNr = "BK21211",
            MilesDriven = 35000
        }
    };

    private readonly ILogger<VehicleController> _logger;
    private readonly IConfiguration _config;

    public VehicleController(ILogger<VehicleController> logger, IConfiguration config)
    {
        _logger = logger;
        _config = config;
    }


    [Authorize]
    [HttpPost("addvehicle"), DisableRequestSizeLimit]
    public async Task<IActionResult> Post([FromBody] Vehicle? vehicle)
    {
        _logger.LogInformation("addVehicle funktion ramt");

        var newVehicle = new Vehicle // opretter det vehicle objekt der sendes fra Postman body input felt
        {
            VehicleId = vehicle.VehicleId,
            VehicleBrand = vehicle.VehicleBrand,
            VehicleRegNr = vehicle.VehicleRegNr,
            MilesDriven = vehicle.MilesDriven
        };
        _logger.LogInformation("nyt vehicle objekt lavet");


        if (newVehicle.VehicleId == 0)
        {
            return BadRequest("Invalid ID");
        }
        else
        {
            Vehicles.Add(newVehicle);
        }
        _logger.LogInformation("nyt vehicle objekt added til Vehicles list");


        return Ok(newVehicle);

    }


    [Authorize]
    [HttpGet("getallvehicles"), DisableRequestSizeLimit]
    public async Task<IActionResult> GetAllVehicles() //skal måske laves om til at returne en list (public list<vehicle> GetAllVehicles()
    {
        _logger.LogInformation("getAllVehicles funktion ramt");

        if (Vehicles == null)
        {
            return BadRequest("Vehicles list is empty");
        }


        return Ok(Vehicles.OrderBy(a => a.VehicleId));
    }


    [Authorize]
    [HttpGet("getvehicle/{id}"), DisableRequestSizeLimit]
    public async Task<IActionResult> GetVehicle(int id) //skal måske laves om til at returne en list (public list<vehicle> GetAllVehicles()
    {
        _logger.LogInformation("getVehicle funktion ramt");

        Vehicle vehicle = new Vehicle(); //initialiserer nyt vehicle objekt
        vehicle = Vehicles.FirstOrDefault(a => a.VehicleId == id)!; //sætter vehicle til matchende id

        _logger.LogInformation("ønsket vehicle object sat til vehicle objekt med id");


        return Ok(vehicle);
    }


    [Authorize]
    [HttpPost("servicehistory/{id}"), DisableRequestSizeLimit]
    public async Task<IActionResult> Post([FromBody] Service? serviceHistory, int id)
    {
        _logger.LogInformation("Tilføj service historik til specifikt køretøj");

        var vehicle = Vehicles.FirstOrDefault(a => a.VehicleId == id);

        var newServiceHistory = new Service //Opretter specifik service historik til gældende køretøj
        {

            ServiceReferenceId = serviceHistory.ServiceReferenceId,
            ServiceDate = serviceHistory.ServiceDate,
            ServiceDescription = serviceHistory.ServiceDescription,
            ServiceWorkerName = serviceHistory.ServiceWorkerName

        };

        _logger.LogInformation("Ny service kontrakt oprettet på den pågældende bil.");

        if (newServiceHistory.ServiceReferenceId == 0)
        {
            return BadRequest("Invalid ID (Not Null).");
        }
        else
        {
            //ServiceHistory.Add(newServiceHistory);
            vehicle.ServiceHistory.Add(newServiceHistory);
        }

        _logger.LogInformation("Ny service historik tilføjet.");

        return Ok(serviceHistory);

    }


}