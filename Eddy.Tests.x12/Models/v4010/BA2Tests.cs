using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BA2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BA2*GJ*4*Fc*o*v*g*NW*E*2S*hbUt4p5D*H";

		var expected = new BA2_BeginningSegmentForCargoTerminalInformation()
		{
			StandardCarrierAlphaCode = "GJ",
			VesselCode = "4",
			FlightVoyageNumber = "Fc",
			ReferenceIdentification = "o",
			ReferenceIdentification2 = "v",
			PierNumber = "g",
			PierName = "NW",
			PortOrTerminalFunctionCode = "E",
			PortName = "2S",
			Date = "hbUt4p5D",
			VesselCodeQualifier = "H",
		};

		var actual = Map.MapObject<BA2_BeginningSegmentForCargoTerminalInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GJ", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.VesselCode = "4";
		subject.FlightVoyageNumber = "Fc";
		subject.ReferenceIdentification = "o";
		subject.ReferenceIdentification2 = "v";
		subject.PierNumber = "g";
		subject.PierName = "NW";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredVesselCode(string vesselCode, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "GJ";
		subject.FlightVoyageNumber = "Fc";
		subject.ReferenceIdentification = "o";
		subject.ReferenceIdentification2 = "v";
		subject.PierNumber = "g";
		subject.PierName = "NW";
		subject.VesselCode = vesselCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Fc", true)]
	public void Validation_RequiredFlightVoyageNumber(string flightVoyageNumber, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "GJ";
		subject.VesselCode = "4";
		subject.ReferenceIdentification = "o";
		subject.ReferenceIdentification2 = "v";
		subject.PierNumber = "g";
		subject.PierName = "NW";
		subject.FlightVoyageNumber = flightVoyageNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "GJ";
		subject.VesselCode = "4";
		subject.FlightVoyageNumber = "Fc";
		subject.ReferenceIdentification2 = "v";
		subject.PierNumber = "g";
		subject.PierName = "NW";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "GJ";
		subject.VesselCode = "4";
		subject.FlightVoyageNumber = "Fc";
		subject.ReferenceIdentification = "o";
		subject.PierNumber = "g";
		subject.PierName = "NW";
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredPierNumber(string pierNumber, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "GJ";
		subject.VesselCode = "4";
		subject.FlightVoyageNumber = "Fc";
		subject.ReferenceIdentification = "o";
		subject.ReferenceIdentification2 = "v";
		subject.PierName = "NW";
		subject.PierNumber = pierNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NW", true)]
	public void Validation_RequiredPierName(string pierName, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "GJ";
		subject.VesselCode = "4";
		subject.FlightVoyageNumber = "Fc";
		subject.ReferenceIdentification = "o";
		subject.ReferenceIdentification2 = "v";
		subject.PierNumber = "g";
		subject.PierName = pierName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
