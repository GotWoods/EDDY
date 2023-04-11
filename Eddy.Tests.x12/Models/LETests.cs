using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class LETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LE*5";

		var expected = new LE_LoopTrailer()
		{
			LoopIdentifierCode = "5",
		};

		var actual = Map.MapObject<LE_LoopTrailer>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredLoopIdentifierCode(string loopIdentifierCode, bool isValidExpected)
	{
		var subject = new LE_LoopTrailer();
		subject.LoopIdentifierCode = loopIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
