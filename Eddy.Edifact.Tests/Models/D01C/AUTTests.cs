using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C;

public class AUTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "AUT+u+6";

		var expected = new AUT_AuthenticationResult()
		{
			ValidationResultText = "u",
			ValidationKeyIdentifier = "6",
		};

		var actual = Map.MapObject<AUT_AuthenticationResult>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredValidationResultText(string validationResultText, bool isValidExpected)
	{
		var subject = new AUT_AuthenticationResult();
		//Required fields
		//Test Parameters
		subject.ValidationResultText = validationResultText;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
