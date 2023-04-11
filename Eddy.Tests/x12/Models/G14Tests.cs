using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G14Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G14*FLUr*PqDk";

		var expected = new G14_CouponSpecialProcessing()
		{
			ServicePromotionAllowanceOrChargeCode = "FLUr",
			ServicePromotionAllowanceOrChargeCode2 = "PqDk",
		};

		var actual = Map.MapObject<G14_CouponSpecialProcessing>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("FLUr", true)]
	public void Validation_RequiredServicePromotionAllowanceOrChargeCode(string servicePromotionAllowanceOrChargeCode, bool isValidExpected)
	{
		var subject = new G14_CouponSpecialProcessing();
		subject.ServicePromotionAllowanceOrChargeCode = servicePromotionAllowanceOrChargeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
