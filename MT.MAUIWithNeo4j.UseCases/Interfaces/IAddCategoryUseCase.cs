using MT.MAUIWithNeo4j.Core;

namespace MT.MAUIWithNeo4j.UseCases.Interfaces
{
    public interface IAddCategoryUseCase
    {
        public Task ExecuteAsync(Category category);
    }
}
