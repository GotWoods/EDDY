using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class CMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CM*FT*9*62*5TExTQ*N*80*zZ*Ss4b12*ns*B*3a*uH*gW*9B*2";

		var expected = new CM_CargoManifest()
		{
			FlightVoyageNumber = "FT",
			PortFunctionCode = "9",
			PortName = "62",
			Date = "5TExTQ",
			BookingNumber = "N",
			StandardCarrierAlphaCode = "80",
			StandardCarrierAlphaCode2 = "zZ",
			Date2 = "Ss4b12",
			VesselName = "ns",
			PierNumber = "B",
			PierName = "3a",
			TerminalName = "uH",
			StateOrProvinceCode = "gW",
			CountryCode = "9B",
			ReferenceIdentification = "2",
		};

		var actual = Map.MapObject<CM_CargoManifest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5TExTQ", "9", true)]
	[InlineData("5TExTQ", "", false)]
	[InlineData("", "9", true)]
	public void Validation_ARequiresBDate(string date, string portFunctionCode, bool isValidExpected)
	{
		var subject = new CM_CargoManifest();
		subject.Date = date;
		subject.PortFunctionCode = portFunctionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
