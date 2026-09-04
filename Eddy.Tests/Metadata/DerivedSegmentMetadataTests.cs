using System.Linq;
using Eddy.Core.Metadata;
using Xunit;

namespace Eddy.Tests.Metadata;

public class DerivedSegmentMetadataTests
{
    [Fact]
    public void N1_v4010_HasSixElementsWithExpectedShape()
    {
        var def = DerivedSegmentMetadata.Describe(typeof(Eddy.x12.Models.v4010.N1_Name));

        Assert.Equal("N1", def.Id);
        Assert.Equal("Name", def.Name);
        Assert.Equal("derived", def.Origin);
        Assert.Equal(6, def.Elements.Count);

        var n101 = def.Elements[0];
        Assert.Equal(1, n101.Position);
        Assert.Equal("N101", n101.Reference);
        Assert.Equal("Entity Identifier Code", n101.Name);
        Assert.Equal("EntityIdentifierCode", n101.PropertyName);
        Assert.Equal(ElementDataType.AlphaNumeric, n101.DataType);
        Assert.Equal(Requirement.Mandatory, n101.Requirement);
        Assert.Equal(2, n101.MinLength);
        Assert.Equal(3, n101.MaxLength);

        var n102 = def.Elements[1];
        Assert.Equal(2, n102.Position);
        Assert.Equal("N102", n102.Reference);
        Assert.Equal("Name", n102.Name);
        Assert.Equal(Requirement.Optional, n102.Requirement);
        Assert.Equal(1, n102.MinLength);
        Assert.Equal(60, n102.MaxLength);

        var n105 = def.Elements.Single(e => e.PropertyName == "EntityRelationshipCode");
        Assert.Equal(5, n105.Position);
        Assert.Equal("N105", n105.Reference);
        Assert.Equal(2, n105.MinLength);
        Assert.Equal(2, n105.MaxLength);

        var n106 = def.Elements.Single(e => e.PropertyName == "EntityIdentifierCode2");
        Assert.Equal("Entity Identifier Code 2", n106.Name);
        Assert.Equal("N106", n106.Reference);
    }

    [Fact]
    public void N1_v4020_DerivesIdenticallyThroughInheritance()
    {
        var v4010 = DerivedSegmentMetadata.Describe(typeof(Eddy.x12.Models.v4010.N1_Name));
        var v4020 = DerivedSegmentMetadata.Describe(typeof(Eddy.x12.Models.v4020.N1_Name));

        Assert.Equal(v4010.Id, v4020.Id);
        Assert.Equal(v4010.Name, v4020.Name);
        Assert.Equal(v4010.Elements.Count, v4020.Elements.Count);
        for (var i = 0; i < v4010.Elements.Count; i++)
        {
            Assert.Equal(v4010.Elements[i].Reference, v4020.Elements[i].Reference);
            Assert.Equal(v4010.Elements[i].Name, v4020.Elements[i].Name);
            Assert.Equal(v4010.Elements[i].Requirement, v4020.Elements[i].Requirement);
            Assert.Equal(v4010.Elements[i].MinLength, v4020.Elements[i].MinLength);
            Assert.Equal(v4010.Elements[i].MaxLength, v4020.Elements[i].MaxLength);
        }
    }

    [Fact]
    public void DateAndTimeValidatorsAreDetected()
    {
        var def = DerivedSegmentMetadata.Describe(typeof(XDT_DateTimeProbe), "X12", "004010");

        var dateElem = def.Elements.Single(e => e.PropertyName == "DateField");
        var timeElem = def.Elements.Single(e => e.PropertyName == "TimeField");
        var plainElem = def.Elements.Single(e => e.PropertyName == "PlainField");

        Assert.Equal(ElementDataType.Date, dateElem.DataType);
        Assert.Equal(ElementDataType.Time, timeElem.DataType);
        Assert.Equal(ElementDataType.AlphaNumeric, plainElem.DataType);
        Assert.Equal(1, plainElem.MinLength);
        Assert.Equal(5, plainElem.MaxLength);
    }

    [Fact]
    public void CompositeElementReportsComponentsRecursively()
    {
        var def = DerivedSegmentMetadata.Describe(typeof(Eddy.x12.Models.v4010.TIA_TaxInformationAndAmount));

        var composite = def.Elements.Single(e => e.PropertyName == "CompositeUnitOfMeasure");
        Assert.Equal(ElementDataType.Composite, composite.DataType);
        Assert.Equal("C001", composite.CompositeId);
        Assert.NotEmpty(composite.Components);

        var first = composite.Components.OrderBy(c => c.Position).First();
        Assert.StartsWith("C001", first.Reference);
        Assert.Equal(ElementDataType.AlphaNumeric, first.DataType);
    }

