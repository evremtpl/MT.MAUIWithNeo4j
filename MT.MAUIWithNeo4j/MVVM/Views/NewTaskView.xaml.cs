using MT.MAUIWithNeo4j.Core;
using MT.MAUIWithNeo4j.MVVM.ViewModels;
using MT.MAUIWithNeo4j.UseCases.Interfaces;
using System.Threading.Tasks;
namespace MT.MAUIWithNeo4j.MVVM.Views;

public partial class NewTaskView : ContentPage
{

    private readonly IAddTaskUseCase _viewAddTaskUseCase;
    private readonly IViewTaskUseCase _viewTaskUseCase;
    private readonly IViewCategoryUseCase _viewCategoryUseCase;
    private readonly IAddCategoryUseCase _addCategoryUseCase;
    public NewTaskView(IAddTaskUseCase viewAddTaskUseCase, IViewTaskUseCase viewTaskUseCase, IViewCategoryUseCase viewCategoryUseCase, IAddCategoryUseCase addCategoryUseCase)
	{
        _viewAddTaskUseCase = viewAddTaskUseCase;
        _addCategoryUseCase = addCategoryUseCase;
        _viewCategoryUseCase = viewCategoryUseCase;
        _viewTaskUseCase = viewTaskUseCase;
        InitializeComponent();
	}

    private async void AddTaskClicked(object sender, EventArgs e)
    {
        var vm = BindingContext as NewTaskViewModel;

        var selectedCategory =
             vm.Categories.Where(x => x.IsSelected == true).FirstOrDefault();

        if (selectedCategory != null)
        {
            if(vm.Task!=null)
            {
                var task = new MyTask
                {
                    TaskName = vm.Task,
                    CategoryId = selectedCategory.Id,
                    Completed = false
                };
                vm.Tasks.Add(task);
                var tasks = await _viewTaskUseCase.GetTasksAsync();

                var taskId = tasks.Count()==0? 1: tasks.Max(x => x.Id) + 1;
                task.Id = taskId;
                await _viewAddTaskUseCase.ExecuteAsync(task);

                await _viewCategoryUseCase.AssignTask(selectedCategory.Id, taskId);
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert("Invalid Selection", "You must enter a task name", "Ok");
            }
        }
        else if(!vm.Categories.Any())
        {
            await DisplayAlert("Invalid Selection", "There is no category, please firstly add category", "Ok");
        }
        else
        {
            await DisplayAlert("Invalid Selection", "You must select a category", "Ok");
        }
    }

    private async void AddCategoryClicked(object sender, EventArgs e)
    {
        var vm = BindingContext as NewTaskViewModel;

        string category =
             await DisplayPromptAsync("New Category",
             "Write the new category name",
             maxLength: 15,
             keyboard: Keyboard.Text);

        var r = new Random();

        if (!string.IsNullOrEmpty(category))
        {
            var newCategory = new Category
            {
                Id = vm.Categories.Count() == 0 ? 1 : vm.Categories.Max(x => x.Id) + 1,
                Color = Color.FromRgb(
                      r.Next(0, 255),
                      r.Next(0, 255),
                      r.Next(0, 255)).ToHex(),
                CategoryName = category
            };
            vm.Categories.Add(newCategory);

            var categories = await _viewCategoryUseCase.GetCategoriesAsync();
            var categoryId = categories.Count()==0? 1 :categories.Max(x => x.Id) + 1;
            newCategory.Id = categoryId;
            await _addCategoryUseCase.ExecuteAsync(newCategory);
        }
    }
}