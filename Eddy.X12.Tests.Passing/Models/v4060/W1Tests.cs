using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class W1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W1*C";

		var expected = new W1_BlockIdentification()
		{
			BlockIdentifier = "C",
		};

		var actual = Map.MapObject<W1_BlockIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredBlockIdentifier(string blockIdentifier, bool isValidExpected)
	{
		var subject = new W1_BlockIdentification();
		//Required fields
		//Test Parameters
		subject.BlockIdentifier = blockIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
