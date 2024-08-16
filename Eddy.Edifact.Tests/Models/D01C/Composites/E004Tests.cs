using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C.Composites;

public class E004Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "g:O:k:N:h:9:z:J:h:R:n:V:6:r:t:q:K";

		var expected = new E004_RuleDetails()
		{
			SpecialConditionCode = "g",
			UnitsQuantity = "O",
			UnitTypeCodeQualifier = "k",
			RelationCode = "N",
			DaysOfWeekSetIdentifier = "h",
			MonetaryAmount = "9",
			MonetaryAmountTypeCodeQualifier = "z",
			CurrencyIdentificationCode = "J",
			FreeText = "h",
			FreeText2 = "R",
			FreeText3 = "n",
			FreeText4 = "V",
			FreeText5 = "6",
			FreeText6 = "r",
			FreeText7 = "t",
			FreeText8 = "q",
			FreeText9 = "K",
		};

		var actual = Map.MapComposite<E004_RuleDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredSpecialConditionCode(string specialConditionCode, bool isValidExpected)
	{
		var subject = new E004_RuleDetails();
		//Required fields
		//Test Parameters
		subject.SpecialConditionCode = specialConditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
