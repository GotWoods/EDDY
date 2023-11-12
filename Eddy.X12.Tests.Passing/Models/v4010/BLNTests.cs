using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BLNTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BLN*j*A*7*BOaRLsPt*nyl0*gT";

		var expected = new BLN_BalanceInformation()
		{
			CodeListQualifierCode = "j",
			IndustryCode = "A",
			MonetaryAmount = 7,
			Date = "BOaRLsPt",
			Time = "nyl0",
			TimeCode = "gT",
		};

		var actual = Map.MapObject<BLN_BalanceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredCodeListQualifierCode(string codeListQualifierCode, bool isValidExpected)
	{
		var subject = new BLN_BalanceInformation();
		//Required fields
		subject.IndustryCode = "A";
		subject.MonetaryAmount = 7;
		//Test Parameters
		subject.CodeListQualifierCode = codeListQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new BLN_BalanceInformation();
		//Required fields
		subject.CodeListQualifierCode = "j";
		subject.MonetaryAmount = 7;
		//Test Parameters
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new BLN_BalanceInformation();
		//Required fields
		subject.CodeListQualifierCode = "j";
		subject.IndustryCode = "A";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("gT", "nyl0", true)]
	[InlineData("gT", "", false)]
	[InlineData("", "nyl0", true)]
	public void Validation_ARequiresBTimeCode(string timeCode, string time, bool isValidExpected)
	{
		var subject = new BLN_BalanceInformation();
		//Required fields
		subject.CodeListQualifierCode = "j";
		subject.IndustryCode = "A";
		subject.MonetaryAmount = 7;
		//Test Parameters
		subject.TimeCode = timeCode;
		subject.Time = time;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
