using MT.MAUIWithNeo4j.UseCases.PluginInterfaces;
using System.Text.Json;
using MT.MAUIWithNeo4j.Core;
using System.Text;


namespace MT.MAUIWithNeo4j.Datastore.Neo4j
{
    public class CategoryWebApiNeo4jRepository : ICategoryRepository
    {
        private HttpClient _client;
        private JsonSerializerOptions _serializerOptions;

        public CategoryWebApiNeo4jRepository()
        {
            _client = new HttpClient();
            _serializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        public async Task AddCategoryAsync(Category category)
        {

            Uri uri;

            uri = new Uri($"{Constants.WebApiBaseUrl}/CategoriesNeo4j");
            var postData = JsonSerializer.Serialize(category, _serializerOptions);
            StringContent content = new StringContent(postData, Encoding.UTF8, "application/json");


            var response = await _client.PostAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();

            }
        }

        public async Task AssignTask(int categoryId, int taskId)
        {

            Uri uri;

            uri = new Uri($"{Constants.WebApiBaseUrl}/CategoriesNeo4j/{categoryId}/{taskId}");



            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();

            }

        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            Uri uri;

            uri = new Uri($"{Constants.WebApiBaseUrl}/CategoriesNeo4j/{categoryId}");



            var response = await _client.DeleteAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();

            }
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            var categories = new List<Category>();

            Uri uri;

            uri = new Uri($"{Constants.WebApiBaseUrl}/CategoriesNeo4j");



            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                categories = JsonSerializer.Deserialize<List<Category>>(content, _serializerOptions);
            }

            return categories;
        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            var category = new Category();

            Uri uri;

            uri = new Uri($"{Constants.WebApiBaseUrl}/CategoriesNeo4j/{categoryId}");



            var response = await _client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();
                category = JsonSerializer.Deserialize<Category>(result, _serializerOptions);
            }

            return category;
        }



        public async Task UpdateCategoryAsync(int categoryId, Category category)
        {
            Uri uri;

            uri = new Uri($"{Constants.WebApiBaseUrl}/CategoriesNeo4j/{categoryId}");
            var putData = JsonSerializer.Serialize(category, _serializerOptions);
            StringContent content = new StringContent(putData, Encoding.UTF8, "application/json");


            var response = await _client.PutAsync(uri, content);
            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();

            }
        }
    }
}
