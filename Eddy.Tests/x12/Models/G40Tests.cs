using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G40Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G40*c*7*7*j*3Q*CN*3b*OLK*1";

		var expected = new G40_BracketPrice()
		{
			PriceBracketIdentifier = "c",
			ItemListCostNew = 7,
			ItemListCostOld = 7,
			FreeFormDescription = "j",
			PriceNewSuggestedRetail = "3Q",
			PriceOldSuggestedRetail = "CN",
			UnitOrBasisForMeasurementCode = "3b",
			PriceIdentifierCode = "OLK",
			Number = 1,
		};

		var actual = Map.MapObject<G40_BracketPrice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredItemListCostNew(decimal itemListCostNew, bool isValidExpected)
	{
		var subject = new G40_BracketPrice();
		if (itemListCostNew > 0)
		subject.ItemListCostNew = itemListCostNew;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
