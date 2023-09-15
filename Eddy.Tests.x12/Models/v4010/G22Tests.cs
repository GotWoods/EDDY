using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class G22Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G22*j*bR*9*h*qWuSKmMm";

		var expected = new G22_PricingInformation()
		{
			PrepricedOptionCode = "j",
			PriceNewSuggestedRetail = "bR",
			MultiplePriceQuantity = 9,
			FreeFormMessage = "h",
			Date = "qWuSKmMm",
		};

		var actual = Map.MapObject<G22_PricingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredPrepricedOptionCode(string prepricedOptionCode, bool isValidExpected)
	{
		var subject = new G22_PricingInformation();
		subject.PrepricedOptionCode = prepricedOptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
