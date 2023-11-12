using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class TSUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TSU*R*n*4*2*1*XpjJWP*H60r*yN";

		var expected = new TSU_TransactionSummary()
		{
			CodeListQualifierCode = "R",
			FinancialInformationCode = "n",
			MonetaryAmount = 4,
			Quantity = 2,
			Quantity2 = 1,
			Date = "XpjJWP",
			Time = "H60r",
			TimeCode = "yN",
		};

		var actual = Map.MapObject<TSU_TransactionSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new TSU_TransactionSummary();
		//Required fields
		subject.FinancialInformationCode = "n";
		subject.MonetaryAmount = 4;
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredFinancialInformationCode(string financialInformationCode, bool isValidExpected)
	{
		var subject = new TSU_TransactionSummary();
		//Required fields
		subject.CodeListQualifierCode = "R";
		subject.MonetaryAmount = 4;
		//Test Parameters
		subject.FinancialInformationCode = financialInformationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new TSU_TransactionSummary();
		//Required fields
		subject.CodeListQualifierCode = "R";
		subject.FinancialInformationCode = "n";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("yN", "H60r", true)]
	[InlineData("yN", "", false)]
	[InlineData("", "H60r", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new TSU_TransactionSummary();
		//Required fields
		subject.CodeListQualifierCode = "R";
		subject.FinancialInformationCode = "n";
		subject.MonetaryAmount = 4;
		//Test Parameters
		subject.TimeCode = timeCode;
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
