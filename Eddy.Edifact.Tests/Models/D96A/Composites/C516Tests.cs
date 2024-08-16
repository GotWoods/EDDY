using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C516Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "9:X:z:X:S";

		var expected = new C516_MonetaryAmount()
		{
			MonetaryAmountTypeQualifier = "9",
			MonetaryAmount = "X",
			CurrencyCoded = "z",
			CurrencyQualifier = "X",
			StatusCoded = "S",
		};

		var actual = Map.MapComposite<C516_MonetaryAmount>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredMonetaryAmountTypeQualifier(string monetaryAmountTypeQualifier, bool isValidExpected)
	{
		var subject = new C516_MonetaryAmount();
		//Required fields
		//Test Parameters
		subject.MonetaryAmountTypeQualifier = monetaryAmountTypeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
