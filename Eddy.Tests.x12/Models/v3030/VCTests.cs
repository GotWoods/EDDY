using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class VCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VC*F*fR*y*mr*H*C*cS*w*M*xvwl4J*e";

		var expected = new VC_MotorVehicleControl()
		{
			VehicleIdentificationNumber = "F",
			VehicleDeckPositionCode = "fR",
			VehicleTypeCode = "y",
			DealerCode = "mr",
			RouteCode = "H",
			BayLocation = "C",
			AutomotiveManufacturersCode = "cS",
			DamageExceptionIndicator = "w",
			SupplementalInspectionCode = "M",
			FactoryCarOrderNumber = "xvwl4J",
			VesselStowageLocation = "e",
		};

		var actual = Map.MapObject<VC_MotorVehicleControl>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredVehicleIdentificationNumber(string vehicleIdentificationNumber, bool isValidExpected)
	{
		var subject = new VC_MotorVehicleControl();
		//Required fields
		//Test Parameters
		subject.VehicleIdentificationNumber = vehicleIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
