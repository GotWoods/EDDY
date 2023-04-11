using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class AK2Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "AK2*IBD*82AECMFHJ*oTXhNDDQBJNpvLc6IOemEkOy2p0wLW2HNKk";

        var expected = new AK2_TransactionSetResponseHeader()
        {
            TransactionSetIdentifierCode = "IBD",
            TransactionSetControlNumber = "82AECMFHJ",
            ImplementationConventionReference = "oTXhNDDQBJNpvLc6IOemEkOy2p0wLW2HNKk",
        };

        var actual = Map.MapObject<AK2_TransactionSetResponseHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("IBD", true)]
    public void Validation_RequiredTransactionSetIdentifierCode(string transactionSetIdentifierCode, bool isValidExpected)
    {
        var subject = new AK2_TransactionSetResponseHeader();
        subject.TransactionSetControlNumber = "82AECMFHJ";
        subject.TransactionSetIdentifierCode = transactionSetIdentifierCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("82AECMFHJ", true)]
    public void Validation_RequiredTransactionSetControlNumber(string transactionSetControlNumber, bool isValidExpected)
    {
        var subject = new AK2_TransactionSetResponseHeader();
        subject.TransactionSetIdentifierCode = "IBD";
        subject.TransactionSetControlNumber = transactionSetControlNumber;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}