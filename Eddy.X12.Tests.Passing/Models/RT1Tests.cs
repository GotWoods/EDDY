using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class RT1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RT1*w*G*5*F*8*7M*q*H";

		var expected = new RT1_RateDetail()
		{
			TransportationMethodTypeCode = "w",
			VehicleTypeCode = "G",
			FreightRate = 5,
			RoundingRuleCode = "F",
			VehicleIdentificationNumberVINPlantCode = "8",
			EquipmentDescriptionCode = "7M",
			TariffItemNumber = "q",
			SpecialRateCode = "H",
		};

		var actual = Map.MapObject<RT1_RateDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new RT1_RateDetail();
		subject.VehicleTypeCode = "G";
		subject.FreightRate = 5;
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredVehicleTypeCode(string vehicleTypeCode, bool isValidExpected)
	{
		var subject = new RT1_RateDetail();
		subject.TransportationMethodTypeCode = "w";
		subject.FreightRate = 5;
		subject.VehicleTypeCode = vehicleTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredFreightRate(decimal freightRate, bool isValidExpected)
	{
		var subject = new RT1_RateDetail();
		subject.TransportationMethodTypeCode = "w";
		subject.VehicleTypeCode = "G";
		if (freightRate > 0)
		subject.FreightRate = freightRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
