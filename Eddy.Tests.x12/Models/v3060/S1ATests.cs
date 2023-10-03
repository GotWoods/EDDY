using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;
using Eddy.x12.Models.v3060.Composites;

namespace Eddy.x12.Tests.Models.v3060;

public class S1ATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "S1A*slH**0*w*p*t*v9xXFDZYVCGl365hZ*k**Z";

		var expected = new S1A_AssuranceLevel1()
		{
			BusinessPurposeOfAssurance = "slH",
			ComputationMethods = null,
			DomainOfComputationOfAssuranceDigest = "0",
			AssuranceOriginator = "w",
			AssuranceRecipient = "p",
			AssuranceReferenceNumber = "t",
			DateTimeReference = "v9xXFDZYVCGl365hZ",
			AssuranceText = "k",
			AssuranceTokenParameters = null,
			AssuranceDigest = "Z",
		};

		var actual = Map.MapObject<S1A_AssuranceLevel1>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("slH", true)]
	public void Validation_RequiredBusinessPurposeOfAssurance(string businessPurposeOfAssurance, bool isValidExpected)
	{
		var subject = new S1A_AssuranceLevel1();
		//Required fields
		subject.ComputationMethods = new C034_ComputationMethods();
		subject.DomainOfComputationOfAssuranceDigest = "0";
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
		subject.BusinessPurposeOfAssurance = "slH";
		subject.DomainOfComputationOfAssuranceDigest = "0";
		//Test Parameters
		if (computationMethods != "") 
			subject.ComputationMethods = new C034_ComputationMethods();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredDomainOfComputationOfAssuranceDigest(string domainOfComputationOfAssuranceDigest, bool isValidExpected)
	{
		var subject = new S1A_AssuranceLevel1();
		//Required fields
		subject.BusinessPurposeOfAssurance = "slH";
		subject.ComputationMethods = new C034_ComputationMethods();
		//Test Parameters
		subject.DomainOfComputationOfAssuranceDigest = domainOfComputationOfAssuranceDigest;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
