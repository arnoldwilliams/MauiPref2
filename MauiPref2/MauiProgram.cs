using MauiPref2.Services;
using MauiPref2.ViewModels;
using MauiPref2.Views;
using Microsoft.Extensions.Logging;

namespace MauiPref2;

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

builder.Services.AddSingleton<ITopicPreferencesService, TopicPreferencesService>();
builder.Services.AddTransient<TopicPreferencesViewModel>();
builder.Services.AddTransient<TopicPreferencesPage>();

#if DEBUG
builder.Logging.AddDebug();
#endif

return builder.Build();
}
}
