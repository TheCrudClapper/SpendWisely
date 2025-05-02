using Entities.DatabaseContexts;
using Entities.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;
using Services.Dtos;
using SpendWiselyRestApi.Extensions;

namespace SpendWiselyRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public CategoriesController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Categories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDto>>> GetCategories()
        {
            var userId = this.GetLoggedUserId();
            return await _context.UserCategories
                .Include(item => item.User)
                .Include(item => item.Category)
                .Where(item => item.IsActive && item.UserId == userId && item.Category.IsActive)
                .Select(item => new CategoryDto()
                {
                    Description = item.Category.Description,
                    EmojiUrl = item.Category.EmojiUrl,
                    Id = item.Category.Id,
                    Name = item.Category.Name,
                })
                .ToListAsync();
        }

        // GET: api/Categories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDto>> GetCategory(int id)
        {
            var category = await _context.Categories
                .Where(item => item.IsActive && item.Id == id)
                .Select(item => new CategoryDto()
                {
                    Description = item.Description,
                    EmojiUrl = item.EmojiUrl,
                    Id = item.Id,
                    Name = item.Name,
                }).FirstAsync();


            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        // PUT: api/Categories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategory(int id, CategoryDto category)
        {
            if (id != category.Id)
            {
                return BadRequest();
            }

            var categoryFromDb = await _context.Categories
                .Where(item => item.Id == id)
                .FirstAsync();

            if (categoryFromDb is null)
                return NotFound("Failed to update item");

            categoryFromDb.DateEdited = DateTime.Now;
            categoryFromDb.EmojiUrl = category.EmojiUrl;
            categoryFromDb.Description = category.Description;
            categoryFromDb.Name = category.Name;

            _context.Update(categoryFromDb);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // POST: api/Categories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostCategory(CategoryDto categoryDto)
        {
            var userId = this.GetLoggedUserId();

            var category = new Category()
            {
                DateCreated = DateTime.Now,
                IsActive = true,
                Name = categoryDto.Name,
                Description = categoryDto.Description,
                EmojiUrl = categoryDto.EmojiUrl,
                IsPredifined = false,
            };

            var userCategory = new UserCategory()
            {
                DateCreated = DateTime.Now,
                IsActive = true,
                UserId = userId,
                Category = category,
            };

            await _context.Categories.AddAsync(category);
            await _context.UserCategories.AddAsync(userCategory);

            await _context.SaveChangesAsync();


            return Ok();
        }

        // DELETE: api/Categories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Categories
                .Where(item => item.IsActive && item.Id == id)
                .FirstOrDefaultAsync();

            if (category is null)
                return NotFound("Category to delete not found");

            category.IsActive = false;
            category.DateDeleted = DateTime.Now;

            await _context.SaveChangesAsync();
            return Ok();
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
