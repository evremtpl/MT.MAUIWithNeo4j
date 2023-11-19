using MT.MAUIWithNeo4j.MVVM.Views;
using MT.MAUIWithNeo4j.UseCases.Interfaces;
namespace MT.MAUIWithNeo4j
{
    public partial class App : Application
    {
        private readonly IViewTaskUseCase _viewTaskUseCase;
        private readonly IViewCategoryUseCase _viewCategoryUseCase;
        private readonly IAddTaskUseCase _viewAddTaskUseCase;
        private readonly IAddCategoryUseCase _addCategoryUseCase;
        public App(IViewTaskUseCase viewTaskUseCase, IViewCategoryUseCase viewCategoryUseCase, IAddTaskUseCase viewAddTaskUseCase, IAddCategoryUseCase addCategoryUseCase)
        {
            InitializeComponent();
            _viewTaskUseCase = viewTaskUseCase;
            _viewCategoryUseCase= viewCategoryUseCase;
            _viewAddTaskUseCase= viewAddTaskUseCase;
            _addCategoryUseCase= addCategoryUseCase;
            MainPage = new NavigationPage (new MainView(_viewTaskUseCase, _viewCategoryUseCase,_viewAddTaskUseCase,_addCategoryUseCase));
           
        }
    }
}
