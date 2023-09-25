using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class W10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W10*OX*4*h*Fk*K0*8*NT*5*fh";

		var expected = new W10_WarehouseAdditionalCarrierInformation()
		{
			UnitLoadOptionCode = "OX",
			QuantityOfPalletsShipped = 4,
			PalletExchangeCode = "h",
			SealNumber = "Fk",
			SealNumber2 = "K0",
			Temperature = 8,
			UnitOrBasisForMeasurementCode = "NT",
			Temperature2 = 5,
			UnitOrBasisForMeasurementCode2 = "fh",
		};

		var actual = Map.MapObject<W10_WarehouseAdditionalCarrierInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "NT", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "NT", false)]
	public void Validation_AllAreRequiredTemperature(int temperature, string unitOrBasisForMeasurementCode, bool isValidExpected)
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
			subject.Temperature2 = 5;
			subject.UnitOrBasisForMeasurementCode2 = "fh";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "fh", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "fh", false)]
	public void Validation_AllAreRequiredTemperature2(int temperature2, string unitOrBasisForMeasurementCode2, bool isValidExpected)
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
			subject.UnitOrBasisForMeasurementCode = "NT";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
