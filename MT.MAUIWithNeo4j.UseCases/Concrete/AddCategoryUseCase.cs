using MT.MAUIWithNeo4j.UseCases.Interfaces;
using MT.MAUIWithNeo4j.Core;
using MT.MAUIWithNeo4j.UseCases.PluginInterfaces;
namespace MT.MAUIWithNeo4j.UseCases.Concrete
{
    public class AddCategoryUseCase : IAddCategoryUseCase
    {

        private readonly ICategoryRepository _categoryRepository;

        public AddCategoryUseCase(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task ExecuteAsync(Category category)
        {
            await _categoryRepository.AddCategoryAsync(category);
        }
    }
}
