using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class MITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MI*x3*h*9*H*U";

		var expected = new MI_MediaInformation()
		{
			MediaTypeIdentifierCode = "x3",
			Amount = "h",
			Amount2 = "9",
			Amount3 = "H",
			Description = "U",
		};

		var actual = Map.MapObject<MI_MediaInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x3", true)]
	public void Validation_RequiredMediaTypeIdentifierCode(string mediaTypeIdentifierCode, bool isValidExpected)
	{
		var subject = new MI_MediaInformation();
		subject.MediaTypeIdentifierCode = mediaTypeIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
