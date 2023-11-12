using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G40Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G40*g*4*9*3*Xf*p8";

		var expected = new G40_BracketPrice()
		{
			PriceBracketIdentifier = "g",
			ItemListCostNew = 4,
			ItemListCostOld = 9,
			FreeFormDescription = "3",
			PriceNewSuggestedRetail = "Xf",
			PriceOldSuggestedRetail = "p8",
		};

		var actual = Map.MapObject<G40_BracketPrice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredPriceBracketIdentifier(string priceBracketIdentifier, bool isValidExpected)
	{
		var subject = new G40_BracketPrice();
		subject.ItemListCostNew = 4;
		subject.ItemListCostOld = 9;
		subject.PriceBracketIdentifier = priceBracketIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredItemListCostNew(decimal itemListCostNew, bool isValidExpected)
	{
		var subject = new G40_BracketPrice();
		subject.PriceBracketIdentifier = "g";
		subject.ItemListCostOld = 9;
		if (itemListCostNew > 0)
			subject.ItemListCostNew = itemListCostNew;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredItemListCostOld(decimal itemListCostOld, bool isValidExpected)
	{
		var subject = new G40_BracketPrice();
		subject.PriceBracketIdentifier = "g";
		subject.ItemListCostNew = 4;
		if (itemListCostOld > 0)
			subject.ItemListCostOld = itemListCostOld;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
