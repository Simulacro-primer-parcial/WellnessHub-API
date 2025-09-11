using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WellnessHub_API.Data;  
using WellnessHub_API.Models; 

namespace WellnessHub_API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HabitsController : ControllerBase
{
    private readonly AppDbContext _context;

    public HabitsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/habits
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Habit>>> GetHabits()
    {
        return await _context.Habits.AsNoTracking().ToListAsync();
    }

    // GET: api/habits/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Habit>> GetHabit(int id)
    {
        var habit = await _context.Habits.FindAsync(id);

        if (habit == null)
        {
            return NotFound();
        }

        return habit;
    }

    // POST: api/habits
    [HttpPost]
    public async Task<ActionResult<Habit>> PostHabit(Habit habit)
    {
        _context.Habits.Add(habit);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetHabit), new { id = habit.Id }, habit);
    }

    // PUT: api/habits/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutHabit(int id, Habit habit)
    {
        if (id != habit.Id)
        {
            return BadRequest();
        }

        _context.Entry(habit).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!HabitExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // DELETE: api/habits/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteHabit(int id)
    {
        var habit = await _context.Habits.FindAsync(id);
        if (habit == null)
        {
            return NotFound();
        }

        _context.Habits.Remove(habit);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool HabitExists(int id)
    {
        return _context.Habits.Any(e => e.Id == id);
    }
}