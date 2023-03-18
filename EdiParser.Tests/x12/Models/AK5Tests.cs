using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class AK5Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "AK5*A*UFO*EcB*rKt*gBE*BoK";

        var expected = new AK5_TransactionSetResponseTrailer()
        {
            TransactionSetAcknowledgmentCode = "A",
            TransactionSetSyntaxErrorCode = "UFO",
            TransactionSetSyntaxErrorCode2 = "EcB",
            TransactionSetSyntaxErrorCode3 = "rKt",
            TransactionSetSyntaxErrorCode4 = "gBE",
            TransactionSetSyntaxErrorCode5 = "BoK",
        };

        var actual = Map.MapObject<AK5_TransactionSetResponseTrailer>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("A", true)]
    public void Validatation_RequiredTransactionSetAcknowledgmentCode(string transactionSetAcknowledgmentCode, bool isValidExpected)
    {
        var subject = new AK5_TransactionSetResponseTrailer();
        subject.TransactionSetAcknowledgmentCode = transactionSetAcknowledgmentCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}