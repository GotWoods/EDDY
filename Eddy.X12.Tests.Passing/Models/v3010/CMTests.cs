using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class CMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CM*ly*f*Md*7zZqqM*X*qZ*10*jJWN1H*4B*O*qY*ph*Qq*m5";

		var expected = new CM_CargoManifest()
		{
			FlightVoyageNumber = "ly",
			PortFunctionCode = "f",
			PortName = "Md",
			Date = "7zZqqM",
			BookingNumber = "X",
			StandardCarrierAlphaCode = "qZ",
			StandardCarrierAlphaCode2 = "10",
			Date2 = "jJWN1H",
			VesselName = "4B",
			PierNumber = "O",
			PierName = "qY",
			TerminalName = "ph",
			StateOrProvinceCode = "Qq",
			CountryCode = "m5",
		};

		var actual = Map.MapObject<CM_CargoManifest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ly", true)]
	public void Validation_RequiredFlightVoyageNumber(string flightVoyageNumber, bool isValidExpected)
	{
		var subject = new CM_CargoManifest();
		subject.PortFunctionCode = "f";
		subject.PortName = "Md";
		subject.FlightVoyageNumber = flightVoyageNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredPortFunctionCode(string portFunctionCode, bool isValidExpected)
	{
		var subject = new CM_CargoManifest();
		subject.FlightVoyageNumber = "ly";
		subject.PortName = "Md";
		subject.PortFunctionCode = portFunctionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Md", true)]
	public void Validation_RequiredPortName(string portName, bool isValidExpected)
	{
		var subject = new CM_CargoManifest();
		subject.FlightVoyageNumber = "ly";
		subject.PortFunctionCode = "f";
		subject.PortName = portName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
