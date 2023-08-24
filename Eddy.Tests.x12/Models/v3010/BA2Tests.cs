using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BA2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BA2*WB*AJFv*Os*e*a*q*wS*L*xO*6GMbHP*B";

		var expected = new BA2_BeginningSegmentForCargoTerminalInformation()
		{
			StandardCarrierAlphaCode = "WB",
			VesselCode = "AJFv",
			FlightVoyageNumber = "Os",
			ReferenceNumber = "e",
			ReferenceNumber2 = "a",
			PierNumber = "q",
			PierName = "wS",
			PortFunctionCode = "L",
			PortName = "xO",
			ArrivalDate = "6GMbHP",
			VesselCodeQualifier = "B",
		};

		var actual = Map.MapObject<BA2_BeginningSegmentForCargoTerminalInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("WB", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.VesselCode = "AJFv";
		subject.FlightVoyageNumber = "Os";
		subject.ReferenceNumber = "e";
		subject.ReferenceNumber2 = "a";
		subject.PierNumber = "q";
		subject.PierName = "wS";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AJFv", true)]
	public void Validation_RequiredVesselCode(string vesselCode, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "WB";
		subject.FlightVoyageNumber = "Os";
		subject.ReferenceNumber = "e";
		subject.ReferenceNumber2 = "a";
		subject.PierNumber = "q";
		subject.PierName = "wS";
		subject.VesselCode = vesselCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Os", true)]
	public void Validation_RequiredFlightVoyageNumber(string flightVoyageNumber, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "WB";
		subject.VesselCode = "AJFv";
		subject.ReferenceNumber = "e";
		subject.ReferenceNumber2 = "a";
		subject.PierNumber = "q";
		subject.PierName = "wS";
		subject.FlightVoyageNumber = flightVoyageNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "WB";
		subject.VesselCode = "AJFv";
		subject.FlightVoyageNumber = "Os";
		subject.ReferenceNumber2 = "a";
		subject.PierNumber = "q";
		subject.PierName = "wS";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredReferenceNumber2(string referenceNumber2, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "WB";
		subject.VesselCode = "AJFv";
		subject.FlightVoyageNumber = "Os";
		subject.ReferenceNumber = "e";
		subject.PierNumber = "q";
		subject.PierName = "wS";
		subject.ReferenceNumber2 = referenceNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredPierNumber(string pierNumber, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "WB";
		subject.VesselCode = "AJFv";
		subject.FlightVoyageNumber = "Os";
		subject.ReferenceNumber = "e";
		subject.ReferenceNumber2 = "a";
		subject.PierName = "wS";
		subject.PierNumber = pierNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wS", true)]
	public void Validation_RequiredPierName(string pierName, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "WB";
		subject.VesselCode = "AJFv";
		subject.FlightVoyageNumber = "Os";
		subject.ReferenceNumber = "e";
		subject.ReferenceNumber2 = "a";
		subject.PierNumber = "q";
		subject.PierName = pierName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
