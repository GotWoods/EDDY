using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D98A;
using Eddy.Edifact.Models.D98A.Composites;

namespace Eddy.Edifact.Tests.Models.D98A.Composites;

public class C516Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "b:C:X:B:a";

		var expected = new C516_MonetaryAmount()
		{
			MonetaryAmountTypeQualifier = "b",
			MonetaryAmount = "C",
			CurrencyCoded = "X",
			CurrencyQualifier = "B",
			StatusCoded = "a",
		};

		var actual = Map.MapComposite<C516_MonetaryAmount>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredMonetaryAmountTypeQualifier(string monetaryAmountTypeQualifier, bool isValidExpected)
	{
		var subject = new C516_MonetaryAmount();
		//Required fields
		//Test Parameters
		subject.MonetaryAmountTypeQualifier = monetaryAmountTypeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
