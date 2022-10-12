using ConferenceMauiDemo.Services;
using ConferenceMauiDemo.ViewModels;
using ConferenceMauiDemo.Views;
using Microsoft.Extensions.DependencyInjection;

namespace ConferenceMauiDemo;

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

		builder.Services.AddSingleton<IDataService, FileDataService>();
        builder.Services.AddTransient<SessionsPageViewModel>();
        builder.Services.AddTransient<SessionsPage>();
        builder.Services.AddTransient<SessionDetailPageViewModel>();
        builder.Services.AddTransient<SessionDetailPage>();

        return builder.Build();
	}
}
