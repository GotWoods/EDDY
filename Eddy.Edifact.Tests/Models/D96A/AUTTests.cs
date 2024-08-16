using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class AUTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "AUT+E+N";

		var expected = new AUT_AuthenticationResult()
		{
			ValidationResult = "E",
			ValidationKeyIdentification = "N",
		};

		var actual = Map.MapObject<AUT_AuthenticationResult>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredValidationResult(string validationResult, bool isValidExpected)
	{
		var subject = new AUT_AuthenticationResult();
		//Required fields
		//Test Parameters
		subject.ValidationResult = validationResult;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
