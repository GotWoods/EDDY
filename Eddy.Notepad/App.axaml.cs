using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Eddy.Notepad.Services;
using Eddy.Notepad.ViewModels;
using Eddy.Notepad.Views;
using Eddy.Notepad.Views.Design;

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

            // Set with EDDY_NOTEPAD_DESIGN_DATA=1 to run against hand-made data instead of the
            // real parser - useful for exercising the view layer independently of the loader.
            var useDesignData = Environment.GetEnvironmentVariable("EDDY_NOTEPAD_DESIGN_DATA") == "1";

            IDocumentLoader loader = useDesignData ? new DesignDocumentLoader() : new DocumentLoader();
            var viewModel = new MainWindowViewModel(loader, new StorageProviderFilePicker(window));
            window.DataContext = viewModel;
            desktop.MainWindow = window;

            if (useDesignData)
                DesignData.AddDesignDocument(viewModel, loader as DesignDocumentLoader);

            // Files passed on the command line open on startup.
            foreach (var path in desktop.Args ?? Array.Empty<string>())
                _ = viewModel.OpenPathAsync(path);
        }

        base.OnFrameworkInitializationCompleted();
    }
}