    [Fact]
    public void EdifactNad_D96A_WorksWithEdifactComponentComposites()
    {
        var def = DerivedSegmentMetadata.Describe(typeof(Eddy.Edifact.Models.D96A.NAD_NameAndAddress));

        Assert.Equal("NAD", def.Id);
        Assert.Equal("Name And Address", def.Name);

        var partyQualifier = def.Elements.Single(e => e.PropertyName == "PartyQualifier");
        Assert.Equal(Requirement.Mandatory, partyQualifier.Requirement);
        Assert.Equal(1, partyQualifier.MinLength);
        Assert.Equal(3, partyQualifier.MaxLength);

        var partyId = def.Elements.Single(e => e.PropertyName == "PartyIdentificationDetails");
        Assert.Equal(ElementDataType.Composite, partyId.DataType);
        Assert.Equal("C082", partyId.CompositeId);
        Assert.NotEmpty(partyId.Components);

        var partyIdSub = partyId.Components.Single(c => c.PropertyName == "PartyIdIdentification");
        Assert.Equal(Requirement.Mandatory, partyIdSub.Requirement);
        Assert.Equal("C08201", partyIdSub.Reference);
    }

    [Theory]
    [InlineData("Eddy.x12.Models.v4010", "X12", "004010")]
    [InlineData("Eddy.x12.Models.v4010.Composites", "X12", "004010")]
    [InlineData("Eddy.x12.Models.v8040", "X12", "008040")]
    [InlineData("Eddy.Edifact.Models.D96A", "EDIFACT", "D96A")]
    [InlineData("Eddy.Edifact.Models.D96A.Composites", "EDIFACT", "D96A")]
    [InlineData("Eddy.Edifact.Models.Beta", "EDIFACT", "Beta")]
    [InlineData("Eddy.Edifact.Models.Beta.Composites", "EDIFACT", "Beta")]
    [InlineData("Eddy.x12.Models.Elements", null, null)]
    [InlineData("Eddy.Tests.Metadata", null, null)]
    public void InferStandardAndVersion_HandlesEveryNamespaceShape(string ns, string expectedStandard, string expectedVersion)
    {
        var type = FakeTypeInNamespace(ns);

        DerivedSegmentMetadata.InferStandardAndVersion(type, out var standard, out var version);

        Assert.Equal(expectedStandard, standard);
        Assert.Equal(expectedVersion, version);
    }

    // Reuses a small set of real types whose namespaces already match each shape under test,
    // so InferStandardAndVersion is exercised against real reflection Type objects.
    private static System.Type FakeTypeInNamespace(string ns)
    {
        return ns switch
        {
            "Eddy.x12.Models.v4010" => typeof(Eddy.x12.Models.v4010.N1_Name),
            "Eddy.x12.Models.v4010.Composites" => typeof(Eddy.x12.Models.v4010.Composites.C001_CompositeUnitOfMeasure),
            "Eddy.x12.Models.v8040" => typeof(Eddy.x12.Models.v8040.N1_PartyIdentification),
            "Eddy.Edifact.Models.D96A" => typeof(Eddy.Edifact.Models.D96A.NAD_NameAndAddress),
            "Eddy.Edifact.Models.D96A.Composites" => typeof(Eddy.Edifact.Models.D96A.Composites.C082_PartyIdentificationDetails),
            "Eddy.Edifact.Models.Beta" => FindBetaSegmentType(),
            "Eddy.Edifact.Models.Beta.Composites" => typeof(Eddy.Edifact.Models.Beta.Composites.FakeBetaComposite),
            "Eddy.x12.Models.Elements" => typeof(Eddy.x12.Models.Elements.C001_CompositeUnitOfMeasure2),
            "Eddy.Tests.Metadata" => typeof(XDT_DateTimeProbe),
            _ => throw new System.ArgumentOutOfRangeException(nameof(ns), ns, "no fixture for this namespace")
        };
    }

    private static System.Type FindBetaSegmentType()
    {
        return typeof(Eddy.Edifact.Models.D96A.NAD_NameAndAddress).Assembly.GetTypes()
            .First(t => t.Namespace == "Eddy.Edifact.Models.Beta");
    }

}
