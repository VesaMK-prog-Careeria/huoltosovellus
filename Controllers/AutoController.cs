using AutoHuoltoSovellus.Data;
using AutoHuoltoSovellus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoHuoltoSovellus.Controllers;

// Tässä lisätään ja haetaan autoja Rest API:n kautta

[ApiController]
[Route("api/[controller]")]
public class AutoController : ControllerBase
{
    private readonly HuoltoDbContext _context;

    public AutoController(HuoltoDbContext context)
    {
        _context = context;
    }

    [HttpPost] // Post pyyntö luo uuden auton
    public async Task<IActionResult> LuoAuto([FromBody] Auto auto)
    {
        if (auto == null)
        {
            return BadRequest("Auton tiedot ovat virheelliset.");
        }

        _context.Autot.Add(auto);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(HaeAuto), new { id = auto.AutoId }, auto);
    }

    [HttpGet("{id}")] // Get pyyntö hakee auton id:n perusteella
    public async Task<IActionResult> HaeAuto(int id)
    {
        var auto = await _context.Autot.FindAsync(id);
        if (auto == null)
        {
            return NotFound();
        }
        return Ok(auto);
    }

    [HttpGet] // Get pyyntö hakee kaikki autot
    public async Task<IActionResult> HaeKaikkiAutot()
    {
        var autot = await _context.Autot.ToListAsync();
        return Ok(autot);
    }

    [HttpPut("{id}")] // Put pyyntö päivittää auton tiedot
    public async Task<IActionResult> PaivitaAuto(int id, [FromBody] Auto paivitettyAuto)
    {
        if (id != paivitettyAuto.AutoId)
        {
            return BadRequest("Auton ID ei täsmää.");
        }

        var auto = await _context.Autot.FindAsync(id);
        if (auto == null)
        {
            return NotFound();
        }

        auto.Rekisterinumero = paivitettyAuto.Rekisterinumero;
        auto.KatsastusPvm = paivitettyAuto.KatsastusPvm;
        auto.ADRPvm = paivitettyAuto.ADRPvm;
        auto.PiirturiPvm = paivitettyAuto.PiirturiPvm;
        auto.AlkolukkoPvm = paivitettyAuto.AlkolukkoPvm;
        auto.NopeudenrajoitinPvm = paivitettyAuto.NopeudenrajoitinPvm;
        
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")] // Delete pyyntö poistaa auton
    public async Task<IActionResult> PoistaAuto(int id)
    {
        var auto = await _context.Autot.FindAsync(id);
        if (auto == null)
        {
            return NotFound();
        }

        _context.Autot.Remove(auto);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}