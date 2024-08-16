using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E011Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "X:k";

		var expected = new E011_RateClassDetails()
		{
			RateOrTariffClassDescriptionCode = "X",
			ProcessingIndicatorDescriptionCode = "k",
		};

		var actual = Map.MapComposite<E011_RateClassDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredRateOrTariffClassDescriptionCode(string rateOrTariffClassDescriptionCode, bool isValidExpected)
	{
		var subject = new E011_RateClassDetails();
		//Required fields
		//Test Parameters
		subject.RateOrTariffClassDescriptionCode = rateOrTariffClassDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
