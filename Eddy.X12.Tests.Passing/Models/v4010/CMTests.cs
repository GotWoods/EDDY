using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class CMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CM*x5*f*lH*hLBx0awo*d*Cr*UB*LgUz8fvL*tT*j*It*03*Eu*mh*Y*1i*r";

		var expected = new CM_CargoManifest()
		{
			FlightVoyageNumber = "x5",
			PortOrTerminalFunctionCode = "f",
			PortName = "lH",
			Date = "hLBx0awo",
			BookingNumber = "d",
			StandardCarrierAlphaCode = "Cr",
			StandardCarrierAlphaCode2 = "UB",
			Date2 = "LgUz8fvL",
			VesselName = "tT",
			PierNumber = "j",
			PierName = "It",
			TerminalName = "03",
			StateOrProvinceCode = "Eu",
			CountryCode = "mh",
			ReferenceIdentification = "Y",
			CorrectionIndicator = "1i",
			TransportationMethodTypeCode = "r",
		};

		var actual = Map.MapObject<CM_CargoManifest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("hLBx0awo", "f", true)]
	[InlineData("hLBx0awo", "", false)]
	[InlineData("", "f", true)]
	public void Validation_ARequiresBDate(string date, string portOrTerminalFunctionCode, bool isValidExpected)
	{
		var subject = new CM_CargoManifest();
		subject.Date = date;
		subject.PortOrTerminalFunctionCode = portOrTerminalFunctionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
