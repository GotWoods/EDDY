using Xunit;

namespace Eddy.MetadataTool.Tests;

public class ImportCodesTests
{
    [Fact]
    public void Reads_a_codes_csv_into_a_codes_only_pack()
    {
        var pack = new MetadataPackModel
        {
            Standard = "EDIFACT",
            Version = "D96A",
            Name = "EDIFACT D96A codes from codes.csv",
            Provenance = "Imported by Eddy.MetadataTool import-codes from codes.csv",
        };

        foreach (var row in CsvCodes.Read(RepoPaths.Fixture("codes.csv")))
        {
            if (!pack.Codes.TryGetValue(row.DataElement, out var map))
                pack.Codes[row.DataElement] = map = new Dictionary<string, string>();
            map[row.Code] = row.Description;
        }

        Assert.Empty(pack.DataElements);
        Assert.Empty(pack.Composites);
        Assert.Empty(pack.Segments);

        Assert.Equal(2, pack.Codes.Count);
        Assert.Equal("Buyer", pack.Codes["3035"]["BY"]);
        Assert.Equal("Supplier", pack.Codes["3035"]["SU"]);
        Assert.Equal("Code list one", pack.Codes["1131"]["1"]);

        // Round trip through the writer/reader to make sure a codes-only pack serializes and
        // parses cleanly (no dataElements/composites/segments sections at all).
        var tempFile = Path.GetTempFileName();
        try
        {
            PackJson.Save(pack, tempFile);
            var reloaded = PackJson.Load(tempFile);
            Assert.Equal("Buyer", reloaded.Codes["3035"]["BY"]);
            Assert.Empty(reloaded.DataElements);
        }
        finally
        {
            File.Delete(tempFile);
        }
    }
}
