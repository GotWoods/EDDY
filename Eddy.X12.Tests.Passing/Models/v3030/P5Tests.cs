using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class P5Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "P5*I*o*5";

		var expected = new P5_PortInformation()
		{
			PortFunctionCode = "I",
			LocationQualifier = "o",
			LocationIdentifier = "5",
		};

		var actual = Map.MapObject<P5_PortInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredPortFunctionCode(string portFunctionCode, bool isValidExpected)
	{
		var subject = new P5_PortInformation();
		//Required fields
		subject.LocationQualifier = "o";
		subject.LocationIdentifier = "5";
		//Test Parameters
		subject.PortFunctionCode = portFunctionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredLocationQualifier(string locationQualifier, bool isValidExpected)
	{
		var subject = new P5_PortInformation();
		//Required fields
		subject.PortFunctionCode = "I";
		subject.LocationIdentifier = "5";
		//Test Parameters
		subject.LocationQualifier = locationQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredLocationIdentifier(string locationIdentifier, bool isValidExpected)
	{
		var subject = new P5_PortInformation();
		//Required fields
		subject.PortFunctionCode = "I";
		subject.LocationQualifier = "o";
		//Test Parameters
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
