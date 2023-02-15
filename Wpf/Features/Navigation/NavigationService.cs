using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Wpf.Features.Navigation;

[ObservableObject]
public partial class NavigationService : INavigationService
{
    private ViewModel _currentView;
    private readonly Func<Type, ViewModel> _viewModelFactory;

    public ViewModel CurrentView
    {
        get => _currentView;
        private set
        {
            _currentView = value;
            OnPropertyChanged();
        }
    }

    public NavigationService(Func<Type, ViewModel> viewModelFactory)
    {
        _viewModelFactory = viewModelFactory;
    }

    public void NavigateTo<TViewModel>() where TViewModel : ViewModel
    {
        CurrentView = _viewModelFactory.Invoke(typeof(TViewModel));
    }
}