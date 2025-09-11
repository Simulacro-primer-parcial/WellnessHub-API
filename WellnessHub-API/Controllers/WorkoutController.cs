using Microsoft.AspNetCore.Mvc;
using WellnessHub.Models;
using System.Collections.Generic;
using System.Linq;

namespace PeopleAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WorkoutsController : ControllerBase
    {
        // "Base de datos" en memoria (se pierde al reiniciar)
        private static readonly List<Workout> _workouts = new();
        private static int _nextId = 1;

        // GET /api/workouts -> listar todo
        [HttpGet]
        public ActionResult<List<Workout>> GetAll()
        {
            return Ok(_workouts.OrderBy(w => w.Id).ToList());
        }

        // GET /api/workouts/{id} -> obtener por id
        [HttpGet("{id:int}")]
        public ActionResult<Workout> GetById(int id)
        {
            var workout = _workouts.FirstOrDefault(w => w.Id == id);
            if (workout == null) return NotFound(new { message = "No encontrado" });
            return Ok(workout);
        }

        // POST /api/workouts -> crear
        [HttpPost]
        public ActionResult<Workout> Create([FromBody] Workout data)
        {
            if (string.IsNullOrWhiteSpace(data.User))
                return BadRequest(new { message = "User es requerido." });

            if (string.IsNullOrWhiteSpace(data.Exercise))
                return BadRequest(new { message = "Exercise es requerido." });

            if (data.DurationMinutes <= 0)
                return BadRequest(new { message = "DurationMinutes debe ser mayor a 0." });

            var nuevo = new Workout
            {
                Id = _nextId++,
                User = data.User.Trim(),
                SessionDate = data.SessionDate == default ? DateTime.UtcNow : data.SessionDate,
                Exercise = data.Exercise.Trim(),
                DurationMinutes = data.DurationMinutes,
                IntensityCalories = data.IntensityCalories,
                CaloriesBurned = data.CaloriesBurned
            };

            _workouts.Add(nuevo);
            return CreatedAtAction(nameof(GetById), new { id = nuevo.Id }, nuevo);
        }

        // PUT /api/workouts/{id} -> actualizar
        [HttpPut("{id:int}")]
        public ActionResult<Workout> Update(int id, [FromBody] Workout data)
        {
            var workout = _workouts.FirstOrDefault(w => w.Id == id);
            if (workout == null) return NotFound(new { message = "No encontrado" });

            if (string.IsNullOrWhiteSpace(data.User))
                return BadRequest(new { message = "User es requerido." });

            if (string.IsNullOrWhiteSpace(data.Exercise))
                return BadRequest(new { message = "Exercise es requerido." });

            if (data.DurationMinutes <= 0)
                return BadRequest(new { message = "DurationMinutes debe ser mayor a 0." });

            workout.User = data.User.Trim();
            workout.SessionDate = data.SessionDate;
            workout.Exercise = data.Exercise.Trim();
            workout.DurationMinutes = data.DurationMinutes;
            workout.IntensityCalories = data.IntensityCalories;
            workout.CaloriesBurned = data.CaloriesBurned;

            return Ok(workout);
        }

        // DELETE /api/workouts/{id} -> eliminar
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var workout = _workouts.FirstOrDefault(w => w.Id == id);
            if (workout == null) return NotFound(new { message = "No encontrado" });

            _workouts.Remove(workout);
            return NoContent();
        }
    }
}
