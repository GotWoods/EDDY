using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class CMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CM*a4*Q*gK*5CZcoy2F*4*HI*EF*0TAFRb0y*8E*Y*41*Uy*Tt*hb*R*XC*M";

		var expected = new CM_CargoManifest()
		{
			FlightVoyageNumber = "a4",
			PortOrTerminalFunctionCode = "Q",
			PortName = "gK",
			Date = "5CZcoy2F",
			BookingNumber = "4",
			StandardCarrierAlphaCode = "HI",
			StandardCarrierAlphaCode2 = "EF",
			Date2 = "0TAFRb0y",
			VesselName = "8E",
			PierNumber = "Y",
			PierName = "41",
			TerminalName = "Uy",
			StateOrProvinceCode = "Tt",
			CountryCode = "hb",
			ReferenceIdentification = "R",
			CorrectionIndicatorCode = "XC",
			TransportationMethodTypeCode = "M",
		};

		var actual = Map.MapObject<CM_CargoManifest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5CZcoy2F", "Q", true)]
	[InlineData("5CZcoy2F", "", false)]
	[InlineData("", "Q", true)]
	public void Validation_ARequiresBDate(string date, string portOrTerminalFunctionCode, bool isValidExpected)
	{
		var subject = new CM_CargoManifest();
		subject.Date = date;
		subject.PortOrTerminalFunctionCode = portOrTerminalFunctionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
