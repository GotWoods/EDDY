using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class RPATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RPA*G*7*9*Qx*9";

		var expected = new RPA_RateAmountsOrPercents()
		{
			RateOrValueTypeCode = "G",
			MonetaryAmount = 7,
			Rate = 9,
			UnitOrBasisForMeasurementCode = "Qx",
			Percent = 9,
		};

		var actual = Map.MapObject<RPA_RateAmountsOrPercents>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredRateOrValueTypeCode(string rateOrValueTypeCode, bool isValidExpected)
	{
		var subject = new RPA_RateAmountsOrPercents();
		//Required fields
		//Test Parameters
		subject.RateOrValueTypeCode = rateOrValueTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
