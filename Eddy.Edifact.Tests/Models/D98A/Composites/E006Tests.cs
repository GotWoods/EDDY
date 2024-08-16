using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98A;
using Eddy.Edifact.Models.D98A.Composites;

namespace Eddy.Edifact.Tests.Models.D98A.Composites;

public class E006Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "v:M";

		var expected = new E006_RuleStatus()
		{
			SpecialConditionsCoded = "v",
			ProcessingIndicatorCoded = "M",
		};

		var actual = Map.MapComposite<E006_RuleStatus>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredSpecialConditionsCoded(string specialConditionsCoded, bool isValidExpected)
	{
		var subject = new E006_RuleStatus();
		//Required fields
		//Test Parameters
		subject.SpecialConditionsCoded = specialConditionsCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
