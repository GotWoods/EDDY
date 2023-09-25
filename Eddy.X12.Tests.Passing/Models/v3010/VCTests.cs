using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class VCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VC*TTkth488VqwpsKWTy*Ym*1*u7*e*K*Bf*6*d*9K1QP8";

		var expected = new VC_MotorVehicleControl()
		{
			VehicleIdentificationNumber = "TTkth488VqwpsKWTy",
			VehicleDeckPositionCode = "Ym",
			VehicleTypeCode = "1",
			DealerCode = "u7",
			RouteCode = "e",
			BayLocation = "K",
			AutomotiveManufacturersCode = "Bf",
			DamageExceptionIndicator = "6",
			SupplementalInspectionCode = "d",
			FactoryCarOrderNumber = "9K1QP8",
		};

		var actual = Map.MapObject<VC_MotorVehicleControl>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("TTkth488VqwpsKWTy", true)]
	public void Validation_RequiredVehicleIdentificationNumber(string vehicleIdentificationNumber, bool isValidExpected)
	{
		var subject = new VC_MotorVehicleControl();
		//Required fields
		//Test Parameters
		subject.VehicleIdentificationNumber = vehicleIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
