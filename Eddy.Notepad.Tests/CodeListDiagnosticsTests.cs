using Eddy.Notepad.Services;
using Eddy.Notepad.ViewModels;

namespace Eddy.Notepad.Tests;

public class CodeListDiagnosticsTests
{
    [Fact]
    public void Unknown_code_value_becomes_a_warning_diagnostic_on_the_segment_node()
    {
        MetadataPacks.LoadDefaults(Eddy.Core.Metadata.MetadataCatalog.Default);
        var text = SampleDocuments.GetText("Sample-INVOIC-Invoice").Replace("NAD+BY+", "NAD+ZQ+");

        var document = new DocumentLoader().Load(text, "planted", null);

        var warning = Assert.Single(document.Diagnostics, d => d.Message.Contains("'ZQ'"));
        Assert.Equal(DiagnosticSeverity.Warning, warning.Severity);
        Assert.Equal("NAD", warning.SegmentCode);
        Assert.NotNull(warning.Node);
        Assert.Equal("NAD", warning.Node!.Code);
        Assert.True(document.IsValid, "a code list warning must not make the document invalid");
        Assert.Equal(0, document.ErrorCount);
        Assert.Equal(1, document.WarningCount);
    }

    [Fact]
    public void Standard_code_values_produce_no_code_list_diagnostics()
    {
        MetadataPacks.LoadDefaults(Eddy.Core.Metadata.MetadataCatalog.Default);
        var document = new DocumentLoader().Load(SampleDocuments.GetText("Sample-INVOIC-Invoice"), "clean", null);
        Assert.DoesNotContain(document.Diagnostics, d => d.Message.Contains("not in code list"));
    }
}
