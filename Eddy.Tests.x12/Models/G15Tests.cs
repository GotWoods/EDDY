using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G15Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G15*9*49*T*h";

		var expected = new G15_CouponDistribution()
		{
			Quantity = 9,
			CouponDistributionMediaCode = "49",
			CouponTypeCode = "T",
			Description = "h",
		};

		var actual = Map.MapObject<G15_CouponDistribution>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new G15_CouponDistribution();
		subject.CouponDistributionMediaCode = "49";
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("49", true)]
	public void Validation_RequiredCouponDistributionMediaCode(string couponDistributionMediaCode, bool isValidExpected)
	{
		var subject = new G15_CouponDistribution();
		subject.Quantity = 9;
		subject.CouponDistributionMediaCode = couponDistributionMediaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
