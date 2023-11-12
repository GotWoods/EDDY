using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class MITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MI*KV*e*A*9*K";

		var expected = new MI_MediaInformation()
		{
			MediaTypeIdentifierCode = "KV",
			Amount = "e",
			Amount2 = "A",
			Amount3 = "9",
			Description = "K",
		};

		var actual = Map.MapObject<MI_MediaInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("KV", true)]
	public void Validation_RequiredMediaTypeIdentifierCode(string mediaTypeIdentifierCode, bool isValidExpected)
	{
		var subject = new MI_MediaInformation();
		//Required fields
		//Test Parameters
		subject.MediaTypeIdentifierCode = mediaTypeIdentifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
