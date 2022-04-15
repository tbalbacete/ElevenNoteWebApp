using ElevenNoteWebApp.Server.Data;
using ElevenNoteWebApp.Server.Models;
using ElevenNoteWebApp.Shared.Models.Category;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElevenNoteWebApp.Server.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext _context;

        public CategoryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateCategoryAsync(CategoryCreate model)
        {
            if (model == null) return false;

            var categoryEntity = new CategoryEntity
            {
                Name = model.Name
            };

            _context.Categories.Add(categoryEntity);
            return await _context.SaveChangesAsync() == 1;
        }
        public async Task<IEnumerable<CategoryListItem>> GetAllCategoriesAsync()
        {
            var categoryQuery = _context.Categories.Select(entity => new CategoryListItem
            {
                Id = entity.Id,
                Name = entity.Name
            });

            return await categoryQuery.ToListAsync();
        }

        public async Task<CategoryDetail> GetCategoryByIdAsync(int categoryId)
        {
            var categoryEntity = await _context.Categories.FirstOrDefaultAsync(n => n.Id == categoryId);

            if (categoryEntity is null) return null;

            var detail = new CategoryDetail
            {
                Id = categoryEntity.Id,
                Name = categoryEntity.Name
            };

            return detail;
        }
        public async Task<bool> UpdateCategoryAsync(CategoryEdit model)
        {
            if (model == null) return false;

            var categoryEntity = await _context.Categories.FindAsync(model.Id);

            categoryEntity.Name = model.Name;

            return await _context.SaveChangesAsync() == 1;
        }

        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            var categoryEntity = await _context.Categories.FindAsync(categoryId);
            _context.Categories.Remove(categoryEntity);
            return await _context.SaveChangesAsync() == 1;
        }


    }
}
