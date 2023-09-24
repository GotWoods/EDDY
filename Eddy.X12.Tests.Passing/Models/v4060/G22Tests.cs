using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class G22Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G22*0*u4*7*f*GlwGKMbi";

		var expected = new G22_PrePricingInformation()
		{
			PrePricedOptionCode = "0",
			PriceNewSuggestedRetail = "u4",
			MultiplePriceQuantity = 7,
			FreeFormMessage = "f",
			Date = "GlwGKMbi",
		};

		var actual = Map.MapObject<G22_PrePricingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredPrePricedOptionCode(string prePricedOptionCode, bool isValidExpected)
	{
		var subject = new G22_PrePricingInformation();
		subject.PrePricedOptionCode = prePricedOptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
