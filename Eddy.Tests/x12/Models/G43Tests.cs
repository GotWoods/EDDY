using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G43Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G43*W*3*f*mw";

		var expected = new G43_PromotionPriceListArea()
		{
			MarketAreaCodeQualifier = "W",
			MarketAreaCodeIdentifier = "3",
			Description = "f",
			ClassOfTradeCode = "mw",
		};

		var actual = Map.MapObject<G43_PromotionPriceListArea>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredMarketAreaCodeQualifier(string marketAreaCodeQualifier, bool isValidExpected)
	{
		var subject = new G43_PromotionPriceListArea();
		subject.MarketAreaCodeQualifier = marketAreaCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
