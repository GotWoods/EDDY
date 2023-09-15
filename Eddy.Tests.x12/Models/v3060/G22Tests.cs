using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class G22Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G22*T*ik*8*q*ERVBgK";

		var expected = new G22_PricingInformation()
		{
			PrepricedOptionCode = "T",
			PriceNewSuggestedRetail = "ik",
			MultiplePriceQuantity = 8,
			FreeFormMessage = "q",
			Date = "ERVBgK",
		};

		var actual = Map.MapObject<G22_PricingInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredPrepricedOptionCode(string prepricedOptionCode, bool isValidExpected)
	{
		var subject = new G22_PricingInformation();
		subject.PrepricedOptionCode = prepricedOptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
