using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class GETests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "GE*1*2";

        var expected = new GE_FunctionalGroupTrailer()
        {
            NumberOfTransactionSetsIncluded = 1,
            GroupControlNumber = 2,
        };

        var actual = Map.MapObject<GE_FunctionalGroupTrailer>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true)]
    public void Validation_RequiredNumberOfTransactionSetsIncluded(int numberOfTransactionSetsIncluded, bool isValidExpected)
    {
        var subject = new GE_FunctionalGroupTrailer();

        subject.GroupControlNumber = 1;

        if (numberOfTransactionSetsIncluded > 0)
            subject.NumberOfTransactionSetsIncluded = numberOfTransactionSetsIncluded;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true)]
    public void Validation_RequiredGroupControlNumber(int groupControlNumber, bool isValidExpected)
    {
        var subject = new GE_FunctionalGroupTrailer();
        subject.NumberOfTransactionSetsIncluded = 1;

        if (groupControlNumber > 0)
            subject.GroupControlNumber = groupControlNumber;

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}