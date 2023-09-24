using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class STTests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "ST*4xh*EE5m*n";

        var expected = new ST_TransactionSetHeader()
        {
            TransactionSetIdentifierCode = "4xh",
            TransactionSetControlNumber = "EE5m",
            ImplementationConventionReference = "n",
        };

        var actual = Map.MapObject<ST_TransactionSetHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("123", true)]
    public void Validation_RequiredTransactionSetIdentifierCode(string transactionSetIdentifierCode, bool isValidExpected)
    {
        var subject = new ST_TransactionSetHeader();
        subject.TransactionSetControlNumber = "1234";
        subject.TransactionSetIdentifierCode = transactionSetIdentifierCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("1234", true)]
    public void Validation_RequiredTransactionSetControlNumber(string transactionSetControlNumber, bool isValidExpected)
    {
        var subject = new ST_TransactionSetHeader();
        subject.TransactionSetIdentifierCode = "123";
        subject.TransactionSetControlNumber = transactionSetControlNumber;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}