using Microsoft.AspNetCore.Mvc;
using System.Numerics;
namespace Dsw2026Ej15.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DoctorsController : ControllerBase
{
    private readonly IPersistence _persistence;

    public DoctorsController(IPersistence persistence)
    {
        _persistence = persistence;
    }

    [HttpPost]
    public IActionResult Create([FromBody] Doctor doctor)
    {
        _persistence.AddDoctor(doctor);
        return Ok(doctor);
    }
}

internal interface IPersistence
{
    void AddDoctor(Doctor doctor);
}