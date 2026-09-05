using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Eddy.Core.Attributes;
using Eddy.Core.Metadata;
using Xunit;

namespace Eddy.Tests.Metadata;

public class MetadataCatalogTests
{
    [Fact]
    public void DescribeOverlaysPackDataOntoDerivedDefinitionAndKeepsSilentFieldsDerived()
    {
        var pack = new MetadataPack { Name = "N1 overlay pack", Standard = "X12", Version = "004010" };
        pack.DataElements["98"] = new DataElementDefinition { Number = "98", Name = "Entity Identifier Code", DataType = ElementDataType.Identifier, MinLength = 2, MaxLength = 3 };

        var segment = new SegmentDefinition { Id = "N1", Name = "Name (from pack)" };
        segment.Elements.Add(new ElementDefinition { Position = 1, DataElementNumber = "98", Requirement = Requirement.Mandatory });
        pack.Segments["N1"] = segment;

        var catalog = new MetadataCatalog();
        catalog.AddPack(pack);

        var def = catalog.Describe(typeof(Eddy.x12.Models.v4010.N1_Name));

        Assert.Equal("Name (from pack)", def.Name);

        var n101 = def.Elements.Single(e => e.Position == 1);
        Assert.Equal("98", n101.DataElementNumber);
        Assert.Equal("98", n101.CodeListId);
        Assert.Equal("N1 overlay pack", n101.Origin);
        Assert.Equal(Requirement.Mandatory, n101.Requirement);

        // pack said nothing about position 2 (Name); derived length rules must survive untouched.
        var n102 = def.Elements.Single(e => e.Position == 2);
        Assert.Equal("derived", n102.Origin);
        Assert.Equal(1, n102.MinLength);
        Assert.Equal(60, n102.MaxLength);
        Assert.Null(n102.DataElementNumber);
    }

    [Fact]
    public void VersionFallbackPicksD96AForAD97ARequestWhenOnlyD96AIsLoaded()
    {
        var pack = new MetadataPack { Name = "d96a-pack", Standard = "EDIFACT", Version = "D96A" };
        pack.Segments["NAD"] = new SegmentDefinition { Id = "NAD", Name = "NAD from D96A pack" };

        var catalog = new MetadataCatalog();
        catalog.AddPack(pack);

        var def = catalog.Describe(typeof(Eddy.Edifact.Models.D97A.NAD_NameAndAddress));

        Assert.Equal("NAD from D96A pack", def.Name);
        Assert.Equal("D97A", def.Version);
    }

    [Fact]
    public void VersionFallbackPicks004010ForA004020Request()
    {
        var pack = new MetadataPack { Name = "004010-pack", Standard = "X12", Version = "004010" };
        pack.Segments["N1"] = new SegmentDefinition { Id = "N1", Name = "N1 from 004010 pack" };

        var catalog = new MetadataCatalog();
        catalog.AddPack(pack);

        var def = catalog.Describe(typeof(Eddy.x12.Models.v4020.N1_Name));

        Assert.Equal("N1 from 004010 pack", def.Name);
        Assert.Equal("004020", def.Version);
    }

    [Fact]
    public void VersionFallbackNeverPicksAHigherVersionThanRequested()
    {
        var pack = new MetadataPack { Name = "004020-pack", Standard = "X12", Version = "004020" };
        pack.Segments["N1"] = new SegmentDefinition { Id = "N1", Name = "N1 from 004020 pack" };

        var catalog = new MetadataCatalog();
        catalog.AddPack(pack);

        var def = catalog.Describe(typeof(Eddy.x12.Models.v4010.N1_Name));

        // the only loaded pack is for a higher version than requested, so nothing should overlay.
        Assert.Equal("derived", def.Origin);
        Assert.Equal("Name", def.Name);
    }

    [Fact]
    public void DescribeCodeFindsAKnownCodeAndReturnsNullForAnUnknownOne()
    {
        var pack = new MetadataPack { Name = "codes-pack", Standard = "X12", Version = "004010" };
        pack.Codes["98"] = new Dictionary<string, string> { { "BY", "Buyer" }, { "SU", "" } };

        var catalog = new MetadataCatalog();
        catalog.AddPack(pack);

        Assert.Equal("Buyer", catalog.DescribeCode("X12", "004010", "98", "BY"));
        Assert.Equal("", catalog.DescribeCode("X12", "004010", "98", "SU"));
        Assert.Null(catalog.DescribeCode("X12", "004010", "98", "ZZ"));
        Assert.Null(catalog.DescribeCode("X12", "004010", "99", "BY"));
    }

