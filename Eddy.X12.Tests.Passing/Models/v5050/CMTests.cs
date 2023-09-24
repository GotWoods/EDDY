using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.Tests.Models.v5050;

public class CMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CM*A9*z*XY*3fUTcfCd*8*fr*rZ*C3DfN6ZB*xS*P*XL*N8*hV*R4*S*pk*q";

		var expected = new CM_CargoManifest()
		{
			FlightVoyageNumber = "A9",
			PortOrTerminalFunctionCode = "z",
			PortName = "XY",
			Date = "3fUTcfCd",
			BookingNumber = "8",
			StandardCarrierAlphaCode = "fr",
			StandardCarrierAlphaCode2 = "rZ",
			Date2 = "C3DfN6ZB",
			VesselName = "xS",
			PierNumber = "P",
			PierName = "XL",
			TerminalName = "N8",
			StateOrProvinceCode = "hV",
			CountryCode = "R4",
			ReferenceIdentification = "S",
			CorrectionIndicator = "pk",
			TransportationMethodTypeCode = "q",
		};

		var actual = Map.MapObject<CM_CargoManifest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("3fUTcfCd", "z", true)]
	[InlineData("3fUTcfCd", "", false)]
	[InlineData("", "z", true)]
	public void Validation_ARequiresBDate(string date, string portOrTerminalFunctionCode, bool isValidExpected)
	{
		var subject = new CM_CargoManifest();
		subject.Date = date;
		subject.PortOrTerminalFunctionCode = portOrTerminalFunctionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
