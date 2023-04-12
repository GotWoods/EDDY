using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class W1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W1*m";

		var expected = new W1_BlockIdentification()
		{
			BlockIdentifier = "m",
		};

		var actual = Map.MapObject<W1_BlockIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredBlockIdentifier(string blockIdentifier, bool isValidExpected)
	{
		var subject = new W1_BlockIdentification();
		subject.BlockIdentifier = blockIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
