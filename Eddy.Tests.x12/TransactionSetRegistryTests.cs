namespace Eddy.x12.Tests;

public class TransactionSetRegistryTests
{
    static TransactionSetRegistryTests()
    {
        // TransactionSetRegistry only auto-registers assemblies that are already loaded into the
        // AppDomain. The domain model assembly is only referenced at compile time by this test project
        // (nothing here uses one of its types directly), so force it to load before resolving anything.
        // (A bare `typeof(...)` reference is not enough to reliably force the load before the class is
        // first used -- an explicit Assembly.Load is.)
        System.Reflection.Assembly.Load(new System.Reflection.AssemblyName("Eddy.x12.DomainModels.CommunicationsAndControls"));
    }


    [Fact]
    public void ResolvesExactVersionMatch()
    {
        var type = TransactionSetRegistry.Resolve("997", "004010");

        Assert.NotNull(type);
        Assert.Equal("Edi997_FunctionalAcknowledgment", type.Name);
    }

    [Fact]
    public void AcceptsFourDigitAndFiveDigitVersionSpellings()
    {
        var fourDigit = TransactionSetRegistry.Resolve("997", "4010");
        var fiveDigitIsaStyle = TransactionSetRegistry.Resolve("997", "00401");

        Assert.NotNull(fourDigit);
        Assert.NotNull(fiveDigitIsaStyle);
        Assert.Same(fourDigit, fiveDigitIsaStyle);
    }

    [Fact]
    public void FallsBackToHighestRegisteredVersionBelowTheRequestedOne()
    {
        // v4020 and v4030 are both registered for 997; nothing is registered at 4025, so it should fall
        // back down to v4020 rather than up to v4030 or returning null.
        var type = TransactionSetRegistry.Resolve("997", "4025");

        Assert.NotNull(type);
        Assert.Equal("Edi997_FunctionalAcknowledgment", type.Name);
        Assert.EndsWith(".v4020", type.Namespace);
    }

    [Fact]
    public void ReturnsNullWhenNothingIsRegisteredBelowTheRequestedVersion()
    {
        var type = TransactionSetRegistry.Resolve("997", "1000");

        Assert.Null(type);
    }

    [Fact]
    public void ReturnsNullForAnUnregisteredCode()
    {
        var type = TransactionSetRegistry.Resolve("NOSUCHCODE", "4010");

        Assert.Null(type);
    }

    [Fact]
    public void AllListsRegisteredTransactionSets()
    {
        var all = TransactionSetRegistry.All;

        Assert.Contains(all, i => i.Code == "997" && i.Version == "4010");
    }

    [Theory]
    [InlineData("004010", "4010")]
    [InlineData("4010", "4010")]
    [InlineData("00401", "4010")]
    [InlineData("8010", "8010")]
    public void NormalizeVersionProducesTheFourDigitForm(string input, string expected)
    {
        Assert.Equal(expected, TransactionSetRegistry.NormalizeVersion(input));
    }
}
