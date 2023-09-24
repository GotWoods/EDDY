using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BA2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BA2*9X*C*uA*A*q*u*2Z*2*Nf*RIoyOM5K*E";

		var expected = new BA2_BeginningSegmentForCargoTerminalInformation()
		{
			StandardCarrierAlphaCode = "9X",
			VesselCode = "C",
			FlightVoyageNumber = "uA",
			ReferenceIdentification = "A",
			ReferenceIdentification2 = "q",
			PierNumber = "u",
			PierName = "2Z",
			PortOrTerminalFunctionCode = "2",
			PortName = "Nf",
			Date = "RIoyOM5K",
			VesselCodeQualifier = "E",
		};

		var actual = Map.MapObject<BA2_BeginningSegmentForCargoTerminalInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9X", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.VesselCode = "C";
		subject.FlightVoyageNumber = "uA";
		subject.ReferenceIdentification = "A";
		subject.ReferenceIdentification2 = "q";
		subject.PierNumber = "u";
		subject.PierName = "2Z";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredVesselCode(string vesselCode, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "9X";
		subject.FlightVoyageNumber = "uA";
		subject.ReferenceIdentification = "A";
		subject.ReferenceIdentification2 = "q";
		subject.PierNumber = "u";
		subject.PierName = "2Z";
		subject.VesselCode = vesselCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uA", true)]
	public void Validation_RequiredFlightVoyageNumber(string flightVoyageNumber, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "9X";
		subject.VesselCode = "C";
		subject.ReferenceIdentification = "A";
		subject.ReferenceIdentification2 = "q";
		subject.PierNumber = "u";
		subject.PierName = "2Z";
		subject.FlightVoyageNumber = flightVoyageNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "9X";
		subject.VesselCode = "C";
		subject.FlightVoyageNumber = "uA";
		subject.ReferenceIdentification2 = "q";
		subject.PierNumber = "u";
		subject.PierName = "2Z";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "9X";
		subject.VesselCode = "C";
		subject.FlightVoyageNumber = "uA";
		subject.ReferenceIdentification = "A";
		subject.PierNumber = "u";
		subject.PierName = "2Z";
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredPierNumber(string pierNumber, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "9X";
		subject.VesselCode = "C";
		subject.FlightVoyageNumber = "uA";
		subject.ReferenceIdentification = "A";
		subject.ReferenceIdentification2 = "q";
		subject.PierName = "2Z";
		subject.PierNumber = pierNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2Z", true)]
	public void Validation_RequiredPierName(string pierName, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "9X";
		subject.VesselCode = "C";
		subject.FlightVoyageNumber = "uA";
		subject.ReferenceIdentification = "A";
		subject.ReferenceIdentification2 = "q";
		subject.PierNumber = "u";
		subject.PierName = pierName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
