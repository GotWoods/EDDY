using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class S508Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "t:S";

		var expected = new S508_ValidationResult()
		{
			ValidationValueQualifier = "t",
			ValidationValue = "S",
		};

		var actual = Map.MapComposite<S508_ValidationResult>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredValidationValueQualifier(string validationValueQualifier, bool isValidExpected)
	{
		var subject = new S508_ValidationResult();
		//Required fields
		//Test Parameters
		subject.ValidationValueQualifier = validationValueQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
