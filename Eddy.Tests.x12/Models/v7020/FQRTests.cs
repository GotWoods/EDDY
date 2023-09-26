using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.Tests.Models.v7020;

public class FQRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "FQR*Yn*nH*4*0N";

		var expected = new FQR_ForecastParameters()
		{
			ForecastPurposeCode = "Yn",
			ForecastTypeCode = "nH",
			Quantity = 4,
			UnitOrBasisForMeasurementCode = "0N",
		};

		var actual = Map.MapObject<FQR_ForecastParameters>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Yn", true)]
	public void Validation_RequiredForecastPurposeCode(string forecastPurposeCode, bool isValidExpected)
	{
		var subject = new FQR_ForecastParameters();
		//Required fields
		subject.ForecastTypeCode = "nH";
		subject.Quantity = 4;
		//Test Parameters
		subject.ForecastPurposeCode = forecastPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("nH", true)]
	public void Validation_RequiredForecastTypeCode(string forecastTypeCode, bool isValidExpected)
	{
		var subject = new FQR_ForecastParameters();
		//Required fields
		subject.ForecastPurposeCode = "Yn";
		subject.Quantity = 4;
		//Test Parameters
		subject.ForecastTypeCode = forecastTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new FQR_ForecastParameters();
		//Required fields
		subject.ForecastPurposeCode = "Yn";
		subject.ForecastTypeCode = "nH";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
