using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class USRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "USR+";

		var expected = new USR_SecurityResult()
		{
			ValidationResult = null,
		};

		var actual = Map.MapObject<USR_SecurityResult>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredValidationResult(string validationResult, bool isValidExpected)
	{
		var subject = new USR_SecurityResult();
		//Required fields
		//Test Parameters
		if (validationResult != "") 
			subject.ValidationResult = new S508_ValidationResult();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
