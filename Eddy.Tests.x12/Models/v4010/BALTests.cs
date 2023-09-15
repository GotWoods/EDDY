using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BALTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAL*J*V*1";

		var expected = new BAL_BalanceDetail()
		{
			BalanceTypeCode = "J",
			AmountQualifierCode = "V",
			MonetaryAmount = 1,
		};

		var actual = Map.MapObject<BAL_BalanceDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredBalanceTypeCode(string balanceTypeCode, bool isValidExpected)
	{
		var subject = new BAL_BalanceDetail();
		subject.AmountQualifierCode = "V";
		subject.MonetaryAmount = 1;
		subject.BalanceTypeCode = balanceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new BAL_BalanceDetail();
		subject.BalanceTypeCode = "J";
		subject.MonetaryAmount = 1;
		subject.AmountQualifierCode = amountQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new BAL_BalanceDetail();
		subject.BalanceTypeCode = "J";
		subject.AmountQualifierCode = "V";
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
