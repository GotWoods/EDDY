using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class G40Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G40*a*4*3*U*BG*HW*fS*CHY*5";

		var expected = new G40_BracketPrice()
		{
			PriceBracketIdentifier = "a",
			ItemListCostNew = 4,
			ItemListCostOld = 3,
			FreeFormDescription = "U",
			PriceNewSuggestedRetail = "BG",
			PriceOldSuggestedRetail = "HW",
			UnitOrBasisForMeasurementCode = "fS",
			PriceIdentifierCode = "CHY",
			Number = 5,
		};

		var actual = Map.MapObject<G40_BracketPrice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredItemListCostNew(decimal itemListCostNew, bool isValidExpected)
	{
		var subject = new G40_BracketPrice();
		if (itemListCostNew > 0)
			subject.ItemListCostNew = itemListCostNew;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
