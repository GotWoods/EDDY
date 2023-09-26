using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5040;

namespace Eddy.x12.Tests.Models.v5040;

public class RT1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RT1*4*d*1*m*I*NE*T*R";

		var expected = new RT1_RateDetail()
		{
			TransportationMethodTypeCode = "4",
			VehicleTypeCode = "d",
			FreightRate = 1,
			RoundingRuleCode = "m",
			VehicleIdentificationNumberVINPlantCode = "I",
			EquipmentDescriptionCode = "NE",
			TariffItemNumber = "T",
			SpecialRateCode = "R",
		};

		var actual = Map.MapObject<RT1_RateDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new RT1_RateDetail();
		//Required fields
		subject.VehicleTypeCode = "d";
		subject.FreightRate = 1;
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredVehicleTypeCode(string vehicleTypeCode, bool isValidExpected)
	{
		var subject = new RT1_RateDetail();
		//Required fields
		subject.TransportationMethodTypeCode = "4";
		subject.FreightRate = 1;
		//Test Parameters
		subject.VehicleTypeCode = vehicleTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredFreightRate(decimal freightRate, bool isValidExpected)
	{
		var subject = new RT1_RateDetail();
		//Required fields
		subject.TransportationMethodTypeCode = "4";
		subject.VehicleTypeCode = "d";
		//Test Parameters
		if (freightRate > 0) 
			subject.FreightRate = freightRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
