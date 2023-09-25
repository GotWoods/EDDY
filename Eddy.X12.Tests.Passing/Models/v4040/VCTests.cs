using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class VCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VC*p*fu*7*rF*m*A*nQ*k*r*WFC1ww*x*L*b";

		var expected = new VC_MotorVehicleControl()
		{
			VehicleIdentificationNumber = "p",
			VehicleDeckPositionCode = "fu",
			VehicleTypeCode = "7",
			DealerCode = "rF",
			RouteCode = "m",
			BayLocation = "A",
			AutomotiveManufacturersCode = "nQ",
			DamageExceptionIndicator = "k",
			SupplementalInspectionCode = "r",
			FactoryCarOrderNumber = "WFC1ww",
			VesselStowageLocation = "x",
			EquipmentOrientationCode = "L",
			LocationIdentifier = "b",
		};

		var actual = Map.MapObject<VC_MotorVehicleControl>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredVehicleIdentificationNumber(string vehicleIdentificationNumber, bool isValidExpected)
	{
		var subject = new VC_MotorVehicleControl();
		//Required fields
		//Test Parameters
		subject.VehicleIdentificationNumber = vehicleIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
