using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E005Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "M:N:T";

		var expected = new E005_RuleText()
		{
			SpecialConditionCode = "M",
			InformationTypeCode = "N",
			FreeTextValue = "T",
		};

		var actual = Map.MapComposite<E005_RuleText>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredSpecialConditionCode(string specialConditionCode, bool isValidExpected)
	{
		var subject = new E005_RuleText();
		//Required fields
		//Test Parameters
		subject.SpecialConditionCode = specialConditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
