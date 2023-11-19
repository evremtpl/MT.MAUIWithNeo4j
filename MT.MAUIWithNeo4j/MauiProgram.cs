using Microsoft.Extensions.Logging;
using MT.MAUIWithNeo4j.UseCases.Interfaces;
using MT.MAUIWithNeo4j.UseCases.Concrete;
using MT.MAUIWithNeo4j.UseCases.PluginInterfaces;
using MT.MAUIWithNeo4j.Datastore;

using MT.MAUIWithNeo4j.Datastore.Redis;
using MT.MAUIWithNeo4j.Datastore.Mongo;
namespace MT.MAUIWithNeo4j
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Roboto-Regular.ttf", "Roboto");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            builder.Services.AddSingleton<IViewTaskUseCase, ViewTaskUseCase>();
            builder.Services.AddSingleton<IViewCategoryUseCase, ViewCategoryUseCase>();
            builder.Services.AddScoped<IAddTaskUseCase, AddTaskUseCase>();
            builder.Services.AddScoped<IAddCategoryUseCase, AddCategoryUseCase>();

            builder.Services.AddSingleton<ITaskRepository, TaskWebApiMongoRepository>();
            builder.Services.AddSingleton<ICategoryRepository, CategoryWebApiMongoRepository>();
            //builder.Services.AddSingleton<ITaskRepository, TaskWebApiRedisRepository>();
            //builder.Services.AddSingleton<ICategoryRepository, CategoryWebApiRedisRepository>();
            //builder.Services.AddSingleton<ITaskRepository, TaskWebApiNeo4jRepository>();
            //builder.Services.AddSingleton<ICategoryRepository, CategoryWebApiNeo4jRepository>();
           
            
            return builder.Build();
        }
    }
}
