using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class ICDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ICD++";

		var expected = new ICD_InsuranceCoverDescription()
		{
			InsuranceCoverType = null,
			InsuranceCoverDetails = null,
		};

		var actual = Map.MapObject<ICD_InsuranceCoverDescription>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredInsuranceCoverType(string insuranceCoverType, bool isValidExpected)
	{
		var subject = new ICD_InsuranceCoverDescription();
		//Required fields
		subject.InsuranceCoverDetails = new C331_InsuranceCoverDetails();
		//Test Parameters
		if (insuranceCoverType != "") 
			subject.InsuranceCoverType = new C330_InsuranceCoverType();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredInsuranceCoverDetails(string insuranceCoverDetails, bool isValidExpected)
	{
		var subject = new ICD_InsuranceCoverDescription();
		//Required fields
		subject.InsuranceCoverType = new C330_InsuranceCoverType();
		//Test Parameters
		if (insuranceCoverDetails != "") 
			subject.InsuranceCoverDetails = new C331_InsuranceCoverDetails();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
