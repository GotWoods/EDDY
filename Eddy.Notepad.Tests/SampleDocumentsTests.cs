using Eddy.Notepad.Services;

namespace Eddy.Notepad.Tests;

public class SampleDocumentsTests
{
    [Fact]
    public void Bundled_samples_are_discoverable()
    {
        var names = SampleDocuments.GetNames();
        Assert.Contains("Sample-204-LoadTender", names);
        Assert.Contains("Sample-210-Invoice", names);
        Assert.Contains("Sample-214-ShipmentStatus", names);
        Assert.Contains("Sample-INVOIC-Invoice", names);
    }

    [Fact]
    public void Sample_text_starts_with_ISA()
    {
        Assert.StartsWith("ISA*", SampleDocuments.GetText("Sample-204-LoadTender"));
    }

    [Fact]
    public void Edifact_sample_text_starts_with_UNA()
    {
        Assert.StartsWith("UNA", SampleDocuments.GetText("Sample-INVOIC-Invoice"));
    }
}
