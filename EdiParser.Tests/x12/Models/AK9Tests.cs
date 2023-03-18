using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class AK9Tests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        string x12Line = "AK9*2*1*3*3*N4l*F5V*lOQ*Esi*YuA";

        var expected = new AK9_FunctionalGroupResponseTrailer()
        {
            FunctionalGroupAcknowledgeCode = "2",
            NumberOfTransactionSetsIncluded = 1,
            NumberOfReceivedTransactionSets = 3,
            NumberOfAcceptedTransactionSets = 3,
            FunctionalGroupSyntaxErrorCode = "N4l",
            FunctionalGroupSyntaxErrorCode2 = "F5V",
            FunctionalGroupSyntaxErrorCode3 = "lOQ",
            FunctionalGroupSyntaxErrorCode4 = "Esi",
            FunctionalGroupSyntaxErrorCode5 = "YuA",
        };

        var actual = Map.MapObject<AK9_FunctionalGroupResponseTrailer>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }
    [Theory]
    [InlineData("", false)]
    [InlineData("2", true)]
    public void Validatation_RequiredFunctionalGroupAcknowledgeCode(string functionalGroupAcknowledgeCode, bool isValidExpected)
    {
        var subject = new AK9_FunctionalGroupResponseTrailer();
        subject.NumberOfTransactionSetsIncluded = 1;
        subject.NumberOfReceivedTransactionSets = 1;
        subject.NumberOfAcceptedTransactionSets = 1;
        subject.FunctionalGroupAcknowledgeCode = functionalGroupAcknowledgeCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true)]
    public void Validatation_RequiredNumberOfTransactionSetsIncluded(int numberOfTransactionSetsIncluded, bool isValidExpected)
    {
        var subject = new AK9_FunctionalGroupResponseTrailer();
        subject.NumberOfReceivedTransactionSets = 1;
        subject.NumberOfAcceptedTransactionSets = 1;
        subject.FunctionalGroupAcknowledgeCode = "B";
        if (numberOfTransactionSetsIncluded > 0)
            subject.NumberOfTransactionSetsIncluded = numberOfTransactionSetsIncluded;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true)]
    public void Validatation_RequiredNumberOfReceivedTransactionSets(int numberOfReceivedTransactionSets, bool isValidExpected)
    {
        var subject = new AK9_FunctionalGroupResponseTrailer();
        subject.NumberOfTransactionSetsIncluded = 1;
        subject.NumberOfAcceptedTransactionSets = 1;
        subject.FunctionalGroupAcknowledgeCode = "B";

        if (numberOfReceivedTransactionSets > 0)
            subject.NumberOfReceivedTransactionSets = numberOfReceivedTransactionSets;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
    [Theory]
    [InlineData(0, false)]
    [InlineData(1, true)]
    public void Validatation_RequiredNumberOfAcceptedTransactionSets(int numberOfAcceptedTransactionSets, bool isValidExpected)
    {
        var subject = new AK9_FunctionalGroupResponseTrailer();
        subject.NumberOfTransactionSetsIncluded = 1;
        subject.NumberOfReceivedTransactionSets = 1;
        subject.FunctionalGroupAcknowledgeCode = "B";


        if (numberOfAcceptedTransactionSets > 0)
            subject.NumberOfAcceptedTransactionSets = numberOfAcceptedTransactionSets;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}