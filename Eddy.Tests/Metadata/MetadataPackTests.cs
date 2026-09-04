using System;
using System.Collections.Generic;
using System.IO;
using Eddy.Core.Metadata;
using Xunit;

namespace Eddy.Tests.Metadata;

public class MetadataPackTests : IDisposable
{
    private readonly string _dir;

    public MetadataPackTests()
    {
        _dir = Path.Combine(Path.GetTempPath(), "eddy-metadata-pack-tests-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(_dir);
    }

    public void Dispose()
    {
        try { Directory.Delete(_dir, true); } catch { /* best effort */ }
    }

    private static MetadataPack BuildSamplePack()
    {
        var pack = new MetadataPack
        {
            Name = "EDIFACT D96A test pack",
            Standard = "EDIFACT",
            Version = "D96A",
            Provenance = "unit test",
            License = "MIT",
        };

        pack.DataElements["3035"] = new DataElementDefinition { Number = "3035", Name = "Party qualifier", DataType = ElementDataType.Identifier, MinLength = 1, MaxLength = 3 };
        pack.DataElements["3039"] = new DataElementDefinition { Number = "3039", Name = "Party id identification", DataType = ElementDataType.AlphaNumeric, MinLength = 1, MaxLength = 35 };
        pack.DataElements["1131"] = new DataElementDefinition { Number = "1131", Name = "Code list qualifier", DataType = ElementDataType.Identifier, MinLength = 1, MaxLength = 3 };

        var composite = new SegmentDefinition { Id = "C082", Name = "Party identification details" };
        composite.Elements.Add(new ElementDefinition { Position = 1, DataElementNumber = "3039", Requirement = Requirement.Mandatory });
        composite.Elements.Add(new ElementDefinition { Position = 2, DataElementNumber = "1131", Requirement = Requirement.Conditional });
        pack.Composites["C082"] = composite;

        var segment = new SegmentDefinition { Id = "NAD", Name = "Name and address" };
        segment.Elements.Add(new ElementDefinition { Position = 1, DataElementNumber = "3035", Requirement = Requirement.Mandatory });
        segment.Elements.Add(new ElementDefinition { Position = 2, CompositeId = "C082", Requirement = Requirement.Conditional });
        pack.Segments["NAD"] = segment;

        pack.Codes["3035"] = new Dictionary<string, string> { { "BY", "Buyer" }, { "SU", "Supplier" }, { "DP", "" } };

        return pack;
    }

    [Fact]
    public void RoundTripsByteForByteFromTheSecondSaveOnward()
    {
        var original = BuildSamplePack();

        var path1 = Path.Combine(_dir, "a.json");
        original.Save(path1);

        var loaded1 = MetadataPack.Load(path1);
        var path2 = Path.Combine(_dir, "b.json");
        loaded1.Save(path2);

        var loaded2 = MetadataPack.Load(path2);
        var path3 = Path.Combine(_dir, "c.json");
        loaded2.Save(path3);

        var bytes2 = File.ReadAllBytes(path2);
        var bytes3 = File.ReadAllBytes(path3);
        Assert.Equal(bytes2, bytes3);
    }

    [Fact]
    public void LoadResolvesSegmentsAndComposites()
    {
        var pack = BuildSamplePack();
        var path = Path.Combine(_dir, "sample.json");
        pack.Save(path);

        var loaded = MetadataPack.Load(path);
        var nad = loaded.GetSegment("EDIFACT", "D96A", "NAD");

        Assert.NotNull(nad);
        Assert.Equal("Name and address", nad.Name);
        Assert.Equal(2, nad.Elements.Count);

        var partyQualifier = nad.Elements.Find(e => e.Position == 1);
        Assert.Equal("3035", partyQualifier.DataElementNumber);
        Assert.Equal("Party qualifier", partyQualifier.Name);
        Assert.Equal(ElementDataType.Identifier, partyQualifier.DataType);
        Assert.Equal("3035", partyQualifier.CodeListId);
        Assert.Equal(Requirement.Mandatory, partyQualifier.Requirement);

        var compositeElem = nad.Elements.Find(e => e.Position == 2);
        Assert.Equal("C082", compositeElem.CompositeId);
        Assert.Equal(ElementDataType.Composite, compositeElem.DataType);
        Assert.Equal(2, compositeElem.Components.Count);
        Assert.Equal("3039", compositeElem.Components.Find(c => c.Position == 1).DataElementNumber);
    }

    [Fact]
    public void LoadRejectsAMissingFormat()
    {
        var path = Path.Combine(_dir, "no-format.json");
        File.WriteAllText(path, "{\"standard\":\"X12\",\"version\":\"004010\"}");

        var ex = Assert.Throws<InvalidDataException>(() => MetadataPack.Load(path));
        Assert.Contains("missing", ex.Message, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void LoadRejectsADifferentFormat()
    {
        var path = Path.Combine(_dir, "wrong-format.json");
        File.WriteAllText(path, "{\"format\":\"something-else/1\",\"standard\":\"X12\",\"version\":\"004010\"}");

        var ex = Assert.Throws<InvalidDataException>(() => MetadataPack.Load(path));
        Assert.Contains("something-else/1", ex.Message);
    }

    [Fact]
    public void MergeFromLetsOtherWinPerKeyAndMergesCodesPerCode()
    {
        var pack = new MetadataPack { Name = "base", Standard = "X12", Version = "004010" };
        pack.DataElements["98"] = new DataElementDefinition { Number = "98", Name = "old name" };
        pack.Codes["98"] = new Dictionary<string, string> { { "BY", "Buyer" }, { "SU", "Supplier" } };

        var other = new MetadataPack { Name = "overlay", Standard = "X12", Version = "004010" };
        other.DataElements["98"] = new DataElementDefinition { Number = "98", Name = "new name" };
        other.Codes["98"] = new Dictionary<string, string> { { "SU", "Supplier updated" }, { "ST", "Ship To" } };

        pack.MergeFrom(other);

        Assert.Equal("overlay", pack.Name);
        Assert.Equal("new name", pack.DataElements["98"].Name);
        Assert.Equal("Buyer", pack.Codes["98"]["BY"]); // untouched by other, kept
        Assert.Equal("Supplier updated", pack.Codes["98"]["SU"]); // other wins
        Assert.Equal("Ship To", pack.Codes["98"]["ST"]); // added by other
    }
}
