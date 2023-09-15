using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class G14Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G14*bMzG*mst6";

		var expected = new G14_CouponSpecialProcessing()
		{
			ServicePromotionAllowanceOrChargeCode = "bMzG",
			ServicePromotionAllowanceOrChargeCode2 = "mst6",
		};

		var actual = Map.MapObject<G14_CouponSpecialProcessing>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bMzG", true)]
	public void Validation_RequiredServicePromotionAllowanceOrChargeCode(string servicePromotionAllowanceOrChargeCode, bool isValidExpected)
	{
		var subject = new G14_CouponSpecialProcessing();
		subject.ServicePromotionAllowanceOrChargeCode = servicePromotionAllowanceOrChargeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
