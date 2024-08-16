using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class E004Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "0:5:b:g:u:L:u:E:5:t:y:j:n:e:9:f:T";

		var expected = new E004_RuleDetails()
		{
			SpecialConditionsCoded = "0",
			NumberOfUnits = "5",
			NumberOfUnitsQualifier = "b",
			RelationCoded = "g",
			DaysOfOperation = "u",
			MonetaryAmount = "L",
			MonetaryAmountTypeQualifier = "u",
			CurrencyCoded = "E",
			FreeText = "5",
			FreeText2 = "t",
			FreeText3 = "y",
			FreeText4 = "j",
			FreeText5 = "n",
			FreeText6 = "e",
			FreeText7 = "9",
			FreeText8 = "f",
			FreeText9 = "T",
		};

		var actual = Map.MapComposite<E004_RuleDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredSpecialConditionsCoded(string specialConditionsCoded, bool isValidExpected)
	{
		var subject = new E004_RuleDetails();
		//Required fields
		//Test Parameters
		subject.SpecialConditionsCoded = specialConditionsCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
