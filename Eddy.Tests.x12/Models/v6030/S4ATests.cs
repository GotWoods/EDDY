using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v6030.Composites;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class S4ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S4A*yRt8Jx*nib**9*7*G*I*0Sm5vm9b2GtwjV9LX*o**";

		var expected = new S4A_AssuranceHeaderLevel2()
		{
			SecurityVersionReleaseIdentifierCode = "yRt8Jx",
			BusinessPurposeOfAssuranceCode = "nib",
			ComputationMethods = null,
			DomainOfComputationOfAssuranceCode = "9",
			AssuranceOriginator = "7",
			AssuranceRecipient = "G",
			AssuranceReferenceNumber = "I",
			DateTimeStamp = "0Sm5vm9b2GtwjV9LX",
			AssuranceText = "o",
			CertificateLookUpInformation = null,
			AssuranceTokenParameters = null,
		};

		var actual = Map.MapObject<S4A_AssuranceHeaderLevel2>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yRt8Jx", true)]
	public void Validation_RequiredSecurityVersionReleaseIdentifierCode(string securityVersionReleaseIdentifierCode, bool isValidExpected)
	{
		var subject = new S4A_AssuranceHeaderLevel2();
		//Required fields
		subject.BusinessPurposeOfAssuranceCode = "nib";
		subject.ComputationMethods = new C034_ComputationMethods();
		subject.DomainOfComputationOfAssuranceCode = "9";
		//Test Parameters
		subject.SecurityVersionReleaseIdentifierCode = securityVersionReleaseIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nib", true)]
	public void Validation_RequiredBusinessPurposeOfAssuranceCode(string businessPurposeOfAssuranceCode, bool isValidExpected)
	{
		var subject = new S4A_AssuranceHeaderLevel2();
		//Required fields
		subject.SecurityVersionReleaseIdentifierCode = "yRt8Jx";
		subject.ComputationMethods = new C034_ComputationMethods();
		subject.DomainOfComputationOfAssuranceCode = "9";
		//Test Parameters
		subject.BusinessPurposeOfAssuranceCode = businessPurposeOfAssuranceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredComputationMethods(string computationMethods, bool isValidExpected)
	{
		var subject = new S4A_AssuranceHeaderLevel2();
		//Required fields
		subject.SecurityVersionReleaseIdentifierCode = "yRt8Jx";
		subject.BusinessPurposeOfAssuranceCode = "nib";
		subject.DomainOfComputationOfAssuranceCode = "9";
		//Test Parameters
		if (computationMethods != "") 
			subject.ComputationMethods = new C034_ComputationMethods();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredDomainOfComputationOfAssuranceCode(string domainOfComputationOfAssuranceCode, bool isValidExpected)
	{
		var subject = new S4A_AssuranceHeaderLevel2();
		//Required fields
		subject.SecurityVersionReleaseIdentifierCode = "yRt8Jx";
		subject.BusinessPurposeOfAssuranceCode = "nib";
		subject.ComputationMethods = new C034_ComputationMethods();
		//Test Parameters
		subject.DomainOfComputationOfAssuranceCode = domainOfComputationOfAssuranceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
