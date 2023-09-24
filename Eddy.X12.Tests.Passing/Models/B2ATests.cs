using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class B2ATests
{
    [Fact]
    public void ParseX12B2ALine_ShouldReturnCorrectObject()
    {
        //Arrange
        string x12Line = "B2A*04";

        var expected = new B2A_SetPurpose()
        {
            TransactionSetPurposeCode = "04",
        };

        var actual = Map.MapObject<B2A_SetPurpose>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);

        //Assert
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData(null, false)]
    [InlineData("PP", true)]
    public void Validation_PurposeCodeIsRequired(string purposeCode, bool isValidExpected)
    {
        var subject = new B2A_SetPurpose();
        subject.TransactionSetPurposeCode = purposeCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

}