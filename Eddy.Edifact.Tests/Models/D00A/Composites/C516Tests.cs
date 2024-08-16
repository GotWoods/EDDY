using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A.Composites;

public class C516Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "e:L:P:i:c";

		var expected = new C516_MonetaryAmount()
		{
			MonetaryAmountTypeCodeQualifier = "e",
			MonetaryAmount = "L",
			CurrencyIdentificationCode = "P",
			CurrencyTypeCodeQualifier = "i",
			StatusDescriptionCode = "c",
		};

		var actual = Map.MapComposite<C516_MonetaryAmount>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredMonetaryAmountTypeCodeQualifier(string monetaryAmountTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new C516_MonetaryAmount();
		//Required fields
		//Test Parameters
		subject.MonetaryAmountTypeCodeQualifier = monetaryAmountTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
