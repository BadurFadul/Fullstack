using backend.Entities;
using Microsoft.AspNetCore.Mvc;

namespace backend.Repositories
{
    public interface ICategoryRepo
    {
        Task<ActionResult<IEnumerable<Category>>> GetCategoriesAsync();
        Task<ActionResult<Category>> GetCategory(Guid id);
        Task<ActionResult<Category>> PostCategory(Category Category);
        Task<ActionResult<Category>> PutCategory(Guid id, Category Category);
        Task<IActionResult> DeleteCategory(Guid id);
    }
}