using ElevenNoteWebApp.Shared.Models.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElevenNoteWebApp.Server.Services.Category
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryListItem>> GetAllCategoriesAsync();
        Task<bool> CreateCategoryAsync(CategoryCreate model);
        Task<CategoryDetail> GetCategoryByIdAsync(int categoryId);
        Task<bool> UpdateCategoryAsync(CategoryEdit model);
        Task<bool> DeleteCategoryAsync(int categoryId);
    }
}
