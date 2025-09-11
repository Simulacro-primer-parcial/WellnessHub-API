using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WellnessHubAPI.Data;
using WellnessHubAPI.Models;

namespace WellnessHubAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class MealsController : ControllerBase
{
    private readonly AppDbContext _db;
    public MealsController(AppDbContext db) => _db = db;

    // POST api/meals
    [HttpPost]
    public async Task<ActionResult<Meal>> Create(Meal meal)
    {
        _db.Meals.Add(meal);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(GetById), new { id = meal.Id }, meal);
    }

    // GET api/meals/{id}
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Meal>> GetById(int id)
    {
        var m = await _db.Meals.FindAsync(id);
        return m is null ? NotFound() : Ok(m);
    }

    // GET api/meals?user=ana&from=2025-09-01&to=2025-09-10
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Meal>>> GetAll(
        [FromQuery] string? user,
        [FromQuery] DateTime? from,
        [FromQuery] DateTime? to)
    {
        var q = _db.Meals.AsQueryable();
        if (!string.IsNullOrWhiteSpace(user)) q = q.Where(x => x.User == user);
        if (from.HasValue) q = q.Where(x => x.Entry_Date >= from.Value.Date);
        if (to.HasValue)   q = q.Where(x => x.Entry_Date <= to.Value.Date);

        var list = await q.OrderBy(x => x.Entry_Date).ThenBy(x => x.Id).ToListAsync();
        return Ok(list);
    }

    // PUT api/meals/{id}
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, Meal dto)
    {
        if (id != dto.Id) return BadRequest("Path id != body id");

        var exists = await _db.Meals.AnyAsync(x => x.Id == id);
        if (!exists) return NotFound();

        _db.Entry(dto).State = EntityState.Modified;
        await _db.SaveChangesAsync();
        return NoContent();
    }

    // DELETE api/meals/{id}
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var m = await _db.Meals.FindAsync(id);
        if (m is null) return NotFound();

        _db.Meals.Remove(m);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}
