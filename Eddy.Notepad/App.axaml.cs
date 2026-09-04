using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Eddy.Notepad.Services;
using Eddy.Notepad.ViewModels;
using Eddy.Notepad.Views;

namespace Eddy.Notepad;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var window = new MainWindow();
            var viewModel = new MainWindowViewModel(new DocumentLoader(), new NullFilePicker());
            window.DataContext = viewModel;
            desktop.MainWindow = window;

            // Files passed on the command line open on startup.
            foreach (var path in desktop.Args ?? Array.Empty<string>())
                _ = viewModel.OpenPathAsync(path);
        }

        base.OnFrameworkInitializationCompleted();
    }
}
