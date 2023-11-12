using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class BLNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BLN*8*q*8*ub6yBk*lUKJ*B5";

		var expected = new BLN_BalanceInformation()
		{
			CodeListQualifierCode = "8",
			FinancialInformationCode = "q",
			MonetaryAmount = 8,
			Date = "ub6yBk",
			Time = "lUKJ",
			TimeCode = "B5",
		};

		var actual = Map.MapObject<BLN_BalanceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new BLN_BalanceInformation();
		//Required fields
		subject.FinancialInformationCode = "q";
		subject.MonetaryAmount = 8;
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredFinancialInformationCode(string financialInformationCode, bool isValidExpected)
	{
		var subject = new BLN_BalanceInformation();
		//Required fields
		subject.CodeListQualifierCode = "8";
		subject.MonetaryAmount = 8;
		//Test Parameters
		subject.FinancialInformationCode = financialInformationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new BLN_BalanceInformation();
		//Required fields
		subject.CodeListQualifierCode = "8";
		subject.FinancialInformationCode = "q";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B5", "lUKJ", true)]
	[InlineData("B5", "", false)]
	[InlineData("", "lUKJ", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new BLN_BalanceInformation();
		//Required fields
		subject.CodeListQualifierCode = "8";
		subject.FinancialInformationCode = "q";
		subject.MonetaryAmount = 8;
		//Test Parameters
		subject.TimeCode = timeCode;
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
