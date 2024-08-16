using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97B;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Tests.Models.D97B.Composites;

public class E504Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "M:M:V:v";

		var expected = new E504_CurrencyDetails()
		{
			CurrencyDetailsQualifier = "M",
			CurrencyCoded = "M",
			CurrencyQualifier = "V",
			CurrencyRateBase = "v",
		};

		var actual = Map.MapComposite<E504_CurrencyDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredCurrencyDetailsQualifier(string currencyDetailsQualifier, bool isValidExpected)
	{
		var subject = new E504_CurrencyDetails();
		//Required fields
		//Test Parameters
		subject.CurrencyDetailsQualifier = currencyDetailsQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
