using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class S3ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S3A*Ab8z0W*r0u**r*1*P*K*TqA02JkyqCUR8DLAh*k**";

		var expected = new S3A_AssuranceHeaderLevel1()
		{
			SecurityVersionReleaseIdentifierCode = "Ab8z0W",
			BusinessPurposeOfAssuranceCode = "r0u",
			ComputationMethods = null,
			DomainOfComputationOfAssuranceCode = "r",
			AssuranceOriginator = "1",
			AssuranceRecipient = "P",
			AssuranceReferenceNumber = "K",
			DateTimeStamp = "TqA02JkyqCUR8DLAh",
			AssuranceText = "k",
			CertificateLookUpInformation = null,
			AssuranceTokenParameters = null,
		};

		var actual = Map.MapObject<S3A_AssuranceHeaderLevel1>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ab8z0W", true)]
	public void Validation_RequiredSecurityVersionReleaseIdentifierCode(string securityVersionReleaseIdentifierCode, bool isValidExpected)
	{
		var subject = new S3A_AssuranceHeaderLevel1();
		//Required fields
		subject.BusinessPurposeOfAssuranceCode = "r0u";
		subject.ComputationMethods = new C034_ComputationMethods();
		subject.DomainOfComputationOfAssuranceCode = "r";
		//Test Parameters
		subject.SecurityVersionReleaseIdentifierCode = securityVersionReleaseIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r0u", true)]
	public void Validation_RequiredBusinessPurposeOfAssuranceCode(string businessPurposeOfAssuranceCode, bool isValidExpected)
	{
		var subject = new S3A_AssuranceHeaderLevel1();
		//Required fields
		subject.SecurityVersionReleaseIdentifierCode = "Ab8z0W";
		subject.ComputationMethods = new C034_ComputationMethods();
		subject.DomainOfComputationOfAssuranceCode = "r";
		//Test Parameters
		subject.BusinessPurposeOfAssuranceCode = businessPurposeOfAssuranceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredComputationMethods(string computationMethods, bool isValidExpected)
	{
		var subject = new S3A_AssuranceHeaderLevel1();
		//Required fields
		subject.SecurityVersionReleaseIdentifierCode = "Ab8z0W";
		subject.BusinessPurposeOfAssuranceCode = "r0u";
		subject.DomainOfComputationOfAssuranceCode = "r";
		//Test Parameters
		if (computationMethods != "") 
			subject.ComputationMethods = new C034_ComputationMethods();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredDomainOfComputationOfAssuranceCode(string domainOfComputationOfAssuranceCode, bool isValidExpected)
	{
		var subject = new S3A_AssuranceHeaderLevel1();
		//Required fields
		subject.SecurityVersionReleaseIdentifierCode = "Ab8z0W";
		subject.BusinessPurposeOfAssuranceCode = "r0u";
		subject.ComputationMethods = new C034_ComputationMethods();
		//Test Parameters
		subject.DomainOfComputationOfAssuranceCode = domainOfComputationOfAssuranceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
