using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class VCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VC*d*FE*y*Fo*P*P*2t*n*5*TYGQbI*Y*y*y";

		var expected = new VC_MotorVehicleControl()
		{
			VehicleIdentificationNumber = "d",
			VehicleDeckPositionCode = "FE",
			VehicleTypeCode = "y",
			DealerCode = "Fo",
			RouteCode = "P",
			BayLocation = "P",
			AutomotiveManufacturersCode = "2t",
			DamageExceptionIndicatorCode = "n",
			SupplementalInspectionCode = "5",
			FactoryCarOrderNumber = "TYGQbI",
			VesselStowageLocation = "Y",
			EquipmentOrientationCode = "y",
			LocationIdentifier = "y",
		};

		var actual = Map.MapObject<VC_MotorVehicleControl>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredVehicleIdentificationNumber(string vehicleIdentificationNumber, bool isValidExpected)
	{
		var subject = new VC_MotorVehicleControl();
		//Required fields
		//Test Parameters
		subject.VehicleIdentificationNumber = vehicleIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
