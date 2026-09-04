using System.Collections.Generic;
using Eddy.Core.Codes;
using Eddy.Core.Metadata;
using Xunit;

namespace Eddy.Tests.Codes;

[Collection("CodeCatalog")]
public class CodeTests
{
    private sealed class TestPartyCodes : CodeList
    {
        public override string Standard => "EDIFACT";
        public override string DataElementNumber => "9035";
        public override string Name => "Test Party Qualifier";
    }

    private enum TestPartyEnum
    {
        [CodeValue("BY")]
        Buyer,

        // No [CodeValue]: falls back to the member's own name.
        SU,
    }

    private static MetadataCatalog BuildCatalog()
    {
        var catalog = new MetadataCatalog();
        var pack = new MetadataPack { Standard = "EDIFACT", Version = "D96A", Name = "test" };
        pack.Codes["9035"] = new Dictionary<string, string> { ["BY"] = "Buyer", ["SU"] = "" };
        catalog.AddPack(pack);
        return catalog;
    }

    [Fact]
    public void ImplicitConversionFromString_SetsValue()
    {
        Code<TestPartyCodes> code = "BY";
        Assert.Equal("BY", code.Value);
    }

    [Fact]
    public void ImplicitConversionFromNullString_GivesNull()
    {
        Code<TestPartyCodes> code = (string)null;
        Assert.Null(code);
    }

    [Fact]
    public void ImplicitConversionToString_ReturnsValue()
    {
        Code<TestPartyCodes> code = "BY";
        string value = code;
        Assert.Equal("BY", value);

        Code<TestPartyCodes> nullCode = null;
        string nullValue = nullCode;
        Assert.Null(nullValue);
    }

    [Fact]
    public void ToString_ReturnsValue()
    {
        Code<TestPartyCodes> code = "BY";
        Assert.Equal("BY", code.ToString());
    }

    [Fact]
    public void Equality_IsOrdinalOnValue()
    {
        Code<TestPartyCodes> a = "BY";
        Code<TestPartyCodes> b = "BY";
        Code<TestPartyCodes> c = "SU";

        Assert.True(a == b);
        Assert.False(a != b);
        Assert.Equal(a, b);
        Assert.Equal(a.GetHashCode(), b.GetHashCode());

        Assert.False(a == c);
        Assert.True(a != c);

        Assert.True(a == "BY");
        Assert.True("BY" == a);
        Assert.False(a == "SU");
        Assert.True(a != "SU");
    }

    [Fact]
    public void Equality_HandlesNulls()
    {
        Code<TestPartyCodes> a = null;
        Code<TestPartyCodes> b = null;
        Assert.True(a == b);

        Code<TestPartyCodes> c = "BY";
        Assert.False(a == c);
        Assert.False(c == a);
        Assert.True(c != a);
        Assert.True(a == (string)null);
    }

    [Fact]
    public void EnumConversion_UsesCodeValueAttributeOrFallsBackToMemberName()
    {
        Code<TestPartyCodes> buyer = TestPartyEnum.Buyer;
        Assert.Equal("BY", buyer.Value);

        Code<TestPartyCodes> su = TestPartyEnum.SU;
        Assert.Equal("SU", su.Value);
    }

    [Fact]
    public void TryGetEnum_MatchesByCodeValueAttributeOrName()
    {
        Code<TestPartyCodes> byCode = "BY";
        Assert.True(byCode.TryGetEnum<TestPartyEnum>(out var value));
        Assert.Equal(TestPartyEnum.Buyer, value);

        Code<TestPartyCodes> suCode = "SU";
        Assert.True(suCode.TryGetEnum<TestPartyEnum>(out var suValue));
        Assert.Equal(TestPartyEnum.SU, suValue);

        Code<TestPartyCodes> unknown = "ZQ";
        Assert.False(unknown.TryGetEnum<TestPartyEnum>(out _));
    }

    [Fact]
    public void List_IsACachedSingletonPerClosedGenericType()
    {
        Assert.Same(Code<TestPartyCodes>.List, Code<TestPartyCodes>.List);
    }

    [Fact]
    public void IsStandardAndDescription_ComeFromCodeListCatalog()
    {
        var previous = CodeList.Catalog;
        try
        {
            CodeList.Catalog = BuildCatalog();

            Code<TestPartyCodes> known = "BY";
            Assert.True(known.IsStandard);
            Assert.True(known.IsStandardIn("D96A"));
            // MetadataCatalog falls back to the nearest lower loaded version, so a later version
            // than what's loaded still resolves; an earlier one (with nothing to fall back to) does not.
            Assert.True(known.IsStandardIn("D01B"));
            Assert.False(known.IsStandardIn("D93A"));
            Assert.Equal("Buyer", known.Description);

            Code<TestPartyCodes> unknown = "ZQ";
            Assert.False(unknown.IsStandard);
            Assert.Null(unknown.Description);
        }
        finally
        {
            CodeList.Catalog = previous;
        }
    }

    [Fact]
    public void IsStandard_IsFalseWhenNoListIsLoaded()
    {
        var previous = CodeList.Catalog;
        try
        {
            CodeList.Catalog = new MetadataCatalog();

            Code<TestPartyCodes> code = "BY";
            Assert.False(code.IsStandard);
            Assert.Null(code.Description);
        }
        finally
        {
            CodeList.Catalog = previous;
        }
    }
}
