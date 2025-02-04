using AutoHuoltoSovellus.Data;
using AutoHuoltoSovellus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutoHuoltoSovellus.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PerävaunuController : ControllerBase
{
    private readonly HuoltoDbContext _context;

    public PerävaunuController(HuoltoDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> HaeKaikki()
    {
        return Ok(await _context.Perävaunut.ToListAsync());
    }

    [HttpPost]
    public async Task<IActionResult> Lisaa([FromBody] Perävaunu perävaunu)
    {
        _context.Perävaunut.Add(perävaunu);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(Hae), new { id = perävaunu.PerävaunuId }, perävaunu);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Hae(int id)
    {
        var perävaunu = await _context.Perävaunut.FindAsync(id);
        if (perävaunu == null) return NotFound();
        return Ok(perävaunu);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Paivita(int id, [FromBody] Perävaunu perävaunu)
    {
        if (id != perävaunu.PerävaunuId) return BadRequest();
        _context.Entry(perävaunu).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Poista(int id)
    {
        var perävaunu = await _context.Perävaunut.FindAsync(id);
        if (perävaunu == null) return NotFound();
        _context.Perävaunut.Remove(perävaunu);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
