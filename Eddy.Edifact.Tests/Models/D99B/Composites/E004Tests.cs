using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E004Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "x:p:e:B:G:U:v:i:K:0:V:o:6:R:K:v:f";

		var expected = new E004_RuleDetails()
		{
			SpecialConditionCode = "x",
			NumberOfUnits = "p",
			UnitTypeCodeQualifier = "e",
			RelationCoded = "B",
			DaysOfOperation = "G",
			MonetaryAmountValue = "U",
			MonetaryAmountTypeCodeQualifier = "v",
			CurrencyIdentificationCode = "i",
			FreeTextValue = "K",
			FreeTextValue2 = "0",
			FreeTextValue3 = "V",
			FreeTextValue4 = "o",
			FreeTextValue5 = "6",
			FreeTextValue6 = "R",
			FreeTextValue7 = "K",
			FreeTextValue8 = "v",
			FreeTextValue9 = "f",
		};

		var actual = Map.MapComposite<E004_RuleDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredSpecialConditionCode(string specialConditionCode, bool isValidExpected)
	{
		var subject = new E004_RuleDetails();
		//Required fields
		//Test Parameters
		subject.SpecialConditionCode = specialConditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
