using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G40Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G40*j*3*4*Y*89*iB*rJ";

		var expected = new G40_BracketPrice()
		{
			PriceBracketIdentifier = "j",
			ItemListCostNew = 3,
			ItemListCostOld = 4,
			FreeFormDescription = "Y",
			PriceNewSuggestedRetail = "89",
			PriceOldSuggestedRetail = "iB",
			UnitOfMeasurementCode = "rJ",
		};

		var actual = Map.MapObject<G40_BracketPrice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredPriceBracketIdentifier(string priceBracketIdentifier, bool isValidExpected)
	{
		var subject = new G40_BracketPrice();
		subject.ItemListCostNew = 3;
		subject.PriceBracketIdentifier = priceBracketIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredItemListCostNew(decimal itemListCostNew, bool isValidExpected)
	{
		var subject = new G40_BracketPrice();
		subject.PriceBracketIdentifier = "j";
		if (itemListCostNew > 0)
			subject.ItemListCostNew = itemListCostNew;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
