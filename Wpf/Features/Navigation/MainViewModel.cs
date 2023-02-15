using CommunityToolkit.Mvvm.Input;
using Wpf.Features.Home;
using Wpf.Features.Settings;

namespace Wpf.Features.Navigation;

public class MainViewModel : ViewModel
{
    private INavigationService _navigationService;

    public INavigationService NavigationService
    {
        get => _navigationService;
        set
        {
            _navigationService = value;
            OnPropertyChanged();
        }
    }

    public MainViewModel(INavigationService navigationService)
    {
        _navigationService = navigationService;
        NavigateToHomeCommand = new RelayCommand(() => _navigationService.NavigateTo<HomeViewModel>(), () => true);
        NavigateToSettingsCommand =
            new RelayCommand(() => _navigationService.NavigateTo<SettingsViewModel>(), () => true);
    }

    public RelayCommand NavigateToHomeCommand { get; }
    public RelayCommand NavigateToSettingsCommand { get; }
}