using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C504Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "6:E:4:m";

		var expected = new C504_CurrencyDetails()
		{
			CurrencyUsageCodeQualifier = "6",
			CurrencyIdentificationCode = "E",
			CurrencyTypeCodeQualifier = "4",
			CurrencyRateValue = "m",
		};

		var actual = Map.MapComposite<C504_CurrencyDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredCurrencyUsageCodeQualifier(string currencyUsageCodeQualifier, bool isValidExpected)
	{
		var subject = new C504_CurrencyDetails();
		//Required fields
		//Test Parameters
		subject.CurrencyUsageCodeQualifier = currencyUsageCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
