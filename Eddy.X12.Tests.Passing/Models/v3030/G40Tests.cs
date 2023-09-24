using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class G40Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G40*x*6*1*H*jK*nV*C0";

		var expected = new G40_BracketPrice()
		{
			PriceBracketIdentifier = "x",
			ItemListCostNew = 6,
			ItemListCostOld = 1,
			FreeFormDescription = "H",
			PriceNewSuggestedRetail = "jK",
			PriceOldSuggestedRetail = "nV",
			UnitOrBasisForMeasurementCode = "C0",
		};

		var actual = Map.MapObject<G40_BracketPrice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredPriceBracketIdentifier(string priceBracketIdentifier, bool isValidExpected)
	{
		var subject = new G40_BracketPrice();
		subject.ItemListCostNew = 6;
		subject.PriceBracketIdentifier = priceBracketIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredItemListCostNew(decimal itemListCostNew, bool isValidExpected)
	{
		var subject = new G40_BracketPrice();
		subject.PriceBracketIdentifier = "x";
		if (itemListCostNew > 0)
			subject.ItemListCostNew = itemListCostNew;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
