using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class P5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "P5*A*3*s";

		var expected = new P5_PortFunction()
		{
			PortOrTerminalFunctionCode = "A",
			LocationQualifier = "3",
			LocationIdentifier = "s",
		};

		var actual = Map.MapObject<P5_PortFunction>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredPortOrTerminalFunctionCode(string portOrTerminalFunctionCode, bool isValidExpected)
	{
		var subject = new P5_PortFunction();
		subject.LocationQualifier = "3";
		subject.LocationIdentifier = "s";
		subject.PortOrTerminalFunctionCode = portOrTerminalFunctionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new P5_PortFunction();
		subject.PortOrTerminalFunctionCode = "A";
		subject.LocationIdentifier = "s";
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new P5_PortFunction();
		subject.PortOrTerminalFunctionCode = "A";
		subject.LocationQualifier = "3";
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
