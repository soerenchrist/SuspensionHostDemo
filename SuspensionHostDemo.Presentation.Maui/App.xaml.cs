using ReactiveUI;
using SuspensionHostDemo.Presentation.State;
using SuspensionHostDemo.Presentation.ViewModels;
using AutoSuspendHelper = ReactiveUI.Maui.AutoSuspendHelper;

namespace SuspensionHostDemo.Presentation.Maui;

public partial class App : Application
{
    private readonly AutoSuspendHelper _suspension;
    
    public App()
    {
        InitializeComponent();
        _suspension = new AutoSuspendHelper();
        RxApp.SuspensionHost.CreateNewAppState = () => new MainState();
        RxApp.SuspensionHost.SetupDefaultSuspendResume(new NewtonsoftJsonSuspensionDriver(
            Path.Combine(FileSystem.AppDataDirectory, "state.json")));

        _suspension.OnCreate();

        var state = RxApp.SuspensionHost.GetAppState<MainState>();
        var viewModel = new MainViewModel(state);

        MainPage = new MainPage
        {
            BindingContext = viewModel
        };
    }

    protected override void OnResume()
    {
        base.OnResume();
        _suspension.OnResume();
    }

    protected override void OnStart()
    {
        base.OnStart();
        _suspension.OnStart();
    }

    protected override void OnSleep()
    {
        base.OnSleep();
        _suspension.OnSleep();
    }
}