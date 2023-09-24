using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G44Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G44*3C*js*46*7Q*Z5*G*h*LE*O";

		var expected = new G44_PromotionRestrictions()
		{
			PromotionConditionQualifier = "3C",
			PromotionConditionCode = "js",
			PromotionConditionCode2 = "46",
			PromotionConditionCode3 = "7Q",
			PromotionConditionCode4 = "Z5",
			FreeFormMessage = "G",
			FreeFormMessage2 = "h",
			PromotionAmountQualifier = "LE",
			AllowanceOrChargeTotalAmount = "O",
		};

		var actual = Map.MapObject<G44_PromotionRestrictions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3C", true)]
	public void Validation_RequiredPromotionConditionQualifier(string promotionConditionQualifier, bool isValidExpected)
	{
		var subject = new G44_PromotionRestrictions();
		subject.PromotionConditionQualifier = promotionConditionQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
