using System.IO;
using Avalonia.Headless;
using Avalonia.Headless.XUnit;
using Avalonia.Threading;
using Eddy.Notepad.Services;
using Eddy.Notepad.ViewModels;
using Eddy.Notepad.Views;
using Eddy.Notepad.Views.Design;

namespace Eddy.Notepad.Tests.Ui;

public class MainWindowRenderTests
{
    [AvaloniaFact]
    public void MainWindow_renders_a_design_document()
    {
        var loader = new DesignDocumentLoader();
        var viewModel = new MainWindowViewModel(loader, new NullFilePicker());
        var document = DesignData.AddDesignDocument(viewModel, loader);

        var window = new MainWindow { DataContext = viewModel };

        window.Show();
        Dispatcher.UIThread.RunJobs();
        window.InvalidateMeasure();
        window.InvalidateArrange();
        Dispatcher.UIThread.RunJobs();

        Assert.NotEmpty(document.Nodes);
        Assert.True(viewModel.HasDocuments);
        Assert.Same(document, viewModel.ActiveDocument);

        var frame = window.CaptureRenderedFrame();
        Assert.NotNull(frame);

        var outputPath = Path.Combine(AppContext.BaseDirectory, "MainWindow.png");
        frame!.Save(outputPath);

        Assert.True(File.Exists(outputPath));
        Assert.True(new FileInfo(outputPath).Length > 0);
    }
}
