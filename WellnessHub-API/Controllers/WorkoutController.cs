using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WellnessHub.Data;
using WellnessHub.Models;

namespace PeopleAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WorkoutsController : ControllerBase
{
    private readonly AppDbContext _context;

    public WorkoutsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/workouts
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Workout>>> GetWorkouts()
    {
        return await _context.Workouts
            .AsNoTracking()
            .OrderBy(w => w.Id)
            .ToListAsync();
    }

    // GET: api/workouts/5
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Workout>> GetWorkout(int id)
    {
        var workout = await _context.Workouts.FindAsync(id);
        if (workout == null) return NotFound();
        return workout;
    }

    // POST: api/workouts
    [HttpPost]
    public async Task<ActionResult<Workout>> PostWorkout(Workout workout)
    {
        _context.Workouts.Add(workout);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetWorkout), new { id = workout.Id }, workout);
    }

    // PUT: api/workouts/5
    [HttpPut("{id:int}")]
    public async Task<IActionResult> PutWorkout(int id, Workout workout)
    {
        if (id != workout.Id) return BadRequest();

        _context.Entry(workout).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!WorkoutExists(id)) return NotFound();
            throw;
        }

        return NoContent();
    }

    // DELETE: api/workouts/5
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteWorkout(int id)
    {
        var workout = await _context.Workouts.FindAsync(id);
        if (workout == null) return NotFound();

        _context.Workouts.Remove(workout);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool WorkoutExists(int id)
    {
        return _context.Workouts.Any(e => e.Id == id);
    }
}
