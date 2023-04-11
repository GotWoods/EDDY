using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class S3ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S3A*LqJuKa*6yq**o*x*r*k*2fZLVAOkMvp82iBfx*I**";

		var expected = new S3A_AssuranceHeaderLevel1()
		{
			SecurityVersionReleaseIdentifierCode = "LqJuKa",
			BusinessPurposeOfAssuranceCode = "6yq",
			ComputationMethods = null,
			DomainOfComputationOfAssuranceCode = "o",
			AssuranceOriginator = "x",
			AssuranceRecipient = "r",
			AssuranceReferenceNumber = "k",
			DateTimeStamp = "2fZLVAOkMvp82iBfx",
			AssuranceText = "I",
			CertificateLookUpInformation = null,
			AssuranceTokenParameters = null,
		};

		var actual = Map.MapObject<S3A_AssuranceHeaderLevel1>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LqJuKa", true)]
	public void Validation_RequiredSecurityVersionReleaseIdentifierCode(string securityVersionReleaseIdentifierCode, bool isValidExpected)
	{
		var subject = new S3A_AssuranceHeaderLevel1();
		subject.BusinessPurposeOfAssuranceCode = "6yq";
		subject.ComputationMethods = new C034_ComputationMethods();
		subject.DomainOfComputationOfAssuranceCode = "o";
		subject.SecurityVersionReleaseIdentifierCode = securityVersionReleaseIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6yq", true)]
	public void Validation_RequiredBusinessPurposeOfAssuranceCode(string businessPurposeOfAssuranceCode, bool isValidExpected)
	{
		var subject = new S3A_AssuranceHeaderLevel1();
		subject.SecurityVersionReleaseIdentifierCode = "LqJuKa";
		subject.ComputationMethods = new C034_ComputationMethods();
		subject.DomainOfComputationOfAssuranceCode = "o";
		subject.BusinessPurposeOfAssuranceCode = businessPurposeOfAssuranceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("", true)]
	public void Validation_RequiredComputationMethods(C034_ComputationMethods computationMethods, bool isValidExpected)
	{
		var subject = new S3A_AssuranceHeaderLevel1();
		subject.SecurityVersionReleaseIdentifierCode = "LqJuKa";
		subject.BusinessPurposeOfAssuranceCode = "6yq";
		subject.DomainOfComputationOfAssuranceCode = "o";
		subject.ComputationMethods = computationMethods;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredDomainOfComputationOfAssuranceCode(string domainOfComputationOfAssuranceCode, bool isValidExpected)
	{
		var subject = new S3A_AssuranceHeaderLevel1();
		subject.SecurityVersionReleaseIdentifierCode = "LqJuKa";
		subject.BusinessPurposeOfAssuranceCode = "6yq";
		subject.ComputationMethods = new C034_ComputationMethods();
		subject.DomainOfComputationOfAssuranceCode = domainOfComputationOfAssuranceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
