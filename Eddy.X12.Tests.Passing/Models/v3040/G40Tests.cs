using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class G40Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G40*k*1*7*Q*tw*OS*in*FDr";

		var expected = new G40_BracketPrice()
		{
			PriceBracketIdentifier = "k",
			ItemListCostNew = 1,
			ItemListCostOld = 7,
			FreeFormDescription = "Q",
			PriceNewSuggestedRetail = "tw",
			PriceOldSuggestedRetail = "OS",
			UnitOrBasisForMeasurementCode = "in",
			PriceIdentifierCode = "FDr",
		};

		var actual = Map.MapObject<G40_BracketPrice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredItemListCostNew(decimal itemListCostNew, bool isValidExpected)
	{
		var subject = new G40_BracketPrice();
		if (itemListCostNew > 0)
			subject.ItemListCostNew = itemListCostNew;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
