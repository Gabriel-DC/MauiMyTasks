using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiMyTasks.ViewModel;

public partial class MainViewModel : ObservableObject
{
    private IConnectivity _connectivity;
    public MainViewModel(IConnectivity connectivity)
    {
        _connectivity = connectivity;
        Items = new ObservableCollection<string>();
    }
    
    [ObservableProperty]
    private ObservableCollection<string> _items;
    
    [ObservableProperty]
    private string _text;
    
    [RelayCommand]
    private async Task Add()
    {
        if(string.IsNullOrWhiteSpace(Text))
            return;

        if (_connectivity.NetworkAccess != NetworkAccess.Internet)
        {
            await Shell.Current.DisplayAlert("Uh oh!", "No internet", "OK");
            return;
        }
        
        Items.Add(Text);
        Text = string.Empty;
    }

    [RelayCommand]
    private void Delete(string s)
    {
        if (Items.Contains(s))
            Items.Remove(s);
    }

    [RelayCommand]
    private async Task Tap(string s)
        => await Shell.Current.GoToAsync($"{nameof(DetailPage)}?Text={s}");
}