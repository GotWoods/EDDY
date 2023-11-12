using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class BA3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BA3*r4*V*kG*2*7*3*MI*7*fG*e*pkHcoi*c";

		var expected = new BA3_BeginningSegmentForDemurrageGuarantee()
		{
			StandardCarrierAlphaCode = "r4",
			VesselCode = "V",
			FlightVoyageNumber = "kG",
			ReferenceNumber = "2",
			ReferenceNumber2 = "7",
			PierNumber = "3",
			PierName = "MI",
			PortFunctionCode = "7",
			PortName = "fG",
			LocationIdentifier = "e",
			ArrivalDate = "pkHcoi",
			VesselCodeQualifier = "c",
		};

		var actual = Map.MapObject<BA3_BeginningSegmentForDemurrageGuarantee>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r4", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.VesselCode = "V";
		subject.FlightVoyageNumber = "kG";
		subject.ReferenceNumber = "2";
		subject.ReferenceNumber2 = "7";
		subject.PierNumber = "3";
		subject.PierName = "MI";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredVesselCode(string vesselCode, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "r4";
		subject.FlightVoyageNumber = "kG";
		subject.ReferenceNumber = "2";
		subject.ReferenceNumber2 = "7";
		subject.PierNumber = "3";
		subject.PierName = "MI";
		subject.VesselCode = vesselCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kG", true)]
	public void Validation_RequiredFlightVoyageNumber(string flightVoyageNumber, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "r4";
		subject.VesselCode = "V";
		subject.ReferenceNumber = "2";
		subject.ReferenceNumber2 = "7";
		subject.PierNumber = "3";
		subject.PierName = "MI";
		subject.FlightVoyageNumber = flightVoyageNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "r4";
		subject.VesselCode = "V";
		subject.FlightVoyageNumber = "kG";
		subject.ReferenceNumber2 = "7";
		subject.PierNumber = "3";
		subject.PierName = "MI";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredReferenceNumber2(string referenceNumber2, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "r4";
		subject.VesselCode = "V";
		subject.FlightVoyageNumber = "kG";
		subject.ReferenceNumber = "2";
		subject.PierNumber = "3";
		subject.PierName = "MI";
		subject.ReferenceNumber2 = referenceNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredPierNumber(string pierNumber, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "r4";
		subject.VesselCode = "V";
		subject.FlightVoyageNumber = "kG";
		subject.ReferenceNumber = "2";
		subject.ReferenceNumber2 = "7";
		subject.PierName = "MI";
		subject.PierNumber = pierNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MI", true)]
	public void Validation_RequiredPierName(string pierName, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "r4";
		subject.VesselCode = "V";
		subject.FlightVoyageNumber = "kG";
		subject.ReferenceNumber = "2";
		subject.ReferenceNumber2 = "7";
		subject.PierNumber = "3";
		subject.PierName = pierName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
