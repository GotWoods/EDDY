using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class VCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VC*3*Pl*f*kI*4*5*GK*8*Q*CR9I7v*e*P*u";

		var expected = new VC_MotorVehicleControl()
		{
			VehicleIdentificationNumber = "3",
			VehicleDeckPositionCode = "Pl",
			VehicleTypeCode = "f",
			DealerCode = "kI",
			RouteCode = "4",
			BayLocation = "5",
			AutomotiveManufacturersCode = "GK",
			DamageExceptionIndicatorCode = "8",
			SupplementalInspectionCode = "Q",
			FactoryCarOrderNumber = "CR9I7v",
			VesselStowageLocation = "e",
			EquipmentOrientationCode = "P",
			LocationIdentifier = "u",
		};

		var actual = Map.MapObject<VC_MotorVehicleControl>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredVehicleIdentificationNumber(string vehicleIdentificationNumber, bool isValidExpected)
	{
		var subject = new VC_MotorVehicleControl();
		subject.VehicleIdentificationNumber = vehicleIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
