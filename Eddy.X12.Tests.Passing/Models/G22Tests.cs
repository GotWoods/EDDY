using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G22Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G22*v*fW*2*A*k6tuME3W";

		var expected = new G22_PrePricingInformation()
		{
			PrePricedOptionCode = "v",
			PriceNewSuggestedRetail = "fW",
			MultiplePriceQuantity = 2,
			FreeFormMessage = "A",
			Date = "k6tuME3W",
		};

		var actual = Map.MapObject<G22_PrePricingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredPrePricedOptionCode(string prePricedOptionCode, bool isValidExpected)
	{
		var subject = new G22_PrePricingInformation();
		subject.PrePricedOptionCode = prePricedOptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
