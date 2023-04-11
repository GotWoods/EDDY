using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SETests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "SE*1*qS2d";

        var expected = new SE_TransactionSetTrailer()
        {
            NumberOfIncludedSegments = 1,
            TransactionSetControlNumber = "qS2d",
        };

        var actual = Map.MapObject<SE_TransactionSetTrailer>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true)]
    public void Validation_RequiredNumberOfIncludedSegments(int numberOfIncludedSegments, bool isValidExpected)
    {
        var subject = new SE_TransactionSetTrailer();
        subject.TransactionSetControlNumber = "1234";
        if (numberOfIncludedSegments > 0)
            subject.NumberOfIncludedSegments = numberOfIncludedSegments;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("1234", true)]
    public void Validation_RequiredTransactionSetControlNumber(string transactionSetControlNumber, bool isValidExpected)
    {
        var subject = new SE_TransactionSetTrailer();
        subject.NumberOfIncludedSegments = 1;
        subject.TransactionSetControlNumber = transactionSetControlNumber;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}