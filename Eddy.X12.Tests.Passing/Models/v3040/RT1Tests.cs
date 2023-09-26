using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class RT1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "RT1*q*s*4*P*y*Xn*z*m";

		var expected = new RT1_RateDetail()
		{
			TransportationMethodTypeCode = "q",
			VehicleTypeCode = "s",
			FreightRate = 4,
			RoundingRuleCode = "P",
			VehicleIdentificationNumberVINPlantCode = "y",
			EquipmentDescriptionCode = "Xn",
			TariffItemNumber = "z",
			SpecialRateCode = "m",
		};

		var actual = Map.MapObject<RT1_RateDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredTransportationMethodTypeCode(string transportationMethodTypeCode, bool isValidExpected)
	{
		var subject = new RT1_RateDetail();
		//Required fields
		subject.VehicleTypeCode = "s";
		subject.FreightRate = 4;
		//Test Parameters
		subject.TransportationMethodTypeCode = transportationMethodTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredVehicleTypeCode(string vehicleTypeCode, bool isValidExpected)
	{
		var subject = new RT1_RateDetail();
		//Required fields
		subject.TransportationMethodTypeCode = "q";
		subject.FreightRate = 4;
		//Test Parameters
		subject.VehicleTypeCode = vehicleTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredFreightRate(decimal freightRate, bool isValidExpected)
	{
		var subject = new RT1_RateDetail();
		//Required fields
		subject.TransportationMethodTypeCode = "q";
		subject.VehicleTypeCode = "s";
		//Test Parameters
		if (freightRate > 0) 
			subject.FreightRate = freightRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
