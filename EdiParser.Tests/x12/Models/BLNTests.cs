using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BLNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BLN*I*G*5*T8g29Rvl*1bpl*wQ";

		var expected = new BLN_BalanceInformation()
		{
			CodeListQualifierCode = "I",
			IndustryCode = "G",
			MonetaryAmount = 5,
			Date = "T8g29Rvl",
			Time = "1bpl",
			TimeCode = "wQ",
		};

		var actual = Map.MapObject<BLN_BalanceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validatation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new BLN_BalanceInformation();
		subject.IndustryCode = "G";
		subject.MonetaryAmount = 5;
		subject.CodeListQualifierCode = codeListQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validatation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new BLN_BalanceInformation();
		subject.CodeListQualifierCode = "I";
		subject.MonetaryAmount = 5;
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validatation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new BLN_BalanceInformation();
		subject.CodeListQualifierCode = "I";
		subject.IndustryCode = "G";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "1bpl", true)]
	[InlineData("wQ", "", false)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new BLN_BalanceInformation();
		subject.CodeListQualifierCode = "I";
		subject.IndustryCode = "G";
		subject.MonetaryAmount = 5;
		subject.TimeCode = timeCode;
		subject.Time = time;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
