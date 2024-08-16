using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E005Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "d:v:G";

		var expected = new E005_RuleText()
		{
			SpecialConditionCode = "d",
			InformationTypeIdentification = "v",
			FreeTextValue = "G",
		};

		var actual = Map.MapComposite<E005_RuleText>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredSpecialConditionCode(string specialConditionCode, bool isValidExpected)
	{
		var subject = new E005_RuleText();
		//Required fields
		//Test Parameters
		subject.SpecialConditionCode = specialConditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
