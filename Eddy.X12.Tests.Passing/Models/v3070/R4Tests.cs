using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class R4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R4*P*W*9*pj*qX*Io*e*aw";

		var expected = new R4_PortOrTerminal()
		{
			PortOrTerminalFunctionCode = "P",
			LocationQualifier = "W",
			LocationIdentifier = "9",
			PortName = "pj",
			CountryCode = "qX",
			TerminalName = "Io",
			PierNumber = "e",
			StateOrProvinceCode = "aw",
		};

		var actual = Map.MapObject<R4_PortOrTerminal>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredPortOrTerminalFunctionCode(string portOrTerminalFunctionCode, bool isValidExpected)
	{
		var subject = new R4_PortOrTerminal();
		subject.PortOrTerminalFunctionCode = portOrTerminalFunctionCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "W";
			subject.LocationIdentifier = "9";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("W", "9", true)]
	[InlineData("W", "", false)]
	[InlineData("", "9", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new R4_PortOrTerminal();
		subject.PortOrTerminalFunctionCode = "P";
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
