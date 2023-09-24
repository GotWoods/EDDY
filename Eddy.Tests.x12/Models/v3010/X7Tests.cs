using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class X7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X7*Q*v";

		var expected = new X7_CustomsInformation()
		{
			FreeFormMessage = "Q",
			FreeFormMessage2 = "v",
		};

		var actual = Map.MapObject<X7_CustomsInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredFreeFormMessage(string freeFormMessage, bool isValidExpected)
	{
		var subject = new X7_CustomsInformation();
		//Required fields
		//Test Parameters
		subject.FreeFormMessage = freeFormMessage;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
