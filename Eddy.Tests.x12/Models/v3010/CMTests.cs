using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class CMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CM*0f*o*e5*8JFZEh*X*iL*fL*lLQbx2*9e*l*EP*04*Pl*5K";

		var expected = new CM_CargoManifest()
		{
			FlightVoyageNumber = "0f",
			PortFunctionCode = "o",
			PortName = "e5",
			Date = "8JFZEh",
			BookingNumber = "X",
			StandardCarrierAlphaCode = "iL",
			StandardCarrierAlphaCode2 = "fL",
			Date2 = "lLQbx2",
			VesselName = "9e",
			PierNumber = "l",
			PierName = "EP",
			TerminalName = "04",
			StateOrProvinceCode = "Pl",
			CountryCode = "5K",
		};

		var actual = Map.MapObject<CM_CargoManifest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0f", true)]
	public void Validation_RequiredFlightVoyageNumber(string flightVoyageNumber, bool isValidExpected)
	{
		var subject = new CM_CargoManifest();
		subject.PortFunctionCode = "o";
		subject.PortName = "e5";
		subject.FlightVoyageNumber = flightVoyageNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredPortFunctionCode(string portFunctionCode, bool isValidExpected)
	{
		var subject = new CM_CargoManifest();
		subject.FlightVoyageNumber = "0f";
		subject.PortName = "e5";
		subject.PortFunctionCode = portFunctionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e5", true)]
	public void Validation_RequiredPortName(string portName, bool isValidExpected)
	{
		var subject = new CM_CargoManifest();
		subject.FlightVoyageNumber = "0f";
		subject.PortFunctionCode = "o";
		subject.PortName = portName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
