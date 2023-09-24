using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class G43Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G43*A*j*2*Nq";

		var expected = new G43_PromotionPriceListArea()
		{
			MarketAreaCodeQualifier = "A",
			MarketAreaCodeIdentifier = "j",
			Description = "2",
			ClassOfTradeCode = "Nq",
		};

		var actual = Map.MapObject<G43_PromotionPriceListArea>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredMarketAreaCodeQualifier(string marketAreaCodeQualifier, bool isValidExpected)
	{
		var subject = new G43_PromotionPriceListArea();
		subject.MarketAreaCodeQualifier = marketAreaCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
