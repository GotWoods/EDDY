using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E005Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "4:F:Y";

		var expected = new E005_RuleText()
		{
			SpecialConditionCode = "4",
			InformationTypeCode = "F",
			FreeText = "Y",
		};

		var actual = Map.MapComposite<E005_RuleText>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredSpecialConditionCode(string specialConditionCode, bool isValidExpected)
	{
		var subject = new E005_RuleText();
		//Required fields
		//Test Parameters
		subject.SpecialConditionCode = specialConditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
