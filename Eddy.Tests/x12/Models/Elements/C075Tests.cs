using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models.Elements;

public class C075Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "Nj*vh*MK";

        var expected = new C075_CompositeAddedFlavor()
        {
            AddedFlavor = "Nj",
            AddedFlavor2 = "vh",
            AddedFlavor3 = "MK",
        };

        var actual = Map.MapObject<C075_CompositeAddedFlavor>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("Nj", true)]
    public void Validation_RequiredAddedFlavor(string addedFlavor, bool isValidExpected)
    {
        var subject = new C075_CompositeAddedFlavor();
        subject.AddedFlavor = addedFlavor;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", "", true)]
    [InlineData("", "vh", true)]
    [InlineData("MK", "", false)]
    public void Validation_ARequiresBAddedFlavor3(string addedFlavor3, string addedFlavor2, bool isValidExpected)
    {
        var subject = new C075_CompositeAddedFlavor();
        subject.AddedFlavor = "Nj";
        subject.AddedFlavor3 = addedFlavor3;
        subject.AddedFlavor2 = addedFlavor2;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
    }

}