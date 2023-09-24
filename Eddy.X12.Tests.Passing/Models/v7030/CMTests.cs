using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7030;

namespace Eddy.x12.Tests.Models.v7030;

public class CMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CM*fP*8*YW*IMfpWTQP*J*XX*Zg*8VHP094W*13*4*L8*Xh*jd*wx*V*6V*N";

		var expected = new CM_CargoManifest()
		{
			FlightVoyageNumber = "fP",
			PortOrTerminalFunctionCode = "8",
			PortName = "YW",
			Date = "IMfpWTQP",
			BookingNumber = "J",
			StandardCarrierAlphaCode = "XX",
			StandardCarrierAlphaCode2 = "Zg",
			Date2 = "8VHP094W",
			VesselName = "13",
			PierNumber = "4",
			PierName = "L8",
			TerminalName = "Xh",
			StateOrProvinceCode = "jd",
			CountryCode = "wx",
			ReferenceIdentification = "V",
			CorrectionIndicatorCode = "6V",
			TransportationMethodTypeCode = "N",
		};

		var actual = Map.MapObject<CM_CargoManifest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("IMfpWTQP", "8", true)]
	[InlineData("IMfpWTQP", "", false)]
	[InlineData("", "8", true)]
	public void Validation_ARequiresBDate(string date, string portOrTerminalFunctionCode, bool isValidExpected)
	{
		var subject = new CM_CargoManifest();
		subject.Date = date;
		subject.PortOrTerminalFunctionCode = portOrTerminalFunctionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
