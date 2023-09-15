using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class LSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LS*h";

		var expected = new LS_LoopHeader()
		{
			LoopIdentifierCode = "h",
		};

		var actual = Map.MapObject<LS_LoopHeader>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h", true)]
	public void Validation_RequiredLoopIdentifierCode(string loopIdentifierCode, bool isValidExpected)
	{
		var subject = new LS_LoopHeader();
		subject.LoopIdentifierCode = loopIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
