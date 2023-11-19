using Microsoft.Extensions.Logging;
using MT.MAUIWithNeo4j.UseCases.Interfaces;
using MT.MAUIWithNeo4j.UseCases.Concrete;
using MT.MAUIWithNeo4j.UseCases.PluginInterfaces;
using MT.MAUIWithNeo4j.Datastore;
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
            builder.Services.AddSingleton<ITaskRepository, TaskWebApiRepository>(); 
            builder.Services.AddSingleton<ICategoryRepository, CategoryWebApiRepository>();

            builder.Services.AddScoped<IAddTaskUseCase, AddTaskUseCase>();
            builder.Services.AddScoped<IAddCategoryUseCase, AddCategoryUseCase>();
            
            return builder.Build();
        }
    }
}
