using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class W1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W1*W";

		var expected = new W1_BlockIdentification()
		{
			BlockIdentification = "W",
		};

		var actual = Map.MapObject<W1_BlockIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredBlockIdentification(string blockIdentification, bool isValidExpected)
	{
		var subject = new W1_BlockIdentification();
		//Required fields
		//Test Parameters
		subject.BlockIdentification = blockIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
