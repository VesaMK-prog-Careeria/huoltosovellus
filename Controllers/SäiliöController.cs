using AutoHuoltoSovellus.Data;
using AutoHuoltoSovellus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoHuoltoSovellus.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SäiliöController : ControllerBase
{
    private readonly HuoltoDbContext _context;

    public SäiliöController(HuoltoDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> HaeKaikki()
    {
        return Ok(await _context.Säiliöt.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Lisaa([FromBody] Säiliö säiliö)
    {
        _context.Säiliöt.Add(säiliö);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Hae), new { id = säiliö.SäiliöId }, säiliö);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Hae(int id)
    {
        var säiliö = await _context.Säiliöt.FindAsync(id);
        if (säiliö == null) return NotFound();
        return Ok(säiliö);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Paivita(int id, [FromBody] Säiliö säiliö)
    {
        if (id != säiliö.SäiliöId) return BadRequest();
        _context.Entry(säiliö).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Poista(int id)
    {
        var säiliö = await _context.Säiliöt.FindAsync(id);
        if (säiliö == null) return NotFound();
        _context.Säiliöt.Remove(säiliö);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
