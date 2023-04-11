using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BA2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BA2*PT*V*Ba*U*F*N*OX*D*Ed*yRMI2vvh*R";

		var expected = new BA2_BeginningSegmentForCargoTerminalInformation()
		{
			StandardCarrierAlphaCode = "PT",
			VesselCode = "V",
			FlightVoyageNumber = "Ba",
			ReferenceIdentification = "U",
			ReferenceIdentification2 = "F",
			PierNumber = "N",
			PierName = "OX",
			PortOrTerminalFunctionCode = "D",
			PortName = "Ed",
			Date = "yRMI2vvh",
			VesselCodeQualifier = "R",
		};

		var actual = Map.MapObject<BA2_BeginningSegmentForCargoTerminalInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("PT", true)]
	public void Validatation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.VesselCode = "V";
		subject.FlightVoyageNumber = "Ba";
		subject.ReferenceIdentification = "U";
		subject.ReferenceIdentification2 = "F";
		subject.PierNumber = "N";
		subject.PierName = "OX";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validatation_RequiredVesselCode(string vesselCode, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "PT";
		subject.FlightVoyageNumber = "Ba";
		subject.ReferenceIdentification = "U";
		subject.ReferenceIdentification2 = "F";
		subject.PierNumber = "N";
		subject.PierName = "OX";
		subject.VesselCode = vesselCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ba", true)]
	public void Validatation_RequiredFlightVoyageNumber(string flightVoyageNumber, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "PT";
		subject.VesselCode = "V";
		subject.ReferenceIdentification = "U";
		subject.ReferenceIdentification2 = "F";
		subject.PierNumber = "N";
		subject.PierName = "OX";
		subject.FlightVoyageNumber = flightVoyageNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validatation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "PT";
		subject.VesselCode = "V";
		subject.FlightVoyageNumber = "Ba";
		subject.ReferenceIdentification2 = "F";
		subject.PierNumber = "N";
		subject.PierName = "OX";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validatation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "PT";
		subject.VesselCode = "V";
		subject.FlightVoyageNumber = "Ba";
		subject.ReferenceIdentification = "U";
		subject.PierNumber = "N";
		subject.PierName = "OX";
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validatation_RequiredPierNumber(string pierNumber, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "PT";
		subject.VesselCode = "V";
		subject.FlightVoyageNumber = "Ba";
		subject.ReferenceIdentification = "U";
		subject.ReferenceIdentification2 = "F";
		subject.PierName = "OX";
		subject.PierNumber = pierNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("OX", true)]
	public void Validatation_RequiredPierName(string pierName, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "PT";
		subject.VesselCode = "V";
		subject.FlightVoyageNumber = "Ba";
		subject.ReferenceIdentification = "U";
		subject.ReferenceIdentification2 = "F";
		subject.PierNumber = "N";
		subject.PierName = pierName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
