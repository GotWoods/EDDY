using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C138Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "E:s";

		var expected = new C138_PriceMultiplierInformation()
		{
			PriceMultiplierRate = "E",
			PriceMultiplierTypeCodeQualifier = "s",
		};

		var actual = Map.MapComposite<C138_PriceMultiplierInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredPriceMultiplierRate(string priceMultiplierRate, bool isValidExpected)
	{
		var subject = new C138_PriceMultiplierInformation();
		//Required fields
		//Test Parameters
		subject.PriceMultiplierRate = priceMultiplierRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
