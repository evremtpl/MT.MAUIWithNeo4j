using MT.MAUIWithNeo4j.Core;
using MT.MAUIWithNeo4j.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MT.MAUIWithNeo4j.Datastore.Redis;

public class TaskWebApiRedisRepository : ITaskRepository
{
    private HttpClient _client;
    private JsonSerializerOptions _serializerOptions;

    public TaskWebApiRedisRepository()
    {
        _client = new HttpClient();
        _serializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            WriteIndented = true
        };
    }
    public async Task AddTaskAsync(MyTask task)
    {
        

        Uri uri;

        uri = new Uri($"{Constants.WebApiBaseUrl}/TasksRedis");
        var postData= JsonSerializer.Serialize<MyTask>(task, _serializerOptions);
        StringContent content = new StringContent(postData, Encoding.UTF8, "application/json");


        var response = await _client.PostAsync(uri, content);
        if (response.IsSuccessStatusCode)
        {
            string result = await response.Content.ReadAsStringAsync();
            
        }

       
    }

    public  async Task DeleteTaskAsync(int taskId)
    {
        Uri uri;

        uri = new Uri($"{Constants.WebApiBaseUrl}/TasksRedis/{taskId}");
        


        var response = await _client.DeleteAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            string result = await response.Content.ReadAsStringAsync();
           
        }
    }

    public async Task<MyTask> GetTaskByIdAsync(int id)
    {
        var task = new MyTask();

        Uri uri;

        uri = new Uri($"{Constants.WebApiBaseUrl}/TasksRedis/{id}");



        var response = await _client.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            string result = await response.Content.ReadAsStringAsync();
            task = JsonSerializer.Deserialize<MyTask>(result, _serializerOptions);
        }

        return task;
    }

    public async  Task<List<MyTask>> GetTasksAsync()
    {
        var tasks = new List<MyTask>();

        Uri uri;

        uri = new Uri($"{Constants.WebApiBaseUrl}/TasksRedis");



        var response = await _client.GetAsync(uri);
        if (response.IsSuccessStatusCode)
        {
            if (response.StatusCode != System.Net.HttpStatusCode.NoContent)
            {
                string content = await response.Content.ReadAsStringAsync();
                tasks = JsonSerializer.Deserialize<List<MyTask>>(content, _serializerOptions);
            }
        }

        return tasks;
    }

    public async Task UpdateTaskAsync(int taskId, MyTask task)
    {
        Uri uri;

        uri = new Uri($"{Constants.WebApiBaseUrl}/TasksRedis/{taskId}");
        var putData = JsonSerializer.Serialize<MyTask>(task, _serializerOptions);
        StringContent content = new StringContent(putData, Encoding.UTF8, "application/json");


        var response = await _client.PutAsync(uri, content);
        if (response.IsSuccessStatusCode)
        {
            string result = await response.Content.ReadAsStringAsync();
            
        }
    }
}
