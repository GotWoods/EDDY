using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C138Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "u:6";

		var expected = new C138_PriceMultiplierInformation()
		{
			PriceMultiplier = "u",
			PriceMultiplierQualifier = "6",
		};

		var actual = Map.MapComposite<C138_PriceMultiplierInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredPriceMultiplier(string priceMultiplier, bool isValidExpected)
	{
		var subject = new C138_PriceMultiplierInformation();
		//Required fields
		//Test Parameters
		subject.PriceMultiplier = priceMultiplier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
