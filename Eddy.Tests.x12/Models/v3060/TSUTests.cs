using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class TSUTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TSU*F*l*9*2*1*ymdssP*y9Sy*L2";

		var expected = new TSU_TransactionSummary()
		{
			CodeListQualifierCode = "F",
			IndustryCode = "l",
			MonetaryAmount = 9,
			Quantity = 2,
			Quantity2 = 1,
			Date = "ymdssP",
			Time = "y9Sy",
			TimeCode = "L2",
		};

		var actual = Map.MapObject<TSU_TransactionSummary>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new TSU_TransactionSummary();
		//Required fields
		subject.IndustryCode = "l";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new TSU_TransactionSummary();
		//Required fields
		subject.CodeListQualifierCode = "F";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new TSU_TransactionSummary();
		//Required fields
		subject.CodeListQualifierCode = "F";
		subject.IndustryCode = "l";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("L2", "y9Sy", true)]
	[InlineData("L2", "", false)]
	[InlineData("", "y9Sy", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new TSU_TransactionSummary();
		//Required fields
		subject.CodeListQualifierCode = "F";
		subject.IndustryCode = "l";
		subject.MonetaryAmount = 9;
		//Test Parameters
		subject.TimeCode = timeCode;
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
