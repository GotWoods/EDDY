using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class W10Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W10*Z2*7*T*z3*5G*5*dt*8*uh";

		var expected = new W10_WarehouseAdditionalCarrierInformation()
		{
			UnitLoadOptionCode = "Z2",
			QuantityOfPalletsShipped = 7,
			PalletExchangeCode = "T",
			SealNumber = "z3",
			SealNumber2 = "5G",
			Temperature = 5,
			UnitOfMeasurementCode = "dt",
			Temperature2 = 8,
			UnitOfMeasurementCode2 = "uh",
		};

		var actual = Map.MapObject<W10_WarehouseAdditionalCarrierInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "dt", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "dt", false)]
	public void Validation_AllAreRequiredTemperature(int temperature, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new W10_WarehouseAdditionalCarrierInformation();
		//Required fields
		//Test Parameters
		if (temperature > 0) 
			subject.Temperature = temperature;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//If one filled, all required
		if(subject.Temperature2 > 0 || subject.Temperature2 > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Temperature2 = 8;
			subject.UnitOfMeasurementCode2 = "uh";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "uh", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "uh", false)]
	public void Validation_AllAreRequiredTemperature2(int temperature2, string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new W10_WarehouseAdditionalCarrierInformation();
		//Required fields
		//Test Parameters
		if (temperature2 > 0) 
			subject.Temperature2 = temperature2;
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		//If one filled, all required
		if(subject.Temperature > 0 || subject.Temperature > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.Temperature = 5;
			subject.UnitOfMeasurementCode = "dt";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
