using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class G15Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G15*7*3s*f*y";

		var expected = new G15_CouponDistribution()
		{
			Quantity = 7,
			CouponDistributionMediaCode = "3s",
			CouponTypeCode = "f",
			Description = "y",
		};

		var actual = Map.MapObject<G15_CouponDistribution>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new G15_CouponDistribution();
		subject.CouponDistributionMediaCode = "3s";
		if (quantity > 0)
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3s", true)]
	public void Validation_RequiredCouponDistributionMediaCode(string couponDistributionMediaCode, bool isValidExpected)
	{
		var subject = new G15_CouponDistribution();
		subject.Quantity = 7;
		subject.CouponDistributionMediaCode = couponDistributionMediaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
