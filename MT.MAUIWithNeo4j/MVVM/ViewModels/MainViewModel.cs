using MT.MAUIWithNeo4j.Core;
using PropertyChanged;

using System.Collections.ObjectModel;
using MT.MAUIWithNeo4j.UseCases.Interfaces;

namespace MT.MAUIWithNeo4j.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class MainViewModel
    {

        private readonly IViewTaskUseCase _viewTaskUseCase;
        private readonly IViewCategoryUseCase _viewCategoryUseCase;
        public ObservableCollection<Category> Categories { get; set; }
        public ObservableCollection<MyTask> Tasks { get; set; }
        public MainViewModel(IViewTaskUseCase viewTaskUseCase, IViewCategoryUseCase viewCategoryUseCase)
        {
            Categories = new ObservableCollection<Category>();
            Tasks = new ObservableCollection<MyTask>();
            _viewTaskUseCase = viewTaskUseCase;
            _viewCategoryUseCase = viewCategoryUseCase;
            FillData();
            Tasks.CollectionChanged += Tasks_CollectionChanged;
            
          
        }

        private void Tasks_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            UpdateData();
        }

        private async  Task  FillData()
        {
            this.Categories.Clear();

            var categories = await _viewCategoryUseCase.GetCategoriesAsync();
            if (categories != null && categories.Count > 0)
            {
                foreach (var category in categories)
                {
                    this.Categories.Add(category);
                }
            }

            this.Tasks.Clear();

            var tasks = await _viewTaskUseCase.GetTasksAsync();
            if (tasks != null && tasks.Count > 0)
            {
                foreach (var task in tasks)
                {
                    this.Tasks.Add(task);
                }
            }

            UpdateData();
        }

        public void UpdateData()
        {
            foreach (var c in Categories)
            {
                var tasks = from t in Tasks
                            where t.CategoryId == c.Id
                            select t;

                var completed = from t in tasks
                                where t.Completed == true
                                select t;

                var notCompleted = from t in tasks
                                   where t.Completed == false
                                   select t;



                c.PendingTasks = notCompleted.Count();
                c.Percentage = (float)completed.Count() / (float)tasks.Count();
            }
            foreach (var t in Tasks)
            {
                var catColor =
                     (from c in Categories
                      where c.Id == t.CategoryId
                      select c.Color).FirstOrDefault();
                t.TaskColor = catColor;
            }
        }
    }
}
