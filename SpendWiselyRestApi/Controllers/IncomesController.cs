using Entities.DatabaseContexts;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Dtos;
using SpendWiselyRestApi.Extensions;

namespace SpendWiselyRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class IncomesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public IncomesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Incomes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IncomeDto>>> GetIncomes()
        {
            var userId = this.GetLoggedUserId();
            return await _context.Incomes
                .Where(i => i.IsActive && i.Account.UserId == userId)
                .Select(i => new IncomeDto
                {
                    Id = i.Id,
                    AccountId = i.AccountId,
                    Amount = i.Amount,
                    Description = i.Description,
                    Name = i.Name
                }).ToListAsync();
        }

        // GET: api/Incomes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Income>> GetIncome(int id)
        {
            var income = await _context.Incomes.FindAsync(id);

            if (income == null)
            {
                return NotFound();
            }

            return income;
        }

        // PUT: api/Incomes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIncome(int id, IncomeDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            var existingIncome = await _context.Incomes.FindAsync(id);
            if (existingIncome == null)
            {
                return NotFound();
            }

            existingIncome.Name = dto.Name;
            existingIncome.Amount = dto.Amount;
            existingIncome.Description = dto.Description;
            existingIncome.AccountId = dto.AccountId;
            existingIncome.DateEdited = DateTime.Now;

            _context.Entry(existingIncome).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IncomeExists(id))
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

        // POST: api/Incomes
        [HttpPost]
        public async Task<ActionResult<Income>> PostIncome(IncomeDto dto)
        {
            var userId = this.GetLoggedUserId();
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == dto.AccountId && a.UserId == userId);

            if (account == null)
            {
                return BadRequest("Invalid account for current user.");
            }

            var income = new Income
            {
                AccountId = dto.AccountId,
                Amount = dto.Amount,
                Description = dto.Description,
                Name = dto.Name,
                IsActive = true,
                DateCreated = DateTime.Now,
            };

            _context.Incomes.Add(income);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIncome", new { id = income.Id }, income);
        }

        // DELETE: api/Incomes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIncome(int id)
        {
            var income = await _context.Incomes.FindAsync(id);
            if (income == null)
            {
                return NotFound();
            }

            _context.Incomes.Remove(income);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IncomeExists(int id)
        {
            return _context.Incomes.Any(e => e.Id == id);
        }
    }
}
