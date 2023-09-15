using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G52Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G52*m1*H*I1";

		var expected = new G52_PromotionAnnouncementConfirmationStatus()
		{
			PromotionConfirmationStatusCode = "m1",
			AllowanceOrChargeNumber = "H",
			ChangeOrResponseTypeCode = "I1",
		};

		var actual = Map.MapObject<G52_PromotionAnnouncementConfirmationStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m1", true)]
	public void Validation_RequiredPromotionConfirmationStatusCode(string promotionConfirmationStatusCode, bool isValidExpected)
	{
		var subject = new G52_PromotionAnnouncementConfirmationStatus();
		subject.ChangeOrResponseTypeCode = "I1";
		subject.PromotionConfirmationStatusCode = promotionConfirmationStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I1", true)]
	public void Validation_RequiredChangeOrResponseTypeCode(string changeOrResponseTypeCode, bool isValidExpected)
	{
		var subject = new G52_PromotionAnnouncementConfirmationStatus();
		subject.PromotionConfirmationStatusCode = "m1";
		subject.ChangeOrResponseTypeCode = changeOrResponseTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
