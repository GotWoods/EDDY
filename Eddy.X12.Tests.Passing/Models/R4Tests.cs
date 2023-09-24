using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class R4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R4*K*w*o*lz*iz*W6*P*Cm";

		var expected = new R4_PortOrTerminal()
		{
			PortOrTerminalFunctionCode = "K",
			LocationQualifier = "w",
			LocationIdentifier = "o",
			PortName = "lz",
			CountryCode = "iz",
			TerminalName = "W6",
			PierNumber = "P",
			StateOrProvinceCode = "Cm",
		};

		var actual = Map.MapObject<R4_PortOrTerminal>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredPortOrTerminalFunctionCode(string portOrTerminalFunctionCode, bool isValidExpected)
	{
		var subject = new R4_PortOrTerminal();
		subject.PortOrTerminalFunctionCode = portOrTerminalFunctionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("w", "o", true)]
	[InlineData("", "o", false)]
	[InlineData("w", "", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new R4_PortOrTerminal();
		subject.PortOrTerminalFunctionCode = "K";
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
