using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G56Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G56*6*V*7*p5";

		var expected = new G56_PriceInformation()
		{
			PriceBracketIdentifier = "6",
			FreeFormMessage = "V",
			ItemListCostNew = 7,
			PriceNewSuggestedRetail = "p5",
		};

		var actual = Map.MapObject<G56_PriceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredPriceBracketIdentifier(string priceBracketIdentifier, bool isValidExpected)
	{
		var subject = new G56_PriceInformation();
		subject.ItemListCostNew = 7;
		subject.PriceBracketIdentifier = priceBracketIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredItemListCostNew(decimal itemListCostNew, bool isValidExpected)
	{
		var subject = new G56_PriceInformation();
		subject.PriceBracketIdentifier = "6";
		if (itemListCostNew > 0)
			subject.ItemListCostNew = itemListCostNew;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
