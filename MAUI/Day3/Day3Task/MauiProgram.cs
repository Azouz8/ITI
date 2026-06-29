using Day3Task;
using Day3Task.Services;
using Day3Task.ViewModels;
using Day3Task.Views;
using Microsoft.Extensions.Logging;

namespace Day3Task;

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
            });

        builder.Services.AddSingleton<DatabaseService>();

        builder.Services.AddTransient<EmployeeFormViewModel>();
        builder.Services.AddTransient<EmployeeListViewModel>();

        builder.Services.AddTransient<EmployeeFormPage>();
        builder.Services.AddTransient<EmployeeListPage>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}