    [Fact]
    public void GetSegmentSearchesSourcesLastAddedFirst()
    {
        var older = new MetadataPack { Name = "older", Standard = "X12", Version = "004010" };
        older.Segments["N1"] = new SegmentDefinition { Id = "N1", Name = "old" };

        var newer = new MetadataPack { Name = "newer", Standard = "X12", Version = "004010" };
        newer.Segments["N1"] = new SegmentDefinition { Id = "N1", Name = "new" };

        var catalog = new MetadataCatalog();
        catalog.AddPack(older);
        catalog.AddPack(newer);

        var result = catalog.GetSegment("X12", "004010", "N1");
        Assert.Equal("new", result.Name);
    }

    [Theory]
    [InlineData("X12", "4010", "004010")]
    [InlineData("X12", "00401", "004010")]
    [InlineData("X12", "004010", "004010")]
    [InlineData("X12", "4020", "004020")]
    [InlineData("EDIFACT", "d96a", "D96A")]
    [InlineData("EDIFACT", "D96A", "D96A")]
    public void NormalizeVersionHandlesEachShorthand(string standard, string input, string expected)
    {
        Assert.Equal(expected, MetadataCatalog.NormalizeVersion(standard, input));
    }

    [Fact]
    public void NormalizeVersionOfNullIsNull()
    {
        Assert.Null(MetadataCatalog.NormalizeVersion("X12", null));
    }

    [Fact]
    public void AddPacksFromDirectorySkipsANonPackJsonFileAndReportsIt()
    {
        var dir = Path.Combine(Path.GetTempPath(), "eddy-metadata-catalog-tests-" + Guid.NewGuid().ToString("N"));
        Directory.CreateDirectory(dir);
        try
        {
            var goodPack = new MetadataPack { Name = "good", Standard = "X12", Version = "004010" };
            goodPack.Save(Path.Combine(dir, "a-good.json"));

            File.WriteAllText(Path.Combine(dir, "b-not-a-pack.json"), "{\"hello\":\"world\"}");

            var catalog = new MetadataCatalog();
            var skipped = catalog.AddPacksFromDirectory(dir);

            Assert.Single(skipped);
            Assert.Contains("b-not-a-pack.json", skipped[0]);
            Assert.Single(catalog.Sources);
            Assert.Equal("good", catalog.Sources[0].Name);
        }
        finally
        {
            try { Directory.Delete(dir, true); } catch { /* best effort */ }
        }
    }

    [Fact]
    public void DescribeIsSafeWhenCalledConcurrentlyAcrossManyTypes()
    {
        var catalog = new MetadataCatalog();
        var pack = new MetadataPack { Name = "concurrency-pack", Standard = "X12", Version = "004010" };
        pack.Segments["N1"] = new SegmentDefinition { Id = "N1", Name = "N1 concurrent" };
        catalog.AddPack(pack);

        var types = typeof(Eddy.x12.Models.v4010.N1_Name).Assembly.GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract
                        && t.Namespace != null
                        && (t.Namespace == "Eddy.x12.Models.v4010" || t.Namespace == "Eddy.x12.Models.v4010.Composites")
                        && t.GetProperties(BindingFlags.Public | BindingFlags.Instance).Any(p => p.GetCustomAttribute<PositionAttribute>() != null))
            .Take(150)
            .ToList();

        Assert.NotEmpty(types);

        var exceptions = new List<Exception>();
        Parallel.ForEach(types, t =>
        {
            try
            {
                catalog.Describe(t);
                DerivedSegmentMetadata.Describe(t);
            }
            catch (Exception ex)
            {
                lock (exceptions) exceptions.Add(ex);
            }
        });

        Assert.True(exceptions.Count == 0, $"{exceptions.Count} concurrent Describe() calls threw. First: {exceptions.FirstOrDefault()}");
    }
}
