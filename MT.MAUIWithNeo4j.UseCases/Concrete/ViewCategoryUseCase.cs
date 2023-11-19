
using MT.MAUIWithNeo4j.UseCases.Interfaces;
using MT.MAUIWithNeo4j.Core;
using MT.MAUIWithNeo4j.UseCases.PluginInterfaces;

namespace MT.MAUIWithNeo4j.UseCases.Concrete
{
    public class ViewCategoryUseCase : IViewCategoryUseCase
    {
        private readonly ICategoryRepository _categoryRepository;
        

        public ViewCategoryUseCase(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
            
        }

        public async Task AssignTask(int categoryId, int taskId)
        {
           await this._categoryRepository.AssignTask(categoryId, taskId);
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await this._categoryRepository.GetCategoriesAsync();
        }

        public async Task<Category> GetCategoriesByIdAsync(int id)
        {
            return await this.GetCategoriesByIdAsync(id);
        }
    }
}
