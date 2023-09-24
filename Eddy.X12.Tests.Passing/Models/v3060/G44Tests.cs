using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class G44Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G44*wl*5F*2Y*IN*R6*F*6*ga*u";

		var expected = new G44_PromotionRestrictions()
		{
			PromotionConditionQualifier = "wl",
			PromotionConditionCode = "5F",
			PromotionConditionCode2 = "2Y",
			PromotionConditionCode3 = "IN",
			PromotionConditionCode4 = "R6",
			FreeFormMessage = "F",
			FreeFormMessage2 = "6",
			PromotionAmountQualifier = "ga",
			AllowanceOrChargeTotalAmount = "u",
		};

		var actual = Map.MapObject<G44_PromotionRestrictions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wl", true)]
	public void Validation_RequiredPromotionConditionQualifier(string promotionConditionQualifier, bool isValidExpected)
	{
		var subject = new G44_PromotionRestrictions();
		subject.PromotionConditionQualifier = promotionConditionQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
