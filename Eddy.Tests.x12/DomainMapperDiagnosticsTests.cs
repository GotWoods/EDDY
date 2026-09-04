using System;
using System.IO;
using System.Linq;
using Eddy.x12.DomainModels.Transportation.v4010;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests;

public class DomainMapperDiagnosticsTests
{
    static DomainMapperDiagnosticsTests()
    {
        EdiSectionParserFactory.LoadSegmentProviders();
    }

    /// <summary>Walks up from the test assembly's output directory to find the repository root (marked by
    /// EDDY.sln), then reads the real 204 sample shipped with Eddy.Notepad.</summary>
    private static string ReadSample204()
    {
        var dir = new DirectoryInfo(AppContext.BaseDirectory);
        while (dir != null && !File.Exists(Path.Combine(dir.FullName, "EDDY.sln")))
            dir = dir.Parent;

        Assert.NotNull(dir);
        var path = Path.Combine(dir.FullName, "Eddy.Notepad", "Samples", "Sample-204-LoadTender.edi");
        return File.ReadAllText(path);
    }

    [Fact]
    public void ReportsZeroUnmappedForACleanFile()
    {
        var data = ReadSample204();
        var doc = x12Document.Parse(data);
        Assert.True(doc.IsValid, doc.ValidationErrors.FirstOrDefault()?.ToString());

        var segments = doc.Sections[0].Segments;
        var mapper = new DomainMapper(segments);

        var result = mapper.MapWithDiagnostics<Edi204_MotorCarrierLoadTender>();

        Assert.Empty(result.UnmappedSegments);
        Assert.Empty(result.Diagnostics);
        Assert.Equal(segments.Count, result.ConsumedSegments.Count);
        foreach (var segment in segments)
            Assert.Contains(segment, result.ConsumedSegments);

        Assert.NotNull(result.Value);
        Assert.Equal("9999955559", result.Value.BeginningSegmentForShipmentInformationTransaction.ShipmentIdentificationNumber);
    }

    [Fact]
    public void ReportsTheRightSegmentWhenAnUnexpectedSegmentIsInserted()
    {
        var data = ReadSample204();
        var originalDoc = x12Document.Parse(data);
        Assert.True(originalDoc.IsValid, originalDoc.ValidationErrors.FirstOrDefault()?.ToString());

        //N7 (line 12 in the sample) is the segment right after the N1/N3/N4 name loop - insert an N9
        //(a segment Edi204 does not expect at that point) immediately before it. N9 lands on line 12,
        //pushing N7 and everything after it down by one line.
        var n7 = originalDoc.Sections[0].Segments.OfType<N7_EquipmentDetails>().Single();
        Assert.Equal(12, n7.Source.LineNumber);

        var modified = Eddy.Core.SourceEdit.InsertBefore(data, n7.Source, '\n', "N9*TN*12345");

        var doc = x12Document.Parse(modified, new x12ParseOptions { Lenient = true });
        var segments = doc.Sections[0].Segments;
        var mapper = new DomainMapper(segments);

        var result = mapper.MapWithDiagnostics<Edi204_MotorCarrierLoadTender>();

        Assert.NotEmpty(result.Diagnostics);
        var first = result.Diagnostics[0];
        Assert.Same(result.UnmappedSegments[0], first.Segment);
        Assert.Equal("N9", ((EdiX12Segment)first.Segment).GetType().GetCustomAttributes(typeof(Eddy.Core.Attributes.Segment), false)
            .Cast<Eddy.Core.Attributes.Segment>().Single().Name);
        Assert.Equal(12, first.Source.LineNumber);
        Assert.Equal("Segment N9 at line 12 is not expected here; mapping of Edi204_MotorCarrierLoadTender stopped", first.Message);

        //everything from N9 onward (N9, N7, S5, and the four trailing L11s) is unmapped
        Assert.Equal(7, result.UnmappedSegments.Count);
        Assert.Equal(7, result.Diagnostics.Count);
        for (var i = 1; i < result.Diagnostics.Count; i++)
            Assert.EndsWith("was not mapped", result.Diagnostics[i].Message);

        //everything before N9 was still consumed normally
        Assert.Equal(segments.Count - result.UnmappedSegments.Count, result.ConsumedSegments.Count);
    }
}
