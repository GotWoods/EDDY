using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CM*A1*4*vq*tgV5yt3s*x*KD*Fy*OBk9tcVL*lB*e*5P*3s*q1*GD*i*OQ*e";

		var expected = new CM_CargoManifest()
		{
			FlightVoyageNumber = "A1",
			PortOrTerminalFunctionCode = "4",
			PortName = "vq",
			Date = "tgV5yt3s",
			BookingNumber = "x",
			StandardCarrierAlphaCode = "KD",
			StandardCarrierAlphaCode2 = "Fy",
			Date2 = "OBk9tcVL",
			VesselName = "lB",
			PierNumber = "e",
			PierName = "5P",
			TerminalName = "3s",
			StateOrProvinceCode = "q1",
			CountryCode = "GD",
			ReferenceIdentification = "i",
			CorrectionIndicatorCode = "OQ",
			TransportationMethodTypeCode = "e",
		};

		var actual = Map.MapObject<CM_CargoManifest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "4", true)]
	[InlineData("tgV5yt3s", "", false)]
	public void Validation_ARequiresBDate(string date, string portOrTerminalFunctionCode, bool isValidExpected)
	{
		var subject = new CM_CargoManifest();
		subject.Date = date;
		subject.PortOrTerminalFunctionCode = portOrTerminalFunctionCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
