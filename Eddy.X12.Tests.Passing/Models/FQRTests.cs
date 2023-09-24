using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class FQRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FQR*j3*8s*1*n7";

		var expected = new FQR_ForecastParameters()
		{
			ForecastPurposeCode = "j3",
			ForecastTypeCode = "8s",
			Quantity = 1,
			UnitOrBasisForMeasurementCode = "n7",
		};

		var actual = Map.MapObject<FQR_ForecastParameters>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j3", true)]
	public void Validation_RequiredForecastPurposeCode(string forecastPurposeCode, bool isValidExpected)
	{
		var subject = new FQR_ForecastParameters();
		subject.ForecastTypeCode = "8s";
		subject.Quantity = 1;
		subject.ForecastPurposeCode = forecastPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8s", true)]
	public void Validation_RequiredForecastTypeCode(string forecastTypeCode, bool isValidExpected)
	{
		var subject = new FQR_ForecastParameters();
		subject.ForecastPurposeCode = "j3";
		subject.Quantity = 1;
		subject.ForecastTypeCode = forecastTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new FQR_ForecastParameters();
		subject.ForecastPurposeCode = "j3";
		subject.ForecastTypeCode = "8s";
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
