using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B.Composites;

public class C516Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "4:3:2:B:q";

		var expected = new C516_MonetaryAmount()
		{
			MonetaryAmountTypeCodeQualifier = "4",
			MonetaryAmountValue = "3",
			CurrencyIdentificationCode = "2",
			CurrencyQualifier = "B",
			StatusDescriptionCode = "q",
		};

		var actual = Map.MapComposite<C516_MonetaryAmount>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredMonetaryAmountTypeCodeQualifier(string monetaryAmountTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new C516_MonetaryAmount();
		//Required fields
		//Test Parameters
		subject.MonetaryAmountTypeCodeQualifier = monetaryAmountTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
