using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E005Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "T:1:t";

		var expected = new E005_RuleText()
		{
			SpecialConditionsCoded = "T",
			InformationTypeIdentification = "1",
			FreeText = "t",
		};

		var actual = Map.MapComposite<E005_RuleText>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredSpecialConditionsCoded(string specialConditionsCoded, bool isValidExpected)
	{
		var subject = new E005_RuleText();
		//Required fields
		//Test Parameters
		subject.SpecialConditionsCoded = specialConditionsCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
