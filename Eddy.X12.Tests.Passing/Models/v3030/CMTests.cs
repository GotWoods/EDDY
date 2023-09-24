using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class CMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CM*O1*z*Wa*MaT8vz*T*Cr*QS*RiawRu*R9*g*6M*zC*4y*C3";

		var expected = new CM_CargoManifest()
		{
			FlightVoyageNumber = "O1",
			PortFunctionCode = "z",
			PortName = "Wa",
			Date = "MaT8vz",
			BookingNumber = "T",
			StandardCarrierAlphaCode = "Cr",
			StandardCarrierAlphaCode2 = "QS",
			Date2 = "RiawRu",
			VesselName = "R9",
			PierNumber = "g",
			PierName = "6M",
			TerminalName = "zC",
			StateOrProvinceCode = "4y",
			CountryCode = "C3",
		};

		var actual = Map.MapObject<CM_CargoManifest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O1", true)]
	public void Validation_RequiredFlightVoyageNumber(string flightVoyageNumber, bool isValidExpected)
	{
		var subject = new CM_CargoManifest();
		subject.PortFunctionCode = "z";
		subject.PortName = "Wa";
		subject.FlightVoyageNumber = flightVoyageNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredPortFunctionCode(string portFunctionCode, bool isValidExpected)
	{
		var subject = new CM_CargoManifest();
		subject.FlightVoyageNumber = "O1";
		subject.PortName = "Wa";
		subject.PortFunctionCode = portFunctionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Wa", true)]
	public void Validation_RequiredPortName(string portName, bool isValidExpected)
	{
		var subject = new CM_CargoManifest();
		subject.FlightVoyageNumber = "O1";
		subject.PortFunctionCode = "z";
		subject.PortName = portName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
