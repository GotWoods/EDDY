using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G22Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G22*B*iv*j*g";

		var expected = new G22_PricingInformation()
		{
			PrepricedOptionCode = "B",
			PriceNewSuggestedRetail = "iv",
			MultiplePriceQuantity = "j",
			FreeFormMessage = "g",
		};

		var actual = Map.MapObject<G22_PricingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredPrepricedOptionCode(string prepricedOptionCode, bool isValidExpected)
	{
		var subject = new G22_PricingInformation();
		subject.PrepricedOptionCode = prepricedOptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
