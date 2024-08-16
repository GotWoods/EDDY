using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class E504Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "4:o:w:2";

		var expected = new E504_CurrencyDetails()
		{
			CurrencyDetailsQualifier = "4",
			CurrencyIdentificationCode = "o",
			CurrencyQualifier = "w",
			CurrencyRateBase = "2",
		};

		var actual = Map.MapComposite<E504_CurrencyDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredCurrencyDetailsQualifier(string currencyDetailsQualifier, bool isValidExpected)
	{
		var subject = new E504_CurrencyDetails();
		//Required fields
		//Test Parameters
		subject.CurrencyDetailsQualifier = currencyDetailsQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
