using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Services.Models;
using Services.Models.DatabaseContexts;
using SpendWiselyRestApi.Dto;

namespace SpendWiselyRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public AccountsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Accounts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            return await _context.Accounts.ToListAsync();
        }

        // GET: api/Accounts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Account>> GetAccount(int id)
        {
            var account = await _context.Accounts.FindAsync(id);

            if (account == null)
            {
                return NotFound();
            }
            
            return account;
        }

        // PUT: api/Accounts/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAccount(int id, AccountDto accountDto)
        {

            if (id != accountDto.Id)
            {
                return BadRequest();
            }

            var existingAccount = await _context.Accounts.FindAsync(id);
            if (existingAccount == null)
                return NotFound();

            existingAccount.Name = accountDto.Name;
            existingAccount.Balance = accountDto.Balance;
            existingAccount.Description = accountDto.Description;
            existingAccount.EmojiUrl = accountDto.EmojiUrl;
            existingAccount.DateEdited = DateTime.Now;

            _context.Entry(existingAccount).State = EntityState.Modified; ;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AccountExists(id))
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

        // POST: api/Accounts
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AccountDto>> PostAccount(AccountDto accountDto)
        {
            Account account = new Account()
            {
                Balance = accountDto.Balance,
                DateCreated = DateTime.Now,
                Description = accountDto.Description,
                EmojiUrl = accountDto.EmojiUrl,
                IsActive = true,
                Name = accountDto.Name,
                UserId = accountDto.UserId,
            };

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAccount", new { id = account.Id }, account);
        }

        // DELETE: api/Accounts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            var account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            _context.Accounts.Remove(account);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AccountExists(int id)
        {
            return _context.Accounts.Any(e => e.Id == id);
        }
    }
}
