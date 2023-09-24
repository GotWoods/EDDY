using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BA3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BA3*vQ*xuCR*ij*W*D*3*24*j*uW*a*Xm7907*L";

		var expected = new BA3_BeginningSegmentForDemurrageGuarantee()
		{
			StandardCarrierAlphaCode = "vQ",
			VesselCode = "xuCR",
			FlightVoyageNumber = "ij",
			ReferenceNumber = "W",
			ReferenceNumber2 = "D",
			PierNumber = "3",
			PierName = "24",
			PortFunctionCode = "j",
			PortName = "uW",
			LocationIdentifier = "a",
			ArrivalDate = "Xm7907",
			VesselCodeQualifier = "L",
		};

		var actual = Map.MapObject<BA3_BeginningSegmentForDemurrageGuarantee>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vQ", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.VesselCode = "xuCR";
		subject.FlightVoyageNumber = "ij";
		subject.ReferenceNumber = "W";
		subject.ReferenceNumber2 = "D";
		subject.PierNumber = "3";
		subject.PierName = "24";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xuCR", true)]
	public void Validation_RequiredVesselCode(string vesselCode, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "vQ";
		subject.FlightVoyageNumber = "ij";
		subject.ReferenceNumber = "W";
		subject.ReferenceNumber2 = "D";
		subject.PierNumber = "3";
		subject.PierName = "24";
		subject.VesselCode = vesselCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ij", true)]
	public void Validation_RequiredFlightVoyageNumber(string flightVoyageNumber, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "vQ";
		subject.VesselCode = "xuCR";
		subject.ReferenceNumber = "W";
		subject.ReferenceNumber2 = "D";
		subject.PierNumber = "3";
		subject.PierName = "24";
		subject.FlightVoyageNumber = flightVoyageNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "vQ";
		subject.VesselCode = "xuCR";
		subject.FlightVoyageNumber = "ij";
		subject.ReferenceNumber2 = "D";
		subject.PierNumber = "3";
		subject.PierName = "24";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredReferenceNumber2(string referenceNumber2, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "vQ";
		subject.VesselCode = "xuCR";
		subject.FlightVoyageNumber = "ij";
		subject.ReferenceNumber = "W";
		subject.PierNumber = "3";
		subject.PierName = "24";
		subject.ReferenceNumber2 = referenceNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredPierNumber(string pierNumber, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "vQ";
		subject.VesselCode = "xuCR";
		subject.FlightVoyageNumber = "ij";
		subject.ReferenceNumber = "W";
		subject.ReferenceNumber2 = "D";
		subject.PierName = "24";
		subject.PierNumber = pierNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("24", true)]
	public void Validation_RequiredPierName(string pierName, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "vQ";
		subject.VesselCode = "xuCR";
		subject.FlightVoyageNumber = "ij";
		subject.ReferenceNumber = "W";
		subject.ReferenceNumber2 = "D";
		subject.PierNumber = "3";
		subject.PierName = pierName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
