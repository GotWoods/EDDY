using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TIITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TII*m*1*9*9*V";

		var expected = new TII_TaxInstallmentInformation()
		{
			YesNoConditionOrResponseCode = "m",
			Quantity = 1,
			MonetaryAmount = 9,
			MonetaryAmount2 = 9,
			TaxServiceNonPaymentCode = "V",
		};

		var actual = Map.MapObject<TII_TaxInstallmentInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new TII_TaxInstallmentInformation();
		subject.Quantity = 1;
		subject.MonetaryAmount = 9;
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new TII_TaxInstallmentInformation();
		subject.YesNoConditionOrResponseCode = "m";
		subject.MonetaryAmount = 9;
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new TII_TaxInstallmentInformation();
		subject.YesNoConditionOrResponseCode = "m";
		subject.Quantity = 1;
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
