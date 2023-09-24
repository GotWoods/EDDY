using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class BA2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BA2*tF*R*g1*8*7*Z*fT*j*Vk*EvYnXI*u";

		var expected = new BA2_BeginningSegmentForCargoTerminalInformation()
		{
			StandardCarrierAlphaCode = "tF",
			VesselCode = "R",
			FlightVoyageNumber = "g1",
			ReferenceIdentification = "8",
			ReferenceIdentification2 = "7",
			PierNumber = "Z",
			PierName = "fT",
			PortOrTerminalFunctionCode = "j",
			PortName = "Vk",
			Date = "EvYnXI",
			VesselCodeQualifier = "u",
		};

		var actual = Map.MapObject<BA2_BeginningSegmentForCargoTerminalInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tF", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.VesselCode = "R";
		subject.FlightVoyageNumber = "g1";
		subject.ReferenceIdentification = "8";
		subject.ReferenceIdentification2 = "7";
		subject.PierNumber = "Z";
		subject.PierName = "fT";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredVesselCode(string vesselCode, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "tF";
		subject.FlightVoyageNumber = "g1";
		subject.ReferenceIdentification = "8";
		subject.ReferenceIdentification2 = "7";
		subject.PierNumber = "Z";
		subject.PierName = "fT";
		subject.VesselCode = vesselCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g1", true)]
	public void Validation_RequiredFlightVoyageNumber(string flightVoyageNumber, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "tF";
		subject.VesselCode = "R";
		subject.ReferenceIdentification = "8";
		subject.ReferenceIdentification2 = "7";
		subject.PierNumber = "Z";
		subject.PierName = "fT";
		subject.FlightVoyageNumber = flightVoyageNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "tF";
		subject.VesselCode = "R";
		subject.FlightVoyageNumber = "g1";
		subject.ReferenceIdentification2 = "7";
		subject.PierNumber = "Z";
		subject.PierName = "fT";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7", true)]
	public void Validation_RequiredReferenceIdentification2(string referenceIdentification2, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "tF";
		subject.VesselCode = "R";
		subject.FlightVoyageNumber = "g1";
		subject.ReferenceIdentification = "8";
		subject.PierNumber = "Z";
		subject.PierName = "fT";
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredPierNumber(string pierNumber, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "tF";
		subject.VesselCode = "R";
		subject.FlightVoyageNumber = "g1";
		subject.ReferenceIdentification = "8";
		subject.ReferenceIdentification2 = "7";
		subject.PierName = "fT";
		subject.PierNumber = pierNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fT", true)]
	public void Validation_RequiredPierName(string pierName, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "tF";
		subject.VesselCode = "R";
		subject.FlightVoyageNumber = "g1";
		subject.ReferenceIdentification = "8";
		subject.ReferenceIdentification2 = "7";
		subject.PierNumber = "Z";
		subject.PierName = pierName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
