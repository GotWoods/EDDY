using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97B;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Tests.Models.D97B.Composites;

public class E011Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "K:F";

		var expected = new E011_RateClassDetails()
		{
			RateTariffClassIdentification = "K",
			ProcessingIndicatorCoded = "F",
		};

		var actual = Map.MapComposite<E011_RateClassDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredRateTariffClassIdentification(string rateTariffClassIdentification, bool isValidExpected)
	{
		var subject = new E011_RateClassDetails();
		//Required fields
		//Test Parameters
		subject.RateTariffClassIdentification = rateTariffClassIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
