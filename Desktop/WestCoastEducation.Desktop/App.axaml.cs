using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Microsoft.Extensions.Configuration;
using WestCoastEducation.Desktop.ViewModels;
using WestCoastEducation.Desktop.Views;

namespace WestCoastEducation.Desktop;

public partial class App : Application
{
    public static IConfiguration Configuration { get; private set; } = null!;

    public override void Initialize()
    {
        Configuration = new ConfigurationBuilder()
            .AddUserSecrets<App>()
            .Build();

        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainViewModel(),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}