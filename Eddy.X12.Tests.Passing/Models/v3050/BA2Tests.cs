using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class BA2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BA2*Qf*A*p6*D*A*F*8U*8*ro*rayhKB*1";

		var expected = new BA2_BeginningSegmentForCargoTerminalInformation()
		{
			StandardCarrierAlphaCode = "Qf",
			VesselCode = "A",
			FlightVoyageNumber = "p6",
			ReferenceNumber = "D",
			ReferenceNumber2 = "A",
			PierNumber = "F",
			PierName = "8U",
			PortFunctionCode = "8",
			PortName = "ro",
			Date = "rayhKB",
			VesselCodeQualifier = "1",
		};

		var actual = Map.MapObject<BA2_BeginningSegmentForCargoTerminalInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Qf", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.VesselCode = "A";
		subject.FlightVoyageNumber = "p6";
		subject.ReferenceNumber = "D";
		subject.ReferenceNumber2 = "A";
		subject.PierNumber = "F";
		subject.PierName = "8U";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredVesselCode(string vesselCode, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "Qf";
		subject.FlightVoyageNumber = "p6";
		subject.ReferenceNumber = "D";
		subject.ReferenceNumber2 = "A";
		subject.PierNumber = "F";
		subject.PierName = "8U";
		subject.VesselCode = vesselCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p6", true)]
	public void Validation_RequiredFlightVoyageNumber(string flightVoyageNumber, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "Qf";
		subject.VesselCode = "A";
		subject.ReferenceNumber = "D";
		subject.ReferenceNumber2 = "A";
		subject.PierNumber = "F";
		subject.PierName = "8U";
		subject.FlightVoyageNumber = flightVoyageNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "Qf";
		subject.VesselCode = "A";
		subject.FlightVoyageNumber = "p6";
		subject.ReferenceNumber2 = "A";
		subject.PierNumber = "F";
		subject.PierName = "8U";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredReferenceNumber2(string referenceNumber2, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "Qf";
		subject.VesselCode = "A";
		subject.FlightVoyageNumber = "p6";
		subject.ReferenceNumber = "D";
		subject.PierNumber = "F";
		subject.PierName = "8U";
		subject.ReferenceNumber2 = referenceNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredPierNumber(string pierNumber, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "Qf";
		subject.VesselCode = "A";
		subject.FlightVoyageNumber = "p6";
		subject.ReferenceNumber = "D";
		subject.ReferenceNumber2 = "A";
		subject.PierName = "8U";
		subject.PierNumber = pierNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8U", true)]
	public void Validation_RequiredPierName(string pierName, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "Qf";
		subject.VesselCode = "A";
		subject.FlightVoyageNumber = "p6";
		subject.ReferenceNumber = "D";
		subject.ReferenceNumber2 = "A";
		subject.PierNumber = "F";
		subject.PierName = pierName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
