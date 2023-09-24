using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class CMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CM*mm*C*rZ*naCm78x7*1*oR*es*ihagWbeg*ZW*O*m6*hM*jB*xj*S*A3*p";

		var expected = new CM_CargoManifest()
		{
			FlightVoyageNumber = "mm",
			PortOrTerminalFunctionCode = "C",
			PortName = "rZ",
			Date = "naCm78x7",
			BookingNumber = "1",
			StandardCarrierAlphaCode = "oR",
			StandardCarrierAlphaCode2 = "es",
			Date2 = "ihagWbeg",
			VesselName = "ZW",
			PierNumber = "O",
			PierName = "m6",
			TerminalName = "hM",
			StateOrProvinceCode = "jB",
			CountryCode = "xj",
			ReferenceIdentification = "S",
			CorrectionIndicator = "A3",
			TransportationMethodTypeCode = "p",
		};

		var actual = Map.MapObject<CM_CargoManifest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("naCm78x7", "C", true)]
	[InlineData("naCm78x7", "", false)]
	[InlineData("", "C", true)]
	public void Validation_ARequiresBDate(string date, string portOrTerminalFunctionCode, bool isValidExpected)
	{
		var subject = new CM_CargoManifest();
		subject.Date = date;
		subject.PortOrTerminalFunctionCode = portOrTerminalFunctionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
