using MT.MAUIWithNeo4j.MVVM.ViewModels;
using MT.MAUIWithNeo4j.UseCases.Interfaces;
namespace MT.MAUIWithNeo4j.MVVM.Views;

public partial class MainView : ContentPage
{

    private readonly IViewTaskUseCase _viewTaskUseCase;
    private readonly IViewCategoryUseCase _viewCategoryUseCase;
    private readonly IAddTaskUseCase _viewAddTaskUseCase;
    private readonly IAddCategoryUseCase _addCategoryUseCase;
    private MainViewModel mainViewModel;
	public MainView(IViewTaskUseCase viewTaskUseCase, IViewCategoryUseCase viewCategoryUseCase, IAddTaskUseCase viewAddTaskUseCase, IAddCategoryUseCase addCategoryUseCas)
	{
        _viewTaskUseCase= viewTaskUseCase;
        _viewCategoryUseCase= viewCategoryUseCase;
        _viewAddTaskUseCase= viewAddTaskUseCase;
        _addCategoryUseCase= addCategoryUseCas;
        mainViewModel = new MainViewModel(_viewTaskUseCase, _viewCategoryUseCase);
        InitializeComponent();

		BindingContext = mainViewModel;

    }

    private void checkBox_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
	mainViewModel.UpdateData();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var taskView = new NewTaskView(_viewAddTaskUseCase,_viewTaskUseCase,_viewCategoryUseCase,_addCategoryUseCase)
        {
            BindingContext = new NewTaskViewModel
            {
                Tasks = mainViewModel.Tasks,
                Categories = mainViewModel.Categories,
            }
        };

        Navigation.PushAsync(taskView);
        //Shell.Current.GoToAsync(nameof(taskView));
    }
}