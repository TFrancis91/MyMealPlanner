using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyMealPlanner.Models;

namespace MyMealPlanner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealRepoController : ControllerBase
    {
        private readonly MealPlannerContext _context;

        public MealRepoController(MealPlannerContext context)
        {
            _context = context;
        }

        // GET: api/MealPlanner
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Meal>>> GetMealList()
        {
            return await _context.MealList.ToListAsync();
        }

        // GET: api/MealPlanner/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Meal>> GetMeal(long id)
        {
            var meal = await _context.MealList.FindAsync(id);

            if (meal == null)
            {
                return NotFound();
            }

            return meal;
        }

        // PUT: api/MealPlanner/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeal(long id, Meal meal)
        {
            if (id != meal.Id)
            {
                return BadRequest();
            }

            _context.Entry(meal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealExists(id))
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

        // POST: api/MealPlanner
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Meal>> PostMeal(Meal meal)
        {
            _context.MealList.Add(meal);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetMeal), new { id = meal.Id }, meal);
        }

        // DELETE: api/MealPlanner/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Meal>> DeleteMeal(long id)
        {
            var meal = await _context.MealList.FindAsync(id);
            if (meal == null)
            {
                return NotFound();
            }

            _context.MealList.Remove(meal);
            await _context.SaveChangesAsync();

            return meal;
        }

        private bool MealExists(long id)
        {
            return _context.MealList.Any(e => e.Id == id);
        }
    }
}
