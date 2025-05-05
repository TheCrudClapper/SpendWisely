using Entities.DatabaseContexts;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Dtos;
using SpendWiselyRestApi.Extensions;
using System.Security.Claims;

namespace SpendWiselyRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ExpensesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public ExpensesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Expenses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExpenseDto>>> GetExpenses()
        {
            var userId = this.GetLoggedUserId();
            return await _context.Expenses
                .Where(e => e.IsActive && e.Account.UserId == userId)
                .Select(e => new ExpenseDto()
                {
                    Id = e.Id,
                    AccountId = e.AccountId,
                    CategoryId = e.CategoryId,
                    Amount = e.Amount,
                    Description = e.Description,
                    Name = e.Name
                }).ToListAsync();
        }

        // GET: api/Expenses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Expense>> GetExpense(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);

            if (expense == null)
            {
                return NotFound();
            }

            return expense;
        }

        // PUT: api/Expenses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpense(int id, ExpenseDto dto)
        {
            if (id != dto.Id)
            {
                return BadRequest();
            }

            var existingExpense = await _context.Expenses.FindAsync(id);
            if (existingExpense == null)
            {
                return NotFound();
            }

            existingExpense.Name = dto.Name;
            existingExpense.Amount = dto.Amount;
            existingExpense.Description = dto.Description;
            existingExpense.AccountId = dto.AccountId;
            existingExpense.CategoryId = dto.CategoryId;
            existingExpense.DateEdited = DateTime.Now;

            _context.Entry(existingExpense).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseExists(id))
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

        // POST: api/Expenses
        [HttpPost]
        public async Task<ActionResult<Expense>> PostExpense(ExpenseDto dto)
        {
            var userId = this.GetLoggedUserId();
            var account = await _context.Accounts.FirstOrDefaultAsync(a => a.Id == dto.AccountId && a.UserId == userId);

            if (account == null)
            {
                return BadRequest("Invalid account for current user.");
            }

            var expense = new Expense()
            {
                AccountId = dto.AccountId,
                CategoryId = dto.CategoryId,
                Amount = dto.Amount,
                Description = dto.Description,
                Name = dto.Name,
                IsActive = true,
                DateCreated = DateTime.Now,
            };

            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExpense", new { id = expense.Id }, expense);
        }

        // DELETE: api/Expenses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(int id)
        {
            var expense = await _context.Expenses.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }

            _context.Expenses.Remove(expense);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExpenseExists(int id)
        {
            return _context.Expenses.Any(e => e.Id == id);
        }
    }
}
