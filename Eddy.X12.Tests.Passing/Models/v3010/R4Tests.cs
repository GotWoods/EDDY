using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class R4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "R4*z*n*i*I8*I0*zr*Z*2K";

		var expected = new R4_Port()
		{
			PortFunctionCode = "z",
			LocationQualifier = "n",
			LocationIdentifier = "i",
			PortName = "I8",
			CountryCode = "I0",
			TerminalName = "zr",
			PierNumber = "Z",
			StateOrProvinceCode = "2K",
		};

		var actual = Map.MapObject<R4_Port>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredPortFunctionCode(string portFunctionCode, bool isValidExpected)
	{
		var subject = new R4_Port();
		subject.PortFunctionCode = portFunctionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
