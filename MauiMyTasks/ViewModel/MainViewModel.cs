using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MauiMyTasks.ViewModel;

public partial class MainViewModel : ObservableObject
{
    public MainViewModel()
    {
        Items = new ObservableCollection<string>();
    }
    
    [ObservableProperty]
    private ObservableCollection<string> _items;
    
    [ObservableProperty]
    private string _text;
    
    [RelayCommand]
    private void Add()
    {
        if(string.IsNullOrWhiteSpace(Text))
            return;
        
        Items.Add(Text);
        Text = string.Empty;
    }

    [RelayCommand]
    private void Delete(string s)
    {
        if (Items.Contains(s))
            Items.Remove(s);
    }
    
}