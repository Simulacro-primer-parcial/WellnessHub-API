using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WellnessHub_API.Models;

namespace WellnessHub_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoodEntriesController : ControllerBase
    {
        private readonly WellnessHubContext _context;

        public MoodEntriesController(WellnessHubContext context)
        {
            _context = context;
        }

        // GET: api/MoodEntries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MoodEntry>>> GetMoodEntries()
        {
            return await _context.MoodEntries.ToListAsync();
        }

        // GET: api/MoodEntries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MoodEntry>> GetMoodEntry(int id)
        {
            var entry = await _context.MoodEntries.FindAsync(id);

            if (entry == null)
                return NotFound();

            return entry;
        }

        // POST: api/MoodEntries
        [HttpPost]
        public async Task<ActionResult<MoodEntry>> PostMoodEntry(MoodEntry moodEntry)
        {
            _context.MoodEntries.Add(moodEntry);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMoodEntry), new { id = moodEntry.Id }, moodEntry);
        }

        // PUT: api/MoodEntries/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoodEntry(int id, MoodEntry moodEntry)
        {
            if (id != moodEntry.Id)
                return BadRequest();

            _context.Entry(moodEntry).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/MoodEntries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMoodEntry(int id)
        {
            var moodEntry = await _context.MoodEntries.FindAsync(id);
            if (moodEntry == null)
                return NotFound();

            _context.MoodEntries.Remove(moodEntry);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
