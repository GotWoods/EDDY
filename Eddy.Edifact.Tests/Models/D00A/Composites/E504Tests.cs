using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class E504Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "M:u:d:m";

		var expected = new E504_CurrencyDetails()
		{
			CurrencyUsageCodeQualifier = "M",
			CurrencyIdentificationCode = "u",
			CurrencyTypeCodeQualifier = "d",
			CurrencyRateValue = "m",
		};

		var actual = Map.MapComposite<E504_CurrencyDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredCurrencyUsageCodeQualifier(string currencyUsageCodeQualifier, bool isValidExpected)
	{
		var subject = new E504_CurrencyDetails();
		//Required fields
		//Test Parameters
		subject.CurrencyUsageCodeQualifier = currencyUsageCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
