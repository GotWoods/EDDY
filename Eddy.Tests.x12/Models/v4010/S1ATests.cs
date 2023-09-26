using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class S1ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S1A*s55**f*s*S*E*eLulxKHrceLaftkc4*p**A";

		var expected = new S1A_AssuranceLevel1()
		{
			BusinessPurposeOfAssurance = "s55",
			ComputationMethods = null,
			DomainOfComputationOfAssurance = "f",
			AssuranceOriginator = "s",
			AssuranceRecipient = "S",
			AssuranceReferenceNumber = "E",
			DateTimeReference = "eLulxKHrceLaftkc4",
			AssuranceText = "p",
			AssuranceTokenParameters = null,
			AssuranceDigest = "A",
		};

		var actual = Map.MapObject<S1A_AssuranceLevel1>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s55", true)]
	public void Validation_RequiredBusinessPurposeOfAssurance(string businessPurposeOfAssurance, bool isValidExpected)
	{
		var subject = new S1A_AssuranceLevel1();
		//Required fields
		subject.ComputationMethods = new C034_ComputationMethods();
		subject.DomainOfComputationOfAssurance = "f";
		//Test Parameters
		subject.BusinessPurposeOfAssurance = businessPurposeOfAssurance;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredComputationMethods(string computationMethods, bool isValidExpected)
	{
		var subject = new S1A_AssuranceLevel1();
		//Required fields
		subject.BusinessPurposeOfAssurance = "s55";
		subject.DomainOfComputationOfAssurance = "f";
		//Test Parameters
		if (computationMethods != "") 
			subject.ComputationMethods = new C034_ComputationMethods();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredDomainOfComputationOfAssurance(string domainOfComputationOfAssurance, bool isValidExpected)
	{
		var subject = new S1A_AssuranceLevel1();
		//Required fields
		subject.BusinessPurposeOfAssurance = "s55";
		subject.ComputationMethods = new C034_ComputationMethods();
		//Test Parameters
		subject.DomainOfComputationOfAssurance = domainOfComputationOfAssurance;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
