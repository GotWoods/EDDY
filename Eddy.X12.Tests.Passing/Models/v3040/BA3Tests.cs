using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class BA3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BA3*eA*x*KP*D*y*r*9I*K*8h*O*JaM63w*b";

		var expected = new BA3_BeginningSegmentForDemurrageGuarantee()
		{
			StandardCarrierAlphaCode = "eA",
			VesselCode = "x",
			FlightVoyageNumber = "KP",
			ReferenceNumber = "D",
			ReferenceNumber2 = "y",
			PierNumber = "r",
			PierName = "9I",
			PortFunctionCode = "K",
			PortName = "8h",
			LocationIdentifier = "O",
			ArrivalDate = "JaM63w",
			VesselCodeQualifier = "b",
		};

		var actual = Map.MapObject<BA3_BeginningSegmentForDemurrageGuarantee>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eA", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.VesselCode = "x";
		subject.FlightVoyageNumber = "KP";
		subject.ReferenceNumber = "D";
		subject.ReferenceNumber2 = "y";
		subject.PierNumber = "r";
		subject.PierName = "9I";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredVesselCode(string vesselCode, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "eA";
		subject.FlightVoyageNumber = "KP";
		subject.ReferenceNumber = "D";
		subject.ReferenceNumber2 = "y";
		subject.PierNumber = "r";
		subject.PierName = "9I";
		subject.VesselCode = vesselCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("KP", true)]
	public void Validation_RequiredFlightVoyageNumber(string flightVoyageNumber, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "eA";
		subject.VesselCode = "x";
		subject.ReferenceNumber = "D";
		subject.ReferenceNumber2 = "y";
		subject.PierNumber = "r";
		subject.PierName = "9I";
		subject.FlightVoyageNumber = flightVoyageNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "eA";
		subject.VesselCode = "x";
		subject.FlightVoyageNumber = "KP";
		subject.ReferenceNumber2 = "y";
		subject.PierNumber = "r";
		subject.PierName = "9I";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredReferenceNumber2(string referenceNumber2, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "eA";
		subject.VesselCode = "x";
		subject.FlightVoyageNumber = "KP";
		subject.ReferenceNumber = "D";
		subject.PierNumber = "r";
		subject.PierName = "9I";
		subject.ReferenceNumber2 = referenceNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredPierNumber(string pierNumber, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "eA";
		subject.VesselCode = "x";
		subject.FlightVoyageNumber = "KP";
		subject.ReferenceNumber = "D";
		subject.ReferenceNumber2 = "y";
		subject.PierName = "9I";
		subject.PierNumber = pierNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9I", true)]
	public void Validation_RequiredPierName(string pierName, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "eA";
		subject.VesselCode = "x";
		subject.FlightVoyageNumber = "KP";
		subject.ReferenceNumber = "D";
		subject.ReferenceNumber2 = "y";
		subject.PierNumber = "r";
		subject.PierName = pierName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
