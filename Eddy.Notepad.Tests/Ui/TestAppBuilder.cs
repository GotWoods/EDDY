using Avalonia;
using Avalonia.Headless;
using Eddy.Notepad;
using Eddy.Notepad.Tests.Ui;

[assembly: AvaloniaTestApplication(typeof(TestAppBuilder))]

namespace Eddy.Notepad.Tests.Ui;

/// <summary>Builds the Avalonia app used by [AvaloniaFact] tests: headless, Skia-rendered.</summary>
public static class TestAppBuilder
{
    public static AppBuilder BuildAvaloniaApp() =>
        AppBuilder.Configure<App>()
            .UseHeadless(new AvaloniaHeadlessPlatformOptions { UseHeadlessDrawing = false })
            .UseSkia();
}
