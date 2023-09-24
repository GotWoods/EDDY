using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class TFATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TFA*cu*9*8*8*8*4*3*6*7*1*4*8*7*2*3*1*3";

		var expected = new TFA_TariffAdjustments()
		{
			RateValueQualifier = "cu",
			TariffAdjustmentValueAmount = 9,
			TariffAdjustmentValueAmount2 = 8,
			TariffAdjustmentValueAmount3 = 8,
			TariffAdjustmentValueAmount4 = 8,
			TariffAdjustmentValueAmount5 = 4,
			TariffAdjustmentValueAmount6 = 3,
			TariffAdjustmentValueAmount7 = 6,
			TariffAdjustmentValueAmount8 = 7,
			TariffAdjustmentValueAmount9 = 1,
			TariffAdjustmentValueAmount10 = 4,
			TariffAdjustmentValueAmount11 = 8,
			TariffAdjustmentValueAmount12 = 7,
			TariffAdjustmentValueAmount13 = 2,
			TariffAdjustmentValueAmount14 = 3,
			TariffAdjustmentValueAmount15 = 1,
			TariffAdjustmentValueAmount16 = 3,
		};

		var actual = Map.MapObject<TFA_TariffAdjustments>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cu", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new TFA_TariffAdjustments();
		subject.RateValueQualifier = rateValueQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
