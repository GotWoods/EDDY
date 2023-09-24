using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.Tests.Models.v8010;

public class W10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W10*3k*1*2*h*F*7*D1*2*he";

		var expected = new W10_WarehouseAdditionalCarrierInformation()
		{
			UnitLoadOptionCode = "3k",
			QuantityOfPalletsShipped = 1,
			PalletExchangeCode = "2",
			SealNumber = "h",
			SealNumber2 = "F",
			Temperature = 7,
			UnitOrBasisForMeasurementCode = "D1",
			Temperature2 = 2,
			UnitOrBasisForMeasurementCode2 = "he",
		};

		var actual = Map.MapObject<W10_WarehouseAdditionalCarrierInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "D1", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "D1", false)]
	public void Validation_AllAreRequiredTemperature(decimal temperature, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new W10_WarehouseAdditionalCarrierInformation();
		//Required fields
		//Test Parameters
		if (temperature > 0) 
			subject.Temperature = temperature;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(subject.Temperature2 > 0 || subject.Temperature2 > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Temperature2 = 2;
			subject.UnitOrBasisForMeasurementCode2 = "he";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "he", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "he", false)]
	public void Validation_AllAreRequiredTemperature2(decimal temperature2, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new W10_WarehouseAdditionalCarrierInformation();
		//Required fields
		//Test Parameters
		if (temperature2 > 0) 
			subject.Temperature2 = temperature2;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(subject.Temperature > 0 || subject.Temperature > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Temperature = 7;
			subject.UnitOrBasisForMeasurementCode = "D1";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
