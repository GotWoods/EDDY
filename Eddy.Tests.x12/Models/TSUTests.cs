using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class TSUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TSU*u*9*2*4*3*yKOQJN9y*r7YA*zy";

		var expected = new TSU_TransactionSummary()
		{
			CodeListQualifierCode = "u",
			IndustryCode = "9",
			MonetaryAmount = 2,
			Quantity = 4,
			Quantity2 = 3,
			Date = "yKOQJN9y",
			Time = "r7YA",
			TimeCode = "zy",
		};

		var actual = Map.MapObject<TSU_TransactionSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new TSU_TransactionSummary();
		subject.IndustryCode = "9";
		subject.MonetaryAmount = 2;
		subject.CodeListQualifierCode = codeListQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new TSU_TransactionSummary();
		subject.CodeListQualifierCode = "u";
		subject.MonetaryAmount = 2;
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new TSU_TransactionSummary();
		subject.CodeListQualifierCode = "u";
		subject.IndustryCode = "9";
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "r7YA", true)]
	[InlineData("zy", "", false)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new TSU_TransactionSummary();
		subject.CodeListQualifierCode = "u";
		subject.IndustryCode = "9";
		subject.MonetaryAmount = 2;
		subject.TimeCode = timeCode;
		subject.Time = time;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
