using MauiMyTasks.ViewModel;

namespace MauiMyTasks;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}