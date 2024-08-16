using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D02A;
using Eddy.Edifact.Models.D02A.Composites;

namespace Eddy.Edifact.Tests.Models.D02A.Composites;

public class E504Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "e:3:h:2";

		var expected = new E504_CurrencyDetails()
		{
			CurrencyUsageCodeQualifier = "e",
			CurrencyIdentificationCode = "3",
			CurrencyTypeCodeQualifier = "h",
			CurrencyRate = "2",
		};

		var actual = Map.MapComposite<E504_CurrencyDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredCurrencyUsageCodeQualifier(string currencyUsageCodeQualifier, bool isValidExpected)
	{
		var subject = new E504_CurrencyDetails();
		//Required fields
		//Test Parameters
		subject.CurrencyUsageCodeQualifier = currencyUsageCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
