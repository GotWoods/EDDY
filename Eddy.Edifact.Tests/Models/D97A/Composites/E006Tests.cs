using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E006Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "6:I";

		var expected = new E006_RuleStatus()
		{
			SpecialConditionsCoded = "6",
			StatusIndicatorCoded = "I",
		};

		var actual = Map.MapComposite<E006_RuleStatus>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredSpecialConditionsCoded(string specialConditionsCoded, bool isValidExpected)
	{
		var subject = new E006_RuleStatus();
		//Required fields
		subject.StatusIndicatorCoded = "I";
		//Test Parameters
		subject.SpecialConditionsCoded = specialConditionsCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredStatusIndicatorCoded(string statusIndicatorCoded, bool isValidExpected)
	{
		var subject = new E006_RuleStatus();
		//Required fields
		subject.SpecialConditionsCoded = "6";
		//Test Parameters
		subject.StatusIndicatorCoded = statusIndicatorCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
