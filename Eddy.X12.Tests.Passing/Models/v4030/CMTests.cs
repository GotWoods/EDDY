using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class CMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CM*ID*B*Ih*qMbsx31W*Q*3h*Ko*lCv5r7Ya*yP*M*gW*ok*S9*Vz*W*CS*r";

		var expected = new CM_CargoManifest()
		{
			FlightVoyageNumber = "ID",
			PortOrTerminalFunctionCode = "B",
			PortName = "Ih",
			Date = "qMbsx31W",
			BookingNumber = "Q",
			StandardCarrierAlphaCode = "3h",
			StandardCarrierAlphaCode2 = "Ko",
			Date2 = "lCv5r7Ya",
			VesselName = "yP",
			PierNumber = "M",
			PierName = "gW",
			TerminalName = "ok",
			StateOrProvinceCode = "S9",
			CountryCode = "Vz",
			ReferenceIdentification = "W",
			CorrectionIndicator = "CS",
			TransportationMethodTypeCode = "r",
		};

		var actual = Map.MapObject<CM_CargoManifest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("qMbsx31W", "B", true)]
	[InlineData("qMbsx31W", "", false)]
	[InlineData("", "B", true)]
	public void Validation_ARequiresBDate(string date, string portOrTerminalFunctionCode, bool isValidExpected)
	{
		var subject = new CM_CargoManifest();
		subject.Date = date;
		subject.PortOrTerminalFunctionCode = portOrTerminalFunctionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
