using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class K2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "K2*W";

		var expected = new K2_AdministrativeMessage()
		{
			FreeFormMessage = "W",
		};

		var actual = Map.MapObject<K2_AdministrativeMessage>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredFreeFormMessage(string freeFormMessage, bool isValidExpected)
	{
		var subject = new K2_AdministrativeMessage();
		subject.FreeFormMessage = freeFormMessage;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
