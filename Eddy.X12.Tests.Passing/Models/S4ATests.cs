using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class S4ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S4A*BjUB3d*5se**z*b*2*d*E2bKFUak7msro1ZSt*j**";

		var expected = new S4A_AssuranceHeaderLevel2()
		{
			SecurityVersionReleaseIdentifierCode = "BjUB3d",
			BusinessPurposeOfAssuranceCode = "5se",
			ComputationMethods = null,
			DomainOfComputationOfAssuranceCode = "z",
			AssuranceOriginator = "b",
			AssuranceRecipient = "2",
			AssuranceReferenceNumber = "d",
			DateTimeStamp = "E2bKFUak7msro1ZSt",
			AssuranceText = "j",
			CertificateLookUpInformation = null,
			AssuranceTokenParameters = null,
		};

		var actual = Map.MapObject<S4A_AssuranceHeaderLevel2>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BjUB3d", true)]
	public void Validation_RequiredSecurityVersionReleaseIdentifierCode(string securityVersionReleaseIdentifierCode, bool isValidExpected)
	{
		var subject = new S4A_AssuranceHeaderLevel2();
		subject.BusinessPurposeOfAssuranceCode = "5se";
		subject.ComputationMethods = null;
		subject.DomainOfComputationOfAssuranceCode = "z";
		subject.SecurityVersionReleaseIdentifierCode = securityVersionReleaseIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5se", true)]
	public void Validation_RequiredBusinessPurposeOfAssuranceCode(string businessPurposeOfAssuranceCode, bool isValidExpected)
	{
		var subject = new S4A_AssuranceHeaderLevel2();
		subject.SecurityVersionReleaseIdentifierCode = "BjUB3d";
		subject.ComputationMethods = null;
		subject.DomainOfComputationOfAssuranceCode = "z";
		subject.BusinessPurposeOfAssuranceCode = businessPurposeOfAssuranceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AA", true)]
	public void Validation_RequiredComputationMethods(string computationMethods, bool isValidExpected)
	{
		var subject = new S4A_AssuranceHeaderLevel2();
		subject.SecurityVersionReleaseIdentifierCode = "BjUB3d";
		subject.BusinessPurposeOfAssuranceCode = "5se";
		subject.DomainOfComputationOfAssuranceCode = "z";

        if (computationMethods != "")
            subject.ComputationMethods = new C034_ComputationMethods() { AssuranceAlgorithmCode = computationMethods };
        
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredDomainOfComputationOfAssuranceCode(string domainOfComputationOfAssuranceCode, bool isValidExpected)
	{
		var subject = new S4A_AssuranceHeaderLevel2();
		subject.SecurityVersionReleaseIdentifierCode = "BjUB3d";
		subject.BusinessPurposeOfAssuranceCode = "5se";
		subject.ComputationMethods = new C034_ComputationMethods();
		subject.DomainOfComputationOfAssuranceCode = domainOfComputationOfAssuranceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
