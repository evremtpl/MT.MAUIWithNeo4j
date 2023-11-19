using MT.MAUIWithNeo4j.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MT.MAUIWithNeo4j.UseCases.Interfaces
{
    public interface IViewTaskUseCase
    {
       public Task<List<MyTask>> GetTasksAsync();
       public Task<MyTask> GetTaskByIdAsync(int id);
    }
}
