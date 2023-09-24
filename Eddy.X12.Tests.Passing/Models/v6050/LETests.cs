using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.Tests.Models.v6050;

public class LETests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LE*Z";

		var expected = new LE_LoopTrailer()
		{
			LoopIdentifierCode = "Z",
		};

		var actual = Map.MapObject<LE_LoopTrailer>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredLoopIdentifierCode(string loopIdentifierCode, bool isValidExpected)
	{
		var subject = new LE_LoopTrailer();
		subject.LoopIdentifierCode = loopIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
