using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BA2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BA2*hb*U*1u*K*u*K*pj*q*B0*tevRkZdP*B";

		var expected = new BA2_BeginningSegmentForCargoTerminalInformation()
		{
			StandardCarrierAlphaCode = "hb",
			VesselCode = "U",
			FlightVoyageNumber = "1u",
			ReferenceIdentification = "K",
			ReferenceIdentification2 = "u",
			PierNumber = "K",
			PierName = "pj",
			PortOrTerminalFunctionCode = "q",
			PortName = "B0",
			Date = "tevRkZdP",
			VesselCodeQualifier = "B",
		};

		var actual = Map.MapObject<BA2_BeginningSegmentForCargoTerminalInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hb", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.VesselCode = "U";
		subject.FlightVoyageNumber = "1u";
		subject.ReferenceIdentification = "K";
		subject.ReferenceIdentification2 = "u";
		subject.PierNumber = "K";
		subject.PierName = "pj";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validation_RequiredVesselCode(string vesselCode, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "hb";
		subject.FlightVoyageNumber = "1u";
		subject.ReferenceIdentification = "K";
		subject.ReferenceIdentification2 = "u";
		subject.PierNumber = "K";
		subject.PierName = "pj";
		subject.VesselCode = vesselCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1u", true)]
	public void Validation_RequiredFlightVoyageNumber(string flightVoyageNumber, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "hb";
		subject.VesselCode = "U";
		subject.ReferenceIdentification = "K";
		subject.ReferenceIdentification2 = "u";
		subject.PierNumber = "K";
		subject.PierName = "pj";
		subject.FlightVoyageNumber = flightVoyageNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "hb";
		subject.VesselCode = "U";
		subject.FlightVoyageNumber = "1u";
		subject.ReferenceIdentification2 = "u";
		subject.PierNumber = "K";
		subject.PierName = "pj";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "hb";
		subject.VesselCode = "U";
		subject.FlightVoyageNumber = "1u";
		subject.ReferenceIdentification = "K";
		subject.PierNumber = "K";
		subject.PierName = "pj";
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredPierNumber(string pierNumber, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "hb";
		subject.VesselCode = "U";
		subject.FlightVoyageNumber = "1u";
		subject.ReferenceIdentification = "K";
		subject.ReferenceIdentification2 = "u";
		subject.PierName = "pj";
		subject.PierNumber = pierNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pj", true)]
	public void Validation_RequiredPierName(string pierName, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "hb";
		subject.VesselCode = "U";
		subject.FlightVoyageNumber = "1u";
		subject.ReferenceIdentification = "K";
		subject.ReferenceIdentification2 = "u";
		subject.PierNumber = "K";
		subject.PierName = pierName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
