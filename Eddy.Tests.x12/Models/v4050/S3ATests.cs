using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;
using Eddy.x12.Models.v4050.Composites;

namespace Eddy.x12.Tests.Models.v4050;

public class S3ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S3A*tKB36I*5Lr**E*7*u*R*1AzkuT8ptaWNTiYEX*B**";

		var expected = new S3A_AssuranceHeaderLevel1()
		{
			SecurityVersionReleaseIdentifierCode = "tKB36I",
			BusinessPurposeOfAssurance = "5Lr",
			ComputationMethods = null,
			DomainOfComputationOfAssurance = "E",
			AssuranceOriginator = "7",
			AssuranceRecipient = "u",
			AssuranceReferenceNumber = "R",
			DateTimeStamp = "1AzkuT8ptaWNTiYEX",
			AssuranceText = "B",
			CertificateLookUpInformation = null,
			AssuranceTokenParameters = null,
		};

		var actual = Map.MapObject<S3A_AssuranceHeaderLevel1>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tKB36I", true)]
	public void Validation_RequiredSecurityVersionReleaseIdentifierCode(string securityVersionReleaseIdentifierCode, bool isValidExpected)
	{
		var subject = new S3A_AssuranceHeaderLevel1();
		//Required fields
		subject.BusinessPurposeOfAssurance = "5Lr";
		subject.ComputationMethods = new C034_ComputationMethods();
		subject.DomainOfComputationOfAssurance = "E";
		//Test Parameters
		subject.SecurityVersionReleaseIdentifierCode = securityVersionReleaseIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5Lr", true)]
	public void Validation_RequiredBusinessPurposeOfAssurance(string businessPurposeOfAssurance, bool isValidExpected)
	{
		var subject = new S3A_AssuranceHeaderLevel1();
		//Required fields
		subject.SecurityVersionReleaseIdentifierCode = "tKB36I";
		subject.ComputationMethods = new C034_ComputationMethods();
		subject.DomainOfComputationOfAssurance = "E";
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
		subject.SecurityVersionReleaseIdentifierCode = "tKB36I";
		subject.BusinessPurposeOfAssurance = "5Lr";
		subject.DomainOfComputationOfAssurance = "E";
		//Test Parameters
		if (computationMethods != "") 
			subject.ComputationMethods = new C034_ComputationMethods();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredDomainOfComputationOfAssurance(string domainOfComputationOfAssurance, bool isValidExpected)
	{
		var subject = new S3A_AssuranceHeaderLevel1();
		//Required fields
		subject.SecurityVersionReleaseIdentifierCode = "tKB36I";
		subject.BusinessPurposeOfAssurance = "5Lr";
		subject.ComputationMethods = new C034_ComputationMethods();
		//Test Parameters
		subject.DomainOfComputationOfAssurance = domainOfComputationOfAssurance;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
