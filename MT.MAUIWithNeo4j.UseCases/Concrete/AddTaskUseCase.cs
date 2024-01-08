using MT.MAUIWithNeo4j.UseCases.Interfaces;
using MT.MAUIWithNeo4j.Core;
using MT.MAUIWithNeo4j.UseCases.PluginInterfaces;

namespace MT.MAUIWithNeo4j.UseCases.Concrete
{
    public class AddTaskUseCase : IAddTaskUseCase
    {
        private readonly ITaskRepository _taskRepository;

        public AddTaskUseCase(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }


        public async Task ExecuteAsync(MyTask task)
        {
            await this._taskRepository.AddTaskAsync(task);


        }

        public async Task UpdateAsync(int taskId,MyTask task)
        {
            await this._taskRepository.UpdateTaskAsync(taskId,task);
        }
    }
}
