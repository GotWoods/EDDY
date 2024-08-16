using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E011Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "p:B";

		var expected = new E011_RateClassDetails()
		{
			RateTariffClassIdentification = "p",
			ProcessingIndicatorDescriptionCode = "B",
		};

		var actual = Map.MapComposite<E011_RateClassDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredRateTariffClassIdentification(string rateTariffClassIdentification, bool isValidExpected)
	{
		var subject = new E011_RateClassDetails();
		//Required fields
		//Test Parameters
		subject.RateTariffClassIdentification = rateTariffClassIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
