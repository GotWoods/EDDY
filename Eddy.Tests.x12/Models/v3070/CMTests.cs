using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class CMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CM*98*2*ji*4GP6TB*x*02*ss*9vA9Vf*kd*S*DS*yy*kl*Un*t";

		var expected = new CM_CargoManifest()
		{
			FlightVoyageNumber = "98",
			PortOrTerminalFunctionCode = "2",
			PortName = "ji",
			Date = "4GP6TB",
			BookingNumber = "x",
			StandardCarrierAlphaCode = "02",
			StandardCarrierAlphaCode2 = "ss",
			Date2 = "9vA9Vf",
			VesselName = "kd",
			PierNumber = "S",
			PierName = "DS",
			TerminalName = "yy",
			StateOrProvinceCode = "kl",
			CountryCode = "Un",
			ReferenceIdentification = "t",
		};

		var actual = Map.MapObject<CM_CargoManifest>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4GP6TB", "2", true)]
	[InlineData("4GP6TB", "", false)]
	[InlineData("", "2", true)]
	public void Validation_ARequiresBDate(string date, string portOrTerminalFunctionCode, bool isValidExpected)
	{
		var subject = new CM_CargoManifest();
		subject.Date = date;
		subject.PortOrTerminalFunctionCode = portOrTerminalFunctionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
