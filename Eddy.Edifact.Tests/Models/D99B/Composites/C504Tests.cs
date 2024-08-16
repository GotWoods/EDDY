using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C504Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "l:1:l:T";

		var expected = new C504_CurrencyDetails()
		{
			CurrencyDetailsQualifier = "l",
			CurrencyIdentificationCode = "1",
			CurrencyQualifier = "l",
			CurrencyRateBase = "T",
		};

		var actual = Map.MapComposite<C504_CurrencyDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredCurrencyDetailsQualifier(string currencyDetailsQualifier, bool isValidExpected)
	{
		var subject = new C504_CurrencyDetails();
		//Required fields
		//Test Parameters
		subject.CurrencyDetailsQualifier = currencyDetailsQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
