using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class S4ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S4A*2V8tqT*Scm**K*n*2*N*tZU6T5CcW64hk2OdZ*b**";

		var expected = new S4A_AssuranceHeaderLevel2()
		{
			SecurityVersionReleaseIdentifierCode = "2V8tqT",
			BusinessPurposeOfAssurance = "Scm",
			ComputationMethods = null,
			DomainOfComputationOfAssurance = "K",
			AssuranceOriginator = "n",
			AssuranceRecipient = "2",
			AssuranceReferenceNumber = "N",
			DateTimeReference = "tZU6T5CcW64hk2OdZ",
			AssuranceText = "b",
			CertificateLookUpInformation = null,
			AssuranceTokenParameters = null,
		};

		var actual = Map.MapObject<S4A_AssuranceHeaderLevel2>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2V8tqT", true)]
	public void Validation_RequiredSecurityVersionReleaseIdentifierCode(string securityVersionReleaseIdentifierCode, bool isValidExpected)
	{
		var subject = new S4A_AssuranceHeaderLevel2();
		//Required fields
		subject.BusinessPurposeOfAssurance = "Scm";
		subject.ComputationMethods = new C034_ComputationMethods();
		subject.DomainOfComputationOfAssurance = "K";
		//Test Parameters
		subject.SecurityVersionReleaseIdentifierCode = securityVersionReleaseIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Scm", true)]
	public void Validation_RequiredBusinessPurposeOfAssurance(string businessPurposeOfAssurance, bool isValidExpected)
	{
		var subject = new S4A_AssuranceHeaderLevel2();
		//Required fields
		subject.SecurityVersionReleaseIdentifierCode = "2V8tqT";
		subject.ComputationMethods = new C034_ComputationMethods();
		subject.DomainOfComputationOfAssurance = "K";
		//Test Parameters
		subject.BusinessPurposeOfAssurance = businessPurposeOfAssurance;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredComputationMethods(string computationMethods, bool isValidExpected)
	{
		var subject = new S4A_AssuranceHeaderLevel2();
		//Required fields
		subject.SecurityVersionReleaseIdentifierCode = "2V8tqT";
		subject.BusinessPurposeOfAssurance = "Scm";
		subject.DomainOfComputationOfAssurance = "K";
		//Test Parameters
		if (computationMethods != "") 
			subject.ComputationMethods = new C034_ComputationMethods();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredDomainOfComputationOfAssurance(string domainOfComputationOfAssurance, bool isValidExpected)
	{
		var subject = new S4A_AssuranceHeaderLevel2();
		//Required fields
		subject.SecurityVersionReleaseIdentifierCode = "2V8tqT";
		subject.BusinessPurposeOfAssurance = "Scm";
		subject.ComputationMethods = new C034_ComputationMethods();
		//Test Parameters
		subject.DomainOfComputationOfAssurance = domainOfComputationOfAssurance;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
