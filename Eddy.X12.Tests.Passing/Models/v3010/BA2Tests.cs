using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BA2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BA2*yk*misI*mv*L*Q*N*T5*m*8S*6qfYgx*w";

		var expected = new BA2_BeginningSegmentForCargoTerminalInformation()
		{
			StandardCarrierAlphaCode = "yk",
			VesselCode = "misI",
			FlightVoyageNumber = "mv",
			ReferenceNumber = "L",
			ReferenceNumber2 = "Q",
			PierNumber = "N",
			PierName = "T5",
			PortFunctionCode = "m",
			PortName = "8S",
			ArrivalDate = "6qfYgx",
			VesselCodeQualifier = "w",
		};

		var actual = Map.MapObject<BA2_BeginningSegmentForCargoTerminalInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yk", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.VesselCode = "misI";
		subject.FlightVoyageNumber = "mv";
		subject.ReferenceNumber = "L";
		subject.ReferenceNumber2 = "Q";
		subject.PierNumber = "N";
		subject.PierName = "T5";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("misI", true)]
	public void Validation_RequiredVesselCode(string vesselCode, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "yk";
		subject.FlightVoyageNumber = "mv";
		subject.ReferenceNumber = "L";
		subject.ReferenceNumber2 = "Q";
		subject.PierNumber = "N";
		subject.PierName = "T5";
		subject.VesselCode = vesselCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mv", true)]
	public void Validation_RequiredFlightVoyageNumber(string flightVoyageNumber, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "yk";
		subject.VesselCode = "misI";
		subject.ReferenceNumber = "L";
		subject.ReferenceNumber2 = "Q";
		subject.PierNumber = "N";
		subject.PierName = "T5";
		subject.FlightVoyageNumber = flightVoyageNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "yk";
		subject.VesselCode = "misI";
		subject.FlightVoyageNumber = "mv";
		subject.ReferenceNumber2 = "Q";
		subject.PierNumber = "N";
		subject.PierName = "T5";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredReferenceNumber2(string referenceNumber2, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "yk";
		subject.VesselCode = "misI";
		subject.FlightVoyageNumber = "mv";
		subject.ReferenceNumber = "L";
		subject.PierNumber = "N";
		subject.PierName = "T5";
		subject.ReferenceNumber2 = referenceNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredPierNumber(string pierNumber, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "yk";
		subject.VesselCode = "misI";
		subject.FlightVoyageNumber = "mv";
		subject.ReferenceNumber = "L";
		subject.ReferenceNumber2 = "Q";
		subject.PierName = "T5";
		subject.PierNumber = pierNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T5", true)]
	public void Validation_RequiredPierName(string pierName, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "yk";
		subject.VesselCode = "misI";
		subject.FlightVoyageNumber = "mv";
		subject.ReferenceNumber = "L";
		subject.ReferenceNumber2 = "Q";
		subject.PierNumber = "N";
		subject.PierName = pierName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
