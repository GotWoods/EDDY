using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G35Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G35*GM*9*7";

		var expected = new G35_AdvertisingFeatureInformation()
		{
			PromotionConditionCode = "GM",
			CouponTypeCode = "9",
			MonetaryAmount = 7,
		};

		var actual = Map.MapObject<G35_AdvertisingFeatureInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0,"", "",true)]
	[InlineData(7, "GM", "", true)]
	[InlineData(0,"GM","", false)]
	[InlineData(7, "", "GM",true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_MonetaryAmount(decimal monetaryAmount, string promotionConditionCode, string couponTypeCode, bool isValidExpected)
	{
		var subject = new G35_AdvertisingFeatureInformation();
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		subject.PromotionConditionCode = promotionConditionCode;
		subject.CouponTypeCode = couponTypeCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
