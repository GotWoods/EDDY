using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class K1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "K1*j*Z";

		var expected = new K1_Remarks()
		{
			FreeFormMessage = "j",
			FreeFormMessage2 = "Z",
		};

		var actual = Map.MapObject<K1_Remarks>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredFreeFormMessage(string freeFormMessage, bool isValidExpected)
	{
		var subject = new K1_Remarks();
		subject.FreeFormMessage = freeFormMessage;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
