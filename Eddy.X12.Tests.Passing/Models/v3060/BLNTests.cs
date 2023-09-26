using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BLNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BLN*Q*a*6*Hywmez*BFAB*df";

		var expected = new BLN_BalanceInformation()
		{
			CodeListQualifierCode = "Q",
			IndustryCode = "a",
			MonetaryAmount = 6,
			Date = "Hywmez",
			Time = "BFAB",
			TimeCode = "df",
		};

		var actual = Map.MapObject<BLN_BalanceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new BLN_BalanceInformation();
		//Required fields
		subject.IndustryCode = "a";
		subject.MonetaryAmount = 6;
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new BLN_BalanceInformation();
		//Required fields
		subject.CodeListQualifierCode = "Q";
		subject.MonetaryAmount = 6;
		//Test Parameters
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new BLN_BalanceInformation();
		//Required fields
		subject.CodeListQualifierCode = "Q";
		subject.IndustryCode = "a";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("df", "BFAB", true)]
	[InlineData("df", "", false)]
	[InlineData("", "BFAB", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new BLN_BalanceInformation();
		//Required fields
		subject.CodeListQualifierCode = "Q";
		subject.IndustryCode = "a";
		subject.MonetaryAmount = 6;
		//Test Parameters
		subject.TimeCode = timeCode;
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
