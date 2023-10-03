using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v4010.Composites;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class S2ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S2A*jDB**p*6*K*S*OIQzyZsMUvJq5ypHS*4**U";

		var expected = new S2A_AssuranceLevel2()
		{
			BusinessPurposeOfAssurance = "jDB",
			ComputationMethods = null,
			DomainOfComputationOfAssurance = "p",
			AssuranceOriginator = "6",
			AssuranceRecipient = "K",
			AssuranceReferenceNumber = "S",
			DateTimeReference = "OIQzyZsMUvJq5ypHS",
			AssuranceText = "4",
			AssuranceTokenParameters = null,
			AssuranceDigest = "U",
		};

		var actual = Map.MapObject<S2A_AssuranceLevel2>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jDB", true)]
	public void Validation_RequiredBusinessPurposeOfAssurance(string businessPurposeOfAssurance, bool isValidExpected)
	{
		var subject = new S2A_AssuranceLevel2();
		//Required fields
		subject.ComputationMethods = new C034_ComputationMethods();
		subject.DomainOfComputationOfAssurance = "p";
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
		subject.BusinessPurposeOfAssurance = "jDB";
		subject.DomainOfComputationOfAssurance = "p";
		//Test Parameters
		if (computationMethods != "") 
			subject.ComputationMethods = new C034_ComputationMethods();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredDomainOfComputationOfAssurance(string domainOfComputationOfAssurance, bool isValidExpected)
	{
		var subject = new S2A_AssuranceLevel2();
		//Required fields
		subject.BusinessPurposeOfAssurance = "jDB";
		subject.ComputationMethods = new C034_ComputationMethods();
		//Test Parameters
		subject.DomainOfComputationOfAssurance = domainOfComputationOfAssurance;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
