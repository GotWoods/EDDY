using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class BA3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BA3*Fx*J*2C*l*q*s*3u*f*L2*c*3eUG6d*7";

		var expected = new BA3_BeginningSegmentForDemurrageGuarantee()
		{
			StandardCarrierAlphaCode = "Fx",
			VesselCode = "J",
			FlightVoyageNumber = "2C",
			ReferenceNumber = "l",
			ReferenceNumber2 = "q",
			PierNumber = "s",
			PierName = "3u",
			PortFunctionCode = "f",
			PortName = "L2",
			LocationIdentifier = "c",
			Date = "3eUG6d",
			VesselCodeQualifier = "7",
		};

		var actual = Map.MapObject<BA3_BeginningSegmentForDemurrageGuarantee>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Fx", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.VesselCode = "J";
		subject.FlightVoyageNumber = "2C";
		subject.ReferenceNumber = "l";
		subject.ReferenceNumber2 = "q";
		subject.PierNumber = "s";
		subject.PierName = "3u";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredVesselCode(string vesselCode, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "Fx";
		subject.FlightVoyageNumber = "2C";
		subject.ReferenceNumber = "l";
		subject.ReferenceNumber2 = "q";
		subject.PierNumber = "s";
		subject.PierName = "3u";
		subject.VesselCode = vesselCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2C", true)]
	public void Validation_RequiredFlightVoyageNumber(string flightVoyageNumber, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "Fx";
		subject.VesselCode = "J";
		subject.ReferenceNumber = "l";
		subject.ReferenceNumber2 = "q";
		subject.PierNumber = "s";
		subject.PierName = "3u";
		subject.FlightVoyageNumber = flightVoyageNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "Fx";
		subject.VesselCode = "J";
		subject.FlightVoyageNumber = "2C";
		subject.ReferenceNumber2 = "q";
		subject.PierNumber = "s";
		subject.PierName = "3u";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredReferenceNumber2(string referenceNumber2, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "Fx";
		subject.VesselCode = "J";
		subject.FlightVoyageNumber = "2C";
		subject.ReferenceNumber = "l";
		subject.PierNumber = "s";
		subject.PierName = "3u";
		subject.ReferenceNumber2 = referenceNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredPierNumber(string pierNumber, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "Fx";
		subject.VesselCode = "J";
		subject.FlightVoyageNumber = "2C";
		subject.ReferenceNumber = "l";
		subject.ReferenceNumber2 = "q";
		subject.PierName = "3u";
		subject.PierNumber = pierNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3u", true)]
	public void Validation_RequiredPierName(string pierName, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "Fx";
		subject.VesselCode = "J";
		subject.FlightVoyageNumber = "2C";
		subject.ReferenceNumber = "l";
		subject.ReferenceNumber2 = "q";
		subject.PierNumber = "s";
		subject.PierName = pierName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
