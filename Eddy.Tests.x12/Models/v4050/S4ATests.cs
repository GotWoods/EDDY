using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class S4ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S4A*RriJEP*MyQ**s*5*S*K*XylrmPwfZEOUtOQfx*5**";

		var expected = new S4A_AssuranceHeaderLevel2()
		{
			SecurityVersionReleaseIdentifierCode = "RriJEP",
			BusinessPurposeOfAssurance = "MyQ",
			ComputationMethods = null,
			DomainOfComputationOfAssurance = "s",
			AssuranceOriginator = "5",
			AssuranceRecipient = "S",
			AssuranceReferenceNumber = "K",
			DateTimeStamp = "XylrmPwfZEOUtOQfx",
			AssuranceText = "5",
			CertificateLookUpInformation = null,
			AssuranceTokenParameters = null,
		};

		var actual = Map.MapObject<S4A_AssuranceHeaderLevel2>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RriJEP", true)]
	public void Validation_RequiredSecurityVersionReleaseIdentifierCode(string securityVersionReleaseIdentifierCode, bool isValidExpected)
	{
		var subject = new S4A_AssuranceHeaderLevel2();
		//Required fields
		subject.BusinessPurposeOfAssurance = "MyQ";
		subject.ComputationMethods = new C034_ComputationMethods();
		subject.DomainOfComputationOfAssurance = "s";
		//Test Parameters
		subject.SecurityVersionReleaseIdentifierCode = securityVersionReleaseIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MyQ", true)]
	public void Validation_RequiredBusinessPurposeOfAssurance(string businessPurposeOfAssurance, bool isValidExpected)
	{
		var subject = new S4A_AssuranceHeaderLevel2();
		//Required fields
		subject.SecurityVersionReleaseIdentifierCode = "RriJEP";
		subject.ComputationMethods = new C034_ComputationMethods();
		subject.DomainOfComputationOfAssurance = "s";
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
		subject.SecurityVersionReleaseIdentifierCode = "RriJEP";
		subject.BusinessPurposeOfAssurance = "MyQ";
		subject.DomainOfComputationOfAssurance = "s";
		//Test Parameters
		if (computationMethods != "") 
			subject.ComputationMethods = new C034_ComputationMethods();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredDomainOfComputationOfAssurance(string domainOfComputationOfAssurance, bool isValidExpected)
	{
		var subject = new S4A_AssuranceHeaderLevel2();
		//Required fields
		subject.SecurityVersionReleaseIdentifierCode = "RriJEP";
		subject.BusinessPurposeOfAssurance = "MyQ";
		subject.ComputationMethods = new C034_ComputationMethods();
		//Test Parameters
		subject.DomainOfComputationOfAssurance = domainOfComputationOfAssurance;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
