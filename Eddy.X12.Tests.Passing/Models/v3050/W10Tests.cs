using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class W10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W10*YV*8*Y*II*zY*8*jK*9*uk";

		var expected = new W10_WarehouseAdditionalCarrierInformation()
		{
			UnitLoadOptionCode = "YV",
			QuantityOfPalletsShipped = 8,
			PalletExchangeCode = "Y",
			SealNumber = "II",
			SealNumber2 = "zY",
			Temperature = 8,
			UnitOrBasisForMeasurementCode = "jK",
			Temperature2 = 9,
			UnitOrBasisForMeasurementCode2 = "uk",
		};

		var actual = Map.MapObject<W10_WarehouseAdditionalCarrierInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "jK", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "jK", false)]
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
			subject.Temperature2 = 9;
			subject.UnitOrBasisForMeasurementCode2 = "uk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "uk", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "uk", false)]
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
			subject.Temperature = 8;
			subject.UnitOrBasisForMeasurementCode = "jK";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
