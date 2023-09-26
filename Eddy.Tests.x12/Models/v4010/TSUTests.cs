using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class TSUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TSU*R*e*4*9*1*UusJsz1d*7w0R*z7";

		var expected = new TSU_TransactionSummary()
		{
			CodeListQualifierCode = "R",
			IndustryCode = "e",
			MonetaryAmount = 4,
			Quantity = 9,
			Quantity2 = 1,
			Date = "UusJsz1d",
			Time = "7w0R",
			TimeCode = "z7",
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
		subject.IndustryCode = "e";
		subject.MonetaryAmount = 4;
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new TSU_TransactionSummary();
		//Required fields
		subject.CodeListQualifierCode = "R";
		subject.MonetaryAmount = 4;
		//Test Parameters
		subject.IndustryCode = industryCode;
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
		subject.IndustryCode = "e";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("z7", "7w0R", true)]
	[InlineData("z7", "", false)]
	[InlineData("", "7w0R", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new TSU_TransactionSummary();
		//Required fields
		subject.CodeListQualifierCode = "R";
		subject.IndustryCode = "e";
		subject.MonetaryAmount = 4;
		//Test Parameters
		subject.TimeCode = timeCode;
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
