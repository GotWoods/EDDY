using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BA2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BA2*73*4*Yg*W*S*G*fo*3*qt*JrGaWR*e";

		var expected = new BA2_BeginningSegmentForCargoTerminalInformation()
		{
			StandardCarrierAlphaCode = "73",
			VesselCode = "4",
			FlightVoyageNumber = "Yg",
			ReferenceIdentification = "W",
			ReferenceIdentification2 = "S",
			PierNumber = "G",
			PierName = "fo",
			PortFunctionCode = "3",
			PortName = "qt",
			Date = "JrGaWR",
			VesselCodeQualifier = "e",
		};

		var actual = Map.MapObject<BA2_BeginningSegmentForCargoTerminalInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("73", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.VesselCode = "4";
		subject.FlightVoyageNumber = "Yg";
		subject.ReferenceIdentification = "W";
		subject.ReferenceIdentification2 = "S";
		subject.PierNumber = "G";
		subject.PierName = "fo";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredVesselCode(string vesselCode, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "73";
		subject.FlightVoyageNumber = "Yg";
		subject.ReferenceIdentification = "W";
		subject.ReferenceIdentification2 = "S";
		subject.PierNumber = "G";
		subject.PierName = "fo";
		subject.VesselCode = vesselCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Yg", true)]
	public void Validation_RequiredFlightVoyageNumber(string flightVoyageNumber, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "73";
		subject.VesselCode = "4";
		subject.ReferenceIdentification = "W";
		subject.ReferenceIdentification2 = "S";
		subject.PierNumber = "G";
		subject.PierName = "fo";
		subject.FlightVoyageNumber = flightVoyageNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "73";
		subject.VesselCode = "4";
		subject.FlightVoyageNumber = "Yg";
		subject.ReferenceIdentification2 = "S";
		subject.PierNumber = "G";
		subject.PierName = "fo";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "73";
		subject.VesselCode = "4";
		subject.FlightVoyageNumber = "Yg";
		subject.ReferenceIdentification = "W";
		subject.PierNumber = "G";
		subject.PierName = "fo";
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredPierNumber(string pierNumber, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "73";
		subject.VesselCode = "4";
		subject.FlightVoyageNumber = "Yg";
		subject.ReferenceIdentification = "W";
		subject.ReferenceIdentification2 = "S";
		subject.PierName = "fo";
		subject.PierNumber = pierNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fo", true)]
	public void Validation_RequiredPierName(string pierName, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "73";
		subject.VesselCode = "4";
		subject.FlightVoyageNumber = "Yg";
		subject.ReferenceIdentification = "W";
		subject.ReferenceIdentification2 = "S";
		subject.PierNumber = "G";
		subject.PierName = pierName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
