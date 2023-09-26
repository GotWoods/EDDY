using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class MITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MI*EZ*1*B*G*B";

		var expected = new MI_MediaInformation()
		{
			MediaTypeIdentifier = "EZ",
			Amount = "1",
			Amount2 = "B",
			Amount3 = "G",
			Description = "B",
		};

		var actual = Map.MapObject<MI_MediaInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("EZ", true)]
	public void Validation_RequiredMediaTypeIdentifier(string mediaTypeIdentifier, bool isValidExpected)
	{
		var subject = new MI_MediaInformation();
		//Required fields
		//Test Parameters
		subject.MediaTypeIdentifier = mediaTypeIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
