using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class X7Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "X7*2*R";

		var expected = new X7_CustomsInformation()
		{
			FreeFormInformation = "2",
			FreeFormInformation2 = "R",
		};

		var actual = Map.MapObject<X7_CustomsInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredFreeFormInformation(string freeFormInformation, bool isValidExpected)
	{
		var subject = new X7_CustomsInformation();
		subject.FreeFormInformation = freeFormInformation;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
