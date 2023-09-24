using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BA3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BA3*Gx*f*Zj*b*G*I*kx*P*jD*d*dldR6G*E";

		var expected = new BA3_BeginningSegmentForDemurrageGuarantee()
		{
			StandardCarrierAlphaCode = "Gx",
			VesselCode = "f",
			FlightVoyageNumber = "Zj",
			ReferenceIdentification = "b",
			ReferenceIdentification2 = "G",
			PierNumber = "I",
			PierName = "kx",
			PortFunctionCode = "P",
			PortName = "jD",
			LocationIdentifier = "d",
			Date = "dldR6G",
			VesselCodeQualifier = "E",
		};

		var actual = Map.MapObject<BA3_BeginningSegmentForDemurrageGuarantee>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Gx", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.VesselCode = "f";
		subject.FlightVoyageNumber = "Zj";
		subject.ReferenceIdentification = "b";
		subject.ReferenceIdentification2 = "G";
		subject.PierNumber = "I";
		subject.PierName = "kx";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredVesselCode(string vesselCode, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "Gx";
		subject.FlightVoyageNumber = "Zj";
		subject.ReferenceIdentification = "b";
		subject.ReferenceIdentification2 = "G";
		subject.PierNumber = "I";
		subject.PierName = "kx";
		subject.VesselCode = vesselCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Zj", true)]
	public void Validation_RequiredFlightVoyageNumber(string flightVoyageNumber, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "Gx";
		subject.VesselCode = "f";
		subject.ReferenceIdentification = "b";
		subject.ReferenceIdentification2 = "G";
		subject.PierNumber = "I";
		subject.PierName = "kx";
		subject.FlightVoyageNumber = flightVoyageNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "Gx";
		subject.VesselCode = "f";
		subject.FlightVoyageNumber = "Zj";
		subject.ReferenceIdentification2 = "G";
		subject.PierNumber = "I";
		subject.PierName = "kx";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "Gx";
		subject.VesselCode = "f";
		subject.FlightVoyageNumber = "Zj";
		subject.ReferenceIdentification = "b";
		subject.PierNumber = "I";
		subject.PierName = "kx";
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredPierNumber(string pierNumber, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "Gx";
		subject.VesselCode = "f";
		subject.FlightVoyageNumber = "Zj";
		subject.ReferenceIdentification = "b";
		subject.ReferenceIdentification2 = "G";
		subject.PierName = "kx";
		subject.PierNumber = pierNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kx", true)]
	public void Validation_RequiredPierName(string pierName, bool isValidExpected)
	{
		var subject = new BA3_BeginningSegmentForDemurrageGuarantee();
		subject.StandardCarrierAlphaCode = "Gx";
		subject.VesselCode = "f";
		subject.FlightVoyageNumber = "Zj";
		subject.ReferenceIdentification = "b";
		subject.ReferenceIdentification2 = "G";
		subject.PierNumber = "I";
		subject.PierName = pierName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
