using System.Windows;
using ReactiveUI;
using SuspensionHostDemo.Presentation.State;
using SuspensionHostDemo.Presentation.ViewModels;

namespace SuspensionHostDemo.Presentation.Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly AutoSuspendHelper _suspension;

        public App()
        {
            _suspension = new AutoSuspendHelper(this);
            RxApp.SuspensionHost.CreateNewAppState = () => new MainState();
            RxApp.SuspensionHost.SetupDefaultSuspendResume(new NewtonsoftJsonSuspensionDriver("appstate.json"));

            var state = RxApp.SuspensionHost.GetAppState<MainState>();
            var viewModel = new MainViewModel(state);
            MainWindow = new MainWindow
            {
                DataContext = viewModel
            };
            MainWindow.Show();
        }
    }
}