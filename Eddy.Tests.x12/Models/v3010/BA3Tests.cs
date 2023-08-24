using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BA3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BA3*hm*Hx7E*B7*5*R*s*dW*f*DV*D*mvpOTT*o";

		var expected = new BA3_BeginningSegmentForDemurrageGuarantee()
		{
			StandardCarrierAlphaCode = "hm",
			VesselCode = "Hx7E",
			FlightVoyageNumber = "B7",
			ReferenceNumber = "5",
			ReferenceNumber2 = "R",
			PierNumber = "s",
			PierName = "dW",
			PortFunctionCode = "f",
			PortName = "DV",
			LocationIdentifier = "D",
			ArrivalDate = "mvpOTT",
			VesselCodeQualifier = "o",
		};

		var actual = Map.MapObject<BA3_BeginningSegmentForDemurrageGuarantee>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hm", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.VesselCode = "Hx7E";
		subject.FlightVoyageNumber = "B7";
		subject.ReferenceNumber = "5";
		subject.ReferenceNumber2 = "R";
		subject.PierNumber = "s";
		subject.PierName = "dW";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Hx7E", true)]
	public void Validation_RequiredVesselCode(string vesselCode, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "hm";
		subject.FlightVoyageNumber = "B7";
		subject.ReferenceNumber = "5";
		subject.ReferenceNumber2 = "R";
		subject.PierNumber = "s";
		subject.PierName = "dW";
		subject.VesselCode = vesselCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B7", true)]
	public void Validation_RequiredFlightVoyageNumber(string flightVoyageNumber, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "hm";
		subject.VesselCode = "Hx7E";
		subject.ReferenceNumber = "5";
		subject.ReferenceNumber2 = "R";
		subject.PierNumber = "s";
		subject.PierName = "dW";
		subject.FlightVoyageNumber = flightVoyageNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "hm";
		subject.VesselCode = "Hx7E";
		subject.FlightVoyageNumber = "B7";
		subject.ReferenceNumber2 = "R";
		subject.PierNumber = "s";
		subject.PierName = "dW";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredReferenceNumber2(string referenceNumber2, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "hm";
		subject.VesselCode = "Hx7E";
		subject.FlightVoyageNumber = "B7";
		subject.ReferenceNumber = "5";
		subject.PierNumber = "s";
		subject.PierName = "dW";
		subject.ReferenceNumber2 = referenceNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredPierNumber(string pierNumber, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "hm";
		subject.VesselCode = "Hx7E";
		subject.FlightVoyageNumber = "B7";
		subject.ReferenceNumber = "5";
		subject.ReferenceNumber2 = "R";
		subject.PierName = "dW";
		subject.PierNumber = pierNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dW", true)]
	public void Validation_RequiredPierName(string pierName, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "hm";
		subject.VesselCode = "Hx7E";
		subject.FlightVoyageNumber = "B7";
		subject.ReferenceNumber = "5";
		subject.ReferenceNumber2 = "R";
		subject.PierNumber = "s";
		subject.PierName = pierName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
