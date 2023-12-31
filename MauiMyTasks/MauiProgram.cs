﻿using MauiMyTasks.ViewModel;
using Microsoft.Extensions.Logging;

namespace MauiMyTasks;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services
            .AddSingleton<IConnectivity>(Connectivity.Current)
            .AddSingleton<MainPage>()
            .AddSingleton<MainViewModel>()
            .AddTransient<DetailPage>()
            .AddTransient<DetailViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}