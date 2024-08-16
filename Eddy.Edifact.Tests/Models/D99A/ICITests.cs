using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99A;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Tests.Models.D99A;

public class ICITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "ICI++";

		var expected = new ICI_InsuranceCoverInformation()
		{
			InsuranceCoverRequirement = null,
			MonetaryAmount = null,
		};

		var actual = Map.MapObject<ICI_InsuranceCoverInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredInsuranceCoverRequirement(string insuranceCoverRequirement, bool isValidExpected)
	{
		var subject = new ICI_InsuranceCoverInformation();
		//Required fields
		//Test Parameters
		if (insuranceCoverRequirement != "") 
			subject.InsuranceCoverRequirement = new E016_InsuranceCoverRequirement();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
