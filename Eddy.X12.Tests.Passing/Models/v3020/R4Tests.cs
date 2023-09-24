using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class R4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R4*L*V*V*Mn*jl*Sk*G*j1";

		var expected = new R4_Port()
		{
			PortFunctionCode = "L",
			LocationQualifier = "V",
			LocationIdentifier = "V",
			PortName = "Mn",
			CountryCode = "jl",
			TerminalName = "Sk",
			PierNumber = "G",
			StateOrProvinceCode = "j1",
		};

		var actual = Map.MapObject<R4_Port>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredPortFunctionCode(string portFunctionCode, bool isValidExpected)
	{
		var subject = new R4_Port();
		subject.PortFunctionCode = portFunctionCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationQualifier) || !string.IsNullOrEmpty(subject.LocationIdentifier))
		{
			subject.LocationQualifier = "V";
			subject.LocationIdentifier = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("V", "V", true)]
	[InlineData("V", "", false)]
	[InlineData("", "V", false)]
	public void Validation_AllAreRequiredLocationQualifier(string locationQualifier, string locationIdentifier, bool isValidExpected)
	{
		var subject = new R4_Port();
		subject.PortFunctionCode = "L";
		subject.LocationQualifier = locationQualifier;
		subject.LocationIdentifier = locationIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
