using MT.MAUIWithNeo4j.Core;

namespace MT.MAUIWithNeo4j.UseCases.PluginInterfaces
{
    public interface ICategoryRepository
    {
       
            Task<List<Category>> GetCategoriesAsync();
            Task<Category> GetCategoryByIdAsync(int categoryId);
            Task UpdateCategoryAsync(int categoryId, Category category);
            Task AddCategoryAsync(Category category);
            Task DeleteCategoryAsync(int categoryId);
            Task AssignTask(int categoryId, int taskId);

    }
}
