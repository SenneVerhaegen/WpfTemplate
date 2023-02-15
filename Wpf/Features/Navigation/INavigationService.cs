namespace Wpf.Features.Navigation;

public interface INavigationService
{
    ViewModel CurrentView { get; }
    void NavigateTo<T>() where T : ViewModel;
}