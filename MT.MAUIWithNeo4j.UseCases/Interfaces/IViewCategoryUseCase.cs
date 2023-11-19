using MT.MAUIWithNeo4j.Core;

namespace MT.MAUIWithNeo4j.UseCases.Interfaces
{
    public interface IViewCategoryUseCase
    {
        public Task<List<Category>> GetCategoriesAsync();

        public Task<Category> GetCategoriesByIdAsync(int id);

        public Task AssignTask(int categoryId, int taskId);
    }
}
