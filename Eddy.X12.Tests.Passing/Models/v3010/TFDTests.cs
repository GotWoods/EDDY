using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class TFDTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TFD*L5*6";

		var expected = new TFD_TariffAdjustmentsMinimumCharge()
		{
			RateValueQualifier = "L5",
			TariffAdjustmentValueAmount = 6,
		};

		var actual = Map.MapObject<TFD_TariffAdjustmentsMinimumCharge>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L5", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new TFD_TariffAdjustmentsMinimumCharge();
		subject.TariffAdjustmentValueAmount = 6;
		subject.RateValueQualifier = rateValueQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredTariffAdjustmentValueAmount(decimal tariffAdjustmentValueAmount, bool isValidExpected)
	{
		var subject = new TFD_TariffAdjustmentsMinimumCharge();
		subject.RateValueQualifier = "L5";
		if (tariffAdjustmentValueAmount > 0)
			subject.TariffAdjustmentValueAmount = tariffAdjustmentValueAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
