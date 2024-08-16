using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class AUTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "AUT+3+H";

		var expected = new AUT_AuthenticationResult()
		{
			ValidationResultValue = "3",
			ValidationKeyIdentifier = "H",
		};

		var actual = Map.MapObject<AUT_AuthenticationResult>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredValidationResultValue(string validationResultValue, bool isValidExpected)
	{
		var subject = new AUT_AuthenticationResult();
		//Required fields
		//Test Parameters
		subject.ValidationResultValue = validationResultValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
