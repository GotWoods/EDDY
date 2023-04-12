using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class W10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W10*FT*2*S*o*r*2*Ag*2*rV";

		var expected = new W10_WarehouseAdditionalCarrierInformation()
		{
			UnitLoadOptionCode = "FT",
			QuantityOfPalletsShipped = 2,
			PalletExchangeCode = "S",
			SealNumber = "o",
			SealNumber2 = "r",
			Temperature = 2,
			UnitOrBasisForMeasurementCode = "Ag",
			Temperature2 = 2,
			UnitOrBasisForMeasurementCode2 = "rV",
		};

		var actual = Map.MapObject<W10_WarehouseAdditionalCarrierInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(2, "Ag", true)]
	[InlineData(0, "Ag", false)]
	[InlineData(2, "", false)]
	public void Validation_AllAreRequiredTemperature(decimal temperature, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new W10_WarehouseAdditionalCarrierInformation();
		if (temperature > 0)
		subject.Temperature = temperature;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(2, "rV", true)]
	[InlineData(0, "rV", false)]
	[InlineData(2, "", false)]
	public void Validation_AllAreRequiredTemperature2(decimal temperature2, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new W10_WarehouseAdditionalCarrierInformation();
		if (temperature2 > 0)
		subject.Temperature2 = temperature2;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
