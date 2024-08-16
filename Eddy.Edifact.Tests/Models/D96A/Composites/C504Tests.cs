using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C504Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "M:2:D:U";

		var expected = new C504_CurrencyDetails()
		{
			CurrencyDetailsQualifier = "M",
			CurrencyCoded = "2",
			CurrencyQualifier = "D",
			CurrencyRateBase = "U",
		};

		var actual = Map.MapComposite<C504_CurrencyDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredCurrencyDetailsQualifier(string currencyDetailsQualifier, bool isValidExpected)
	{
		var subject = new C504_CurrencyDetails();
		//Required fields
		//Test Parameters
		subject.CurrencyDetailsQualifier = currencyDetailsQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
