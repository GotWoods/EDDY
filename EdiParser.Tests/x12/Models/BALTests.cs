using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BALTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BAL*K*V*3";

		var expected = new BAL_BalanceDetail()
		{
			BalanceTypeCode = "K",
			AmountQualifierCode = "V",
			MonetaryAmount = 3,
		};

		var actual = Map.MapObject<BAL_BalanceDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validatation_RequiredBalanceTypeCode(string balanceTypeCode, bool isValidExpected)
	{
		var subject = new BAL_BalanceDetail();
		subject.AmountQualifierCode = "V";
		subject.MonetaryAmount = 3;
		subject.BalanceTypeCode = balanceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validatation_RequiredAmountQualifierCode(string amountQualifierCode, bool isValidExpected)
	{
		var subject = new BAL_BalanceDetail();
		subject.BalanceTypeCode = "K";
		subject.MonetaryAmount = 3;
		subject.AmountQualifierCode = amountQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validatation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new BAL_BalanceDetail();
		subject.BalanceTypeCode = "K";
		subject.AmountQualifierCode = "V";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
