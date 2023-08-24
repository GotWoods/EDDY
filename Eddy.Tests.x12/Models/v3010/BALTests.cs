using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BALTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAL*Q*M*6";

		var expected = new BAL_BalanceDetail()
		{
			BalanceTypeCode = "Q",
			AmountQualifierCode = "M",
			MonetaryAmount = 6,
		};

		var actual = Map.MapObject<BAL_BalanceDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredBalanceTypeCode(string balanceTypeCode, bool isValidExpected)
	{
		var subject = new BAL_BalanceDetail();
		subject.AmountQualifierCode = "M";
		subject.MonetaryAmount = 6;
		subject.BalanceTypeCode = balanceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new BAL_BalanceDetail();
		subject.BalanceTypeCode = "Q";
		subject.MonetaryAmount = 6;
		subject.AmountQualifierCode = amountQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new BAL_BalanceDetail();
		subject.BalanceTypeCode = "Q";
		subject.AmountQualifierCode = "M";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
