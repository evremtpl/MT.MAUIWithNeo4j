using MT.MAUIWithNeo4j.MVVM.Views;
using MT.MAUIWithNeo4j.UseCases.Interfaces;
namespace MT.MAUIWithNeo4j
{
    public partial class App : Application
    {
        private readonly IViewTaskUseCase _viewTaskUseCase;
        private readonly IViewCategoryUseCase _viewCategoryUseCase;
        private readonly IAddTaskUseCase _addTaskUseCase;
        private readonly IAddCategoryUseCase _addCategoryUseCase;
        public App(IViewTaskUseCase viewTaskUseCase, IViewCategoryUseCase viewCategoryUseCase, IAddTaskUseCase addTaskUseCase, IAddCategoryUseCase addCategoryUseCase)
        {
            InitializeComponent();
            _viewTaskUseCase = viewTaskUseCase;
            _viewCategoryUseCase= viewCategoryUseCase;
            _addTaskUseCase = addTaskUseCase;
            _addCategoryUseCase= addCategoryUseCase;
            MainPage = new NavigationPage (new MainView(_viewTaskUseCase, _viewCategoryUseCase, _addTaskUseCase, _addCategoryUseCase));
           
        }
    }
}
