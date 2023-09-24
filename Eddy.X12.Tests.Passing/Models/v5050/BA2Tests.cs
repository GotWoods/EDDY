using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.Tests.Models.v5050;

public class BA2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BA2*0Z*6*bS*g*e*7*Ta*d*tE*6fHJ3xuq*t";

		var expected = new BA2_BeginningSegmentForCargoTerminalInformation()
		{
			StandardCarrierAlphaCode = "0Z",
			VesselCode = "6",
			FlightVoyageNumber = "bS",
			ReferenceIdentification = "g",
			ReferenceIdentification2 = "e",
			PierNumber = "7",
			PierName = "Ta",
			PortOrTerminalFunctionCode = "d",
			PortName = "tE",
			Date = "6fHJ3xuq",
			VesselCodeQualifier = "t",
		};

		var actual = Map.MapObject<BA2_BeginningSegmentForCargoTerminalInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0Z", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.VesselCode = "6";
		subject.FlightVoyageNumber = "bS";
		subject.ReferenceIdentification = "g";
		subject.ReferenceIdentification2 = "e";
		subject.PierNumber = "7";
		subject.PierName = "Ta";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredVesselCode(string vesselCode, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "0Z";
		subject.FlightVoyageNumber = "bS";
		subject.ReferenceIdentification = "g";
		subject.ReferenceIdentification2 = "e";
		subject.PierNumber = "7";
		subject.PierName = "Ta";
		subject.VesselCode = vesselCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bS", true)]
	public void Validation_RequiredFlightVoyageNumber(string flightVoyageNumber, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "0Z";
		subject.VesselCode = "6";
		subject.ReferenceIdentification = "g";
		subject.ReferenceIdentification2 = "e";
		subject.PierNumber = "7";
		subject.PierName = "Ta";
		subject.FlightVoyageNumber = flightVoyageNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "0Z";
		subject.VesselCode = "6";
		subject.FlightVoyageNumber = "bS";
		subject.ReferenceIdentification2 = "e";
		subject.PierNumber = "7";
		subject.PierName = "Ta";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "0Z";
		subject.VesselCode = "6";
		subject.FlightVoyageNumber = "bS";
		subject.ReferenceIdentification = "g";
		subject.PierNumber = "7";
		subject.PierName = "Ta";
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredPierNumber(string pierNumber, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "0Z";
		subject.VesselCode = "6";
		subject.FlightVoyageNumber = "bS";
		subject.ReferenceIdentification = "g";
		subject.ReferenceIdentification2 = "e";
		subject.PierName = "Ta";
		subject.PierNumber = pierNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ta", true)]
	public void Validation_RequiredPierName(string pierName, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "0Z";
		subject.VesselCode = "6";
		subject.FlightVoyageNumber = "bS";
		subject.ReferenceIdentification = "g";
		subject.ReferenceIdentification2 = "e";
		subject.PierNumber = "7";
		subject.PierName = pierName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
