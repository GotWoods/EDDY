using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4010.Composites;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class S3ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S3A*spHiBJ*xoq**R*R*M*l*3EEQW3B52ceKf3Buc*X**";

		var expected = new S3A_AssuranceHeaderLevel1()
		{
			SecurityVersionReleaseIdentifierCode = "spHiBJ",
			BusinessPurposeOfAssurance = "xoq",
			ComputationMethods = null,
			DomainOfComputationOfAssurance = "R",
			AssuranceOriginator = "R",
			AssuranceRecipient = "M",
			AssuranceReferenceNumber = "l",
			DateTimeReference = "3EEQW3B52ceKf3Buc",
			AssuranceText = "X",
			CertificateLookUpInformation = null,
			AssuranceTokenParameters = null,
		};

		var actual = Map.MapObject<S3A_AssuranceHeaderLevel1>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("spHiBJ", true)]
	public void Validation_RequiredSecurityVersionReleaseIdentifierCode(string securityVersionReleaseIdentifierCode, bool isValidExpected)
	{
		var subject = new S3A_AssuranceHeaderLevel1();
		//Required fields
		subject.BusinessPurposeOfAssurance = "xoq";
		subject.ComputationMethods = new C034_ComputationMethods();
		subject.DomainOfComputationOfAssurance = "R";
		//Test Parameters
		subject.SecurityVersionReleaseIdentifierCode = securityVersionReleaseIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xoq", true)]
	public void Validation_RequiredBusinessPurposeOfAssurance(string businessPurposeOfAssurance, bool isValidExpected)
	{
		var subject = new S3A_AssuranceHeaderLevel1();
		//Required fields
		subject.SecurityVersionReleaseIdentifierCode = "spHiBJ";
		subject.ComputationMethods = new C034_ComputationMethods();
		subject.DomainOfComputationOfAssurance = "R";
		//Test Parameters
		subject.BusinessPurposeOfAssurance = businessPurposeOfAssurance;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredComputationMethods(string computationMethods, bool isValidExpected)
	{
		var subject = new S3A_AssuranceHeaderLevel1();
		//Required fields
		subject.SecurityVersionReleaseIdentifierCode = "spHiBJ";
		subject.BusinessPurposeOfAssurance = "xoq";
		subject.DomainOfComputationOfAssurance = "R";
		//Test Parameters
		if (computationMethods != "") 
			subject.ComputationMethods = new C034_ComputationMethods();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredDomainOfComputationOfAssurance(string domainOfComputationOfAssurance, bool isValidExpected)
	{
		var subject = new S3A_AssuranceHeaderLevel1();
		//Required fields
		subject.SecurityVersionReleaseIdentifierCode = "spHiBJ";
		subject.BusinessPurposeOfAssurance = "xoq";
		subject.ComputationMethods = new C034_ComputationMethods();
		//Test Parameters
		subject.DomainOfComputationOfAssurance = domainOfComputationOfAssurance;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
