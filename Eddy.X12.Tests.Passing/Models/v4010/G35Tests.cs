using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class G35Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G35*2c*L*1";

		var expected = new G35_AdvertisingFeatureInformation()
		{
			PromotionConditionCode = "2c",
			CouponTypeCode = "L",
			MonetaryAmount = 1,
		};

		var actual = Map.MapObject<G35_AdvertisingFeatureInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", "", true)]
	[InlineData(1, "2c", "L", true)]
	[InlineData(1, "", "", false)]
	[InlineData(0, "2c", "L", true)]
	public void Validation_IfOneSpecifiedThenOneMoreRequired_MonetaryAmount(decimal monetaryAmount, string promotionConditionCode, string couponTypeCode, bool isValidExpected)
	{
		var subject = new G35_AdvertisingFeatureInformation();
		//Required fields
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		subject.PromotionConditionCode = promotionConditionCode;
		subject.CouponTypeCode = couponTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledThenAtLeastOneOtherIsRequired);
	}

}
