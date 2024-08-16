using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98A;
using Eddy.Edifact.Models.D98A.Composites;

namespace Eddy.Edifact.Tests.Models.D98A.Composites;

public class E004Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "f:M:I:R:M:D:8:p:v:4:Y:F:B:d:1:f:n";

		var expected = new E004_RuleDetails()
		{
			SpecialConditionsCoded = "f",
			NumberOfUnits = "M",
			NumberOfUnitsQualifier = "I",
			RelationCoded = "R",
			DaysOfOperation = "M",
			MonetaryAmount = "D",
			MonetaryAmountTypeQualifier = "8",
			CurrencyCoded = "p",
			FreeText = "v",
			FreeText2 = "4",
			FreeText3 = "Y",
			FreeText4 = "F",
			FreeText5 = "B",
			FreeText6 = "d",
			FreeText7 = "1",
			FreeText8 = "f",
			FreeText9 = "n",
		};

		var actual = Map.MapComposite<E004_RuleDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredSpecialConditionsCoded(string specialConditionsCoded, bool isValidExpected)
	{
		var subject = new E004_RuleDetails();
		//Required fields
		//Test Parameters
		subject.SpecialConditionsCoded = specialConditionsCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
