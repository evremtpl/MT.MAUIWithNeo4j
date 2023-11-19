using MT.MAUIWithNeo4j.Core;
using MT.MAUIWithNeo4j.UseCases.Interfaces;
using MT.MAUIWithNeo4j.UseCases.PluginInterfaces;


namespace MT.MAUIWithNeo4j.UseCases.Concrete
{
    public class ViewTaskUseCase : IViewTaskUseCase
    {
        private readonly ITaskRepository _taskRepository;

        public ViewTaskUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository; 
        }

        public async Task<MyTask> GetTaskByIdAsync(int id)
        {
            return await this._taskRepository.GetTaskByIdAsync(id);
        }

        public async Task<List<MyTask>> GetTasksAsync()
        {
            return await this._taskRepository.GetTasksAsync();
        }
    }
}
