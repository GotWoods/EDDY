using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class R4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R4*K*x*L*8h*nO*Z8*b*I7";

		var expected = new R4_Port()
		{
			PortFunctionCode = "K",
			LocationQualifier = "x",
			LocationIdentifier = "L",
			PortName = "8h",
			CountryCode = "nO",
			TerminalName = "Z8",
			PierNumber = "b",
			StateOrProvinceCode = "I7",
		};

		var actual = Map.MapObject<R4_Port>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredPortFunctionCode(string portFunctionCode, bool isValidExpected)
	{
		var subject = new R4_Port();
		subject.PortFunctionCode = portFunctionCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "x";
			subject.LocationIdentifier = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("x", "L", true)]
	[InlineData("x", "", false)]
	[InlineData("", "L", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new R4_Port();
		subject.PortFunctionCode = "K";
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
