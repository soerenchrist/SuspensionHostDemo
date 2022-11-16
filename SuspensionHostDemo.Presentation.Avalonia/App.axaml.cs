using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using SuspensionHostDemo.Presentation.State;
using SuspensionHostDemo.Presentation.ViewModels;

namespace SuspensionHostDemo.Presentation.Avalonia
{
    public partial class App : Application
    {
        public override void Initialize()
        {
            AvaloniaXamlLoader.Load(this);
        }

        public override void OnFrameworkInitializationCompleted()
        {
            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                var suspension = new AutoSuspendHelper(ApplicationLifetime);
                RxApp.SuspensionHost.CreateNewAppState = () => new MainState();
                RxApp.SuspensionHost.SetupDefaultSuspendResume(new NewtonsoftJsonSuspensionDriver("appstate.json"));
                suspension.OnFrameworkInitializationCompleted();

                var state = RxApp.SuspensionHost.GetAppState<MainState>();
                desktop.MainWindow = new MainWindow
                {
                    DataContext = new MainViewModel(state)
                };
            }

            base.OnFrameworkInitializationCompleted();
        }
    }
}