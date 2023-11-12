using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class VCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VC*EinMynuJUzPtObafP*fv*h*X2*G*9*CH*2*F*U5idMs*c";

		var expected = new VC_MotorVehicleControl()
		{
			VehicleIdentificationNumber = "EinMynuJUzPtObafP",
			VehicleDeckPositionCode = "fv",
			VehicleTypeCode = "h",
			DealerCode = "X2",
			RouteCode = "G",
			BayLocation = "9",
			AutomotiveManufacturersCode = "CH",
			DamageExceptionIndicator = "2",
			SupplementalInspectionCode = "F",
			FactoryCarOrderNumber = "U5idMs",
			VesselStowageLocation = "c",
		};

		var actual = Map.MapObject<VC_MotorVehicleControl>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("EinMynuJUzPtObafP", true)]
	public void Validation_RequiredVehicleIdentificationNumber(string vehicleIdentificationNumber, bool isValidExpected)
	{
		var subject = new VC_MotorVehicleControl();
		//Required fields
		//Test Parameters
		subject.VehicleIdentificationNumber = vehicleIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
