using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Eddy.Core.Metadata;
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
            // Embedded packs, then EDDY_METADATA_PACKS, before anything asks MetadataCatalog.Default to
            // describe a segment (see Services/MetadataPacks.cs and docs/metadata-packs.md).
            var (loadedPacks, _) = MetadataPacks.LoadDefaults(MetadataCatalog.Default);

            var window = new MainWindow();

            // Set with EDDY_NOTEPAD_DESIGN_DATA=1 to run against hand-made data instead of the
            // real parser - useful for exercising the view layer independently of the loader.
            var useDesignData = Environment.GetEnvironmentVariable("EDDY_NOTEPAD_DESIGN_DATA") == "1";

            IDocumentLoader loader = useDesignData ? new DesignDocumentLoader() : new DocumentLoader();
            var viewModel = new MainWindowViewModel(loader, new StorageProviderFilePicker(window), MetadataCatalog.Default);
            foreach (var pack in loadedPacks)
                viewModel.RegisterLoadedPack(new PackInfoViewModel(pack.Name, pack.Standard, pack.Version, pack.Source));
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
