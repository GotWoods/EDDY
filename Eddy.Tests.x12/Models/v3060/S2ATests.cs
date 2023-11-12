using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3060.Composites;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class S2ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S2A*fDo**A*K*I*i*A6xwvymKyksEHqbBE*z**9";

		var expected = new S2A_AssuranceLevel2()
		{
			BusinessPurposeOfAssurance = "fDo",
			ComputationMethods = null,
			DomainOfComputationOfAssuranceDigest = "A",
			AssuranceOriginator = "K",
			AssuranceRecipient = "I",
			AssuranceReferenceNumber = "i",
			DateTimeReference = "A6xwvymKyksEHqbBE",
			AssuranceText = "z",
			AssuranceTokenParameters = null,
			AssuranceDigest = "9",
		};

		var actual = Map.MapObject<S2A_AssuranceLevel2>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fDo", true)]
	public void Validation_RequiredBusinessPurposeOfAssurance(string businessPurposeOfAssurance, bool isValidExpected)
	{
		var subject = new S2A_AssuranceLevel2();
		//Required fields
		subject.ComputationMethods = new C034_ComputationMethods();
		subject.DomainOfComputationOfAssuranceDigest = "A";
		//Test Parameters
		subject.BusinessPurposeOfAssurance = businessPurposeOfAssurance;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredComputationMethods(string computationMethods, bool isValidExpected)
	{
		var subject = new S2A_AssuranceLevel2();
		//Required fields
		subject.BusinessPurposeOfAssurance = "fDo";
		subject.DomainOfComputationOfAssuranceDigest = "A";
		//Test Parameters
		if (computationMethods != "") 
			subject.ComputationMethods = new C034_ComputationMethods();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredDomainOfComputationOfAssuranceDigest(string domainOfComputationOfAssuranceDigest, bool isValidExpected)
	{
		var subject = new S2A_AssuranceLevel2();
		//Required fields
		subject.BusinessPurposeOfAssurance = "fDo";
		subject.ComputationMethods = new C034_ComputationMethods();
		//Test Parameters
		subject.DomainOfComputationOfAssuranceDigest = domainOfComputationOfAssuranceDigest;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
