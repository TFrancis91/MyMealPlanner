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
    public class MealPlanController : ControllerBase
    {
        private readonly MealPlannerContext _context;

        public MealPlanController(MealPlannerContext context)
        {
            _context = context;
        }

        // GET: api/MealPlan
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MealPlan>>> GetMealPlan()
        {
            return await _context.MealPlan.ToListAsync();
        }

        // GET: api/MealPlan/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MealPlan>> GetMealPlan(long id)
        {
            var mealPlan = await _context.MealPlan.FindAsync(id);

            if (mealPlan == null)
            {
                return NotFound();
            }

            return mealPlan;
        }

        // PUT: api/MealPlan/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMealPlan(long id, MealPlan mealPlan)
        {
            if (id != mealPlan.MealId)
            {
                return BadRequest();
            }

            _context.Entry(mealPlan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealPlanExists(id))
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

        // POST: api/MealPlan
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MealPlan>> PostMealPlan(MealPlan mealPlan)
        {
            _context.MealPlan.Add(mealPlan);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (MealPlanExists(mealPlan.MealId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMealPlan", new { id = mealPlan.MealId }, mealPlan);
        }

        // DELETE: api/MealPlan/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MealPlan>> DeleteMealPlan(long id)
        {
            var mealPlan = await _context.MealPlan.FindAsync(id);
            if (mealPlan == null)
            {
                return NotFound();
            }

            _context.MealPlan.Remove(mealPlan);
            await _context.SaveChangesAsync();

            return mealPlan;
        }

        private bool MealPlanExists(long id)
        {
            return _context.MealPlan.Any(e => e.MealId == id);
        }
    }
}
