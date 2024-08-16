using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D02A;
using Eddy.Edifact.Models.D02A.Composites;

namespace Eddy.Edifact.Tests.Models.D02A.Composites;

public class C504Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "m:Z:S:H";

		var expected = new C504_CurrencyDetails()
		{
			CurrencyUsageCodeQualifier = "m",
			CurrencyIdentificationCode = "Z",
			CurrencyTypeCodeQualifier = "S",
			CurrencyRate = "H",
		};

		var actual = Map.MapComposite<C504_CurrencyDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredCurrencyUsageCodeQualifier(string currencyUsageCodeQualifier, bool isValidExpected)
	{
		var subject = new C504_CurrencyDetails();
		//Required fields
		//Test Parameters
		subject.CurrencyUsageCodeQualifier = currencyUsageCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
