using MT.MAUIWithNeo4j.Core;

namespace MT.MAUIWithNeo4j.UseCases.PluginInterfaces
{
    public interface ITaskRepository
    {
        Task<List<MyTask>> GetTasksAsync();
        Task<MyTask> GetTaskByIdAsync(int id);
        Task UpdateTaskAsync(int taskId, MyTask task);
        Task AddTaskAsync(MyTask task);
        Task DeleteTaskAsync(int taskId);
    }
}
