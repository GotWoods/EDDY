using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E004Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "r:S:I:v:q:D:N:U:r:o:W:1:s:5:d:R:8";

		var expected = new E004_RuleDetails()
		{
			SpecialConditionCode = "r",
			UnitsQuantity = "S",
			UnitTypeCodeQualifier = "I",
			RelationCode = "v",
			DaysOfWeekSetIdentifier = "q",
			MonetaryAmount = "D",
			MonetaryAmountTypeCodeQualifier = "N",
			CurrencyIdentificationCode = "U",
			FreeTextValue = "r",
			FreeTextValue2 = "o",
			FreeTextValue3 = "W",
			FreeTextValue4 = "1",
			FreeTextValue5 = "s",
			FreeTextValue6 = "5",
			FreeTextValue7 = "d",
			FreeTextValue8 = "R",
			FreeTextValue9 = "8",
		};

		var actual = Map.MapComposite<E004_RuleDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredSpecialConditionCode(string specialConditionCode, bool isValidExpected)
	{
		var subject = new E004_RuleDetails();
		//Required fields
		//Test Parameters
		subject.SpecialConditionCode = specialConditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
