using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class APETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "APE*wl7*a*l*4*v";

		var expected = new APE_AssuranceProtocolError()
		{
			BusinessPurposeOfAssuranceCode = "wl7",
			DomainOfComputationOfAssuranceCode = "a",
			SecurityOrAssuranceProtocolErrorCode = "l",
			AssuranceOriginator = "4",
			AssuranceRecipient = "v",
		};

		var actual = Map.MapObject<APE_AssuranceProtocolError>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wl7", true)]
	public void Validation_RequiredBusinessPurposeOfAssuranceCode(string businessPurposeOfAssuranceCode, bool isValidExpected)
	{
		var subject = new APE_AssuranceProtocolError();
		//Required fields
		subject.DomainOfComputationOfAssuranceCode = "a";
		subject.SecurityOrAssuranceProtocolErrorCode = "l";
		//Test Parameters
		subject.BusinessPurposeOfAssuranceCode = businessPurposeOfAssuranceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredDomainOfComputationOfAssuranceCode(string domainOfComputationOfAssuranceCode, bool isValidExpected)
	{
		var subject = new APE_AssuranceProtocolError();
		//Required fields
		subject.BusinessPurposeOfAssuranceCode = "wl7";
		subject.SecurityOrAssuranceProtocolErrorCode = "l";
		//Test Parameters
		subject.DomainOfComputationOfAssuranceCode = domainOfComputationOfAssuranceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredSecurityOrAssuranceProtocolErrorCode(string securityOrAssuranceProtocolErrorCode, bool isValidExpected)
	{
		var subject = new APE_AssuranceProtocolError();
		//Required fields
		subject.BusinessPurposeOfAssuranceCode = "wl7";
		subject.DomainOfComputationOfAssuranceCode = "a";
		//Test Parameters
		subject.SecurityOrAssuranceProtocolErrorCode = securityOrAssuranceProtocolErrorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
