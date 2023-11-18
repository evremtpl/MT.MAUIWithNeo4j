using MT.MAUIWithNeo4j.MVVM.Views;

namespace MT.MAUIWithNeo4j
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage (new MainView());
           
        }
    }
}
