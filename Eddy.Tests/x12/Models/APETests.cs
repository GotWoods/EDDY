using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class APETests
{
    [Fact]
    public void Parse_ShouldReturnCorrectObject()
    {
        var x12Line = "APE*4eo*o*O*s*B";

        var expected = new APE_AssuranceProtocolError
        {
            BusinessPurposeOfAssuranceCode = "4eo",
            DomainOfComputationOfAssuranceCode = "o",
            SecurityOrAssuranceProtocolErrorCode = "O",
            AssuranceOriginator = "s",
            AssuranceRecipient = "B"
        };

        var actual = Map.MapObject<APE_AssuranceProtocolError>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("4eo", true)]
    public void Validatation_RequiredBusinessPurposeOfAssuranceCode(string businessPurposeOfAssuranceCode, bool isValidExpected)
    {
        var subject = new APE_AssuranceProtocolError();
        subject.DomainOfComputationOfAssuranceCode = "o";
        subject.SecurityOrAssuranceProtocolErrorCode = "O";
        subject.BusinessPurposeOfAssuranceCode = businessPurposeOfAssuranceCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("o", true)]
    public void Validatation_RequiredDomainOfComputationOfAssuranceCode(string domainOfComputationOfAssuranceCode, bool isValidExpected)
    {
        var subject = new APE_AssuranceProtocolError();
        subject.BusinessPurposeOfAssuranceCode = "4eo";
        subject.SecurityOrAssuranceProtocolErrorCode = "O";
        subject.DomainOfComputationOfAssuranceCode = domainOfComputationOfAssuranceCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }

    [Theory]
    [InlineData("", false)]
    [InlineData("O", true)]
    public void Validatation_RequiredSecurityOrAssuranceProtocolErrorCode(string securityOrAssuranceProtocolErrorCode, bool isValidExpected)
    {
        var subject = new APE_AssuranceProtocolError();
        subject.BusinessPurposeOfAssuranceCode = "4eo";
        subject.DomainOfComputationOfAssuranceCode = "o";
        subject.SecurityOrAssuranceProtocolErrorCode = securityOrAssuranceProtocolErrorCode;
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
    }
}