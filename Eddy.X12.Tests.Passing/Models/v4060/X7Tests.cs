using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.Tests.Models.v4060;

public class X7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X7*6*Q";

		var expected = new X7_CustomsInformation()
		{
			FreeFormInformation = "6",
			FreeFormInformation2 = "Q",
		};

		var actual = Map.MapObject<X7_CustomsInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredFreeFormInformation(string freeFormInformation, bool isValidExpected)
	{
		var subject = new X7_CustomsInformation();
		//Required fields
		//Test Parameters
		subject.FreeFormInformation = freeFormInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
