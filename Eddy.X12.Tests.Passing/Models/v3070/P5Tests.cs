using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class P5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "P5*e*K*j";

		var expected = new P5_PortInformation()
		{
			PortOrTerminalFunctionCode = "e",
			LocationQualifier = "K",
			LocationIdentifier = "j",
		};

		var actual = Map.MapObject<P5_PortInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredPortOrTerminalFunctionCode(string portOrTerminalFunctionCode, bool isValidExpected)
	{
		var subject = new P5_PortInformation();
		//Required fields
		subject.LocationQualifier = "K";
		subject.LocationIdentifier = "j";
		//Test Parameters
		subject.PortOrTerminalFunctionCode = portOrTerminalFunctionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new P5_PortInformation();
		//Required fields
		subject.PortOrTerminalFunctionCode = "e";
		subject.LocationIdentifier = "j";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new P5_PortInformation();
		//Required fields
		subject.PortOrTerminalFunctionCode = "e";
		subject.LocationQualifier = "K";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
