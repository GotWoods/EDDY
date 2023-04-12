using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RPATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RPA*W*4*2**6";

		var expected = new RPA_RateAmountsOrPercents()
		{
			RateOrValueTypeCode = "W",
			MonetaryAmount = 4,
			Rate = 2,
			CompositeUnitOfMeasure = null,
			PercentageAsDecimal = 6,
		};

		var actual = Map.MapObject<RPA_RateAmountsOrPercents>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredRateOrValueTypeCode(string rateOrValueTypeCode, bool isValidExpected)
	{
		var subject = new RPA_RateAmountsOrPercents();
		subject.RateOrValueTypeCode = rateOrValueTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
