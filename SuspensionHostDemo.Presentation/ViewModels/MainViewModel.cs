using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using SuspensionHostDemo.Presentation.State;

namespace SuspensionHostDemo.Presentation.ViewModels;

public class MainViewModel : ReactiveObject
{
    [Reactive]
    public string FirstName { get; set; }

    [Reactive]
    public string LastName { get; set; }

    public MainViewModel(MainState mainState)
    {
        FirstName = mainState.FirstName;
        LastName = mainState.LastName;

        this.WhenAnyValue(x => x.FirstName)
            .Subscribe(x => { mainState.FirstName = x; });
        this.WhenAnyValue(x => x.LastName)
            .Subscribe(x => { mainState.LastName = x; });
    }
}