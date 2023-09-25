using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class VCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VC*a*DT*p*BQ*l*h*YX*Y*B*ewDROf*j*2*X";

		var expected = new VC_MotorVehicleControl()
		{
			VehicleIdentificationNumber = "a",
			VehicleDeckPositionCode = "DT",
			VehicleTypeCode = "p",
			DealerCode = "BQ",
			RouteCode = "l",
			BayLocation = "h",
			AutomotiveManufacturersCode = "YX",
			DamageExceptionIndicator = "Y",
			SupplementalInspectionCode = "B",
			FactoryCarOrderNumber = "ewDROf",
			VesselStowageLocation = "j",
			EquipmentOrientationCode = "2",
			LocationIdentifier = "X",
		};

		var actual = Map.MapObject<VC_MotorVehicleControl>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredVehicleIdentificationNumber(string vehicleIdentificationNumber, bool isValidExpected)
	{
		var subject = new VC_MotorVehicleControl();
		//Required fields
		//Test Parameters
		subject.VehicleIdentificationNumber = vehicleIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
