using MT.MAUIWithNeo4j.Core;

namespace MT.MAUIWithNeo4j.UseCases.Interfaces
{
    public interface IAddTaskUseCase
    {
       public Task ExecuteAsync(MyTask task);

        public Task UpdateAsync(int taskId,MyTask task);

    }
}
