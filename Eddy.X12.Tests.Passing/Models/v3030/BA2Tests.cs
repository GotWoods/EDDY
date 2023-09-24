using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class BA2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BA2*Zi*V*ep*b*G*o*Jl*0*HL*ddhSvZ*y";

		var expected = new BA2_BeginningSegmentForCargoTerminalInformation()
		{
			StandardCarrierAlphaCode = "Zi",
			VesselCode = "V",
			FlightVoyageNumber = "ep",
			ReferenceNumber = "b",
			ReferenceNumber2 = "G",
			PierNumber = "o",
			PierName = "Jl",
			PortFunctionCode = "0",
			PortName = "HL",
			ArrivalDate = "ddhSvZ",
			VesselCodeQualifier = "y",
		};

		var actual = Map.MapObject<BA2_BeginningSegmentForCargoTerminalInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Zi", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.VesselCode = "V";
		subject.FlightVoyageNumber = "ep";
		subject.ReferenceNumber = "b";
		subject.ReferenceNumber2 = "G";
		subject.PierNumber = "o";
		subject.PierName = "Jl";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredVesselCode(string vesselCode, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "Zi";
		subject.FlightVoyageNumber = "ep";
		subject.ReferenceNumber = "b";
		subject.ReferenceNumber2 = "G";
		subject.PierNumber = "o";
		subject.PierName = "Jl";
		subject.VesselCode = vesselCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ep", true)]
	public void Validation_RequiredFlightVoyageNumber(string flightVoyageNumber, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "Zi";
		subject.VesselCode = "V";
		subject.ReferenceNumber = "b";
		subject.ReferenceNumber2 = "G";
		subject.PierNumber = "o";
		subject.PierName = "Jl";
		subject.FlightVoyageNumber = flightVoyageNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "Zi";
		subject.VesselCode = "V";
		subject.FlightVoyageNumber = "ep";
		subject.ReferenceNumber2 = "G";
		subject.PierNumber = "o";
		subject.PierName = "Jl";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredReferenceNumber2(string referenceNumber2, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "Zi";
		subject.VesselCode = "V";
		subject.FlightVoyageNumber = "ep";
		subject.ReferenceNumber = "b";
		subject.PierNumber = "o";
		subject.PierName = "Jl";
		subject.ReferenceNumber2 = referenceNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredPierNumber(string pierNumber, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "Zi";
		subject.VesselCode = "V";
		subject.FlightVoyageNumber = "ep";
		subject.ReferenceNumber = "b";
		subject.ReferenceNumber2 = "G";
		subject.PierName = "Jl";
		subject.PierNumber = pierNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Jl", true)]
	public void Validation_RequiredPierName(string pierName, bool isValidExpected)
	{
		var subject = new BA2_BeginningSegmentForCargoTerminalInformation();
		subject.StandardCarrierAlphaCode = "Zi";
		subject.VesselCode = "V";
		subject.FlightVoyageNumber = "ep";
		subject.ReferenceNumber = "b";
		subject.ReferenceNumber2 = "G";
		subject.PierNumber = "o";
		subject.PierName = pierName;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
