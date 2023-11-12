using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class APETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "APE*jc2*b*f*M*I";

		var expected = new APE_AssuranceProtocolError()
		{
			BusinessPurposeOfAssurance = "jc2",
			DomainOfComputationOfAssurance = "b",
			SecurityOrAssuranceProtocolErrorCode = "f",
			AssuranceOriginator = "M",
			AssuranceRecipient = "I",
		};

		var actual = Map.MapObject<APE_AssuranceProtocolError>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jc2", true)]
	public void Validation_RequiredBusinessPurposeOfAssurance(string businessPurposeOfAssurance, bool isValidExpected)
	{
		var subject = new APE_AssuranceProtocolError();
		//Required fields
		subject.DomainOfComputationOfAssurance = "b";
		subject.SecurityOrAssuranceProtocolErrorCode = "f";
		//Test Parameters
		subject.BusinessPurposeOfAssurance = businessPurposeOfAssurance;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredDomainOfComputationOfAssurance(string domainOfComputationOfAssurance, bool isValidExpected)
	{
		var subject = new APE_AssuranceProtocolError();
		//Required fields
		subject.BusinessPurposeOfAssurance = "jc2";
		subject.SecurityOrAssuranceProtocolErrorCode = "f";
		//Test Parameters
		subject.DomainOfComputationOfAssurance = domainOfComputationOfAssurance;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredSecurityOrAssuranceProtocolErrorCode(string securityOrAssuranceProtocolErrorCode, bool isValidExpected)
	{
		var subject = new APE_AssuranceProtocolError();
		//Required fields
		subject.BusinessPurposeOfAssurance = "jc2";
		subject.DomainOfComputationOfAssurance = "b";
		//Test Parameters
		subject.SecurityOrAssuranceProtocolErrorCode = securityOrAssuranceProtocolErrorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
