using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class RPATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RPA*h*7*6**9";

		var expected = new RPA_RateAmountsOrPercents()
		{
			RateOrValueTypeCode = "h",
			MonetaryAmount = 7,
			Rate = 6,
			CompositeUnitOfMeasure = null,
			Percent = 9,
		};

		var actual = Map.MapObject<RPA_RateAmountsOrPercents>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredRateOrValueTypeCode(string rateOrValueTypeCode, bool isValidExpected)
	{
		var subject = new RPA_RateAmountsOrPercents();
		//Required fields
		//Test Parameters
		subject.RateOrValueTypeCode = rateOrValueTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
