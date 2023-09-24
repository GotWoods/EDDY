using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class DISTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DIS*htS*rT*2*BQ*5*2";

		var expected = new DIS_DiscountDetail()
		{
			DiscountTermsTypeCode = "htS",
			DiscountBaseQualifier = "rT",
			DiscountBaseValue = 2,
			DiscountControlLimitQualifier = "BQ",
			DiscountControlLimit = 5,
			DiscountControlLimit2 = 2,
		};

		var actual = Map.MapObject<DIS_DiscountDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("htS", true)]
	public void Validation_RequiredDiscountTermsTypeCode(string discountTermsTypeCode, bool isValidExpected)
	{
		var subject = new DIS_DiscountDetail();
		subject.DiscountBaseQualifier = "rT";
		subject.DiscountBaseValue = 2;
		subject.DiscountControlLimitQualifier = "BQ";
		subject.DiscountControlLimit = 5;
		subject.DiscountTermsTypeCode = discountTermsTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rT", true)]
	public void Validation_RequiredDiscountBaseQualifier(string discountBaseQualifier, bool isValidExpected)
	{
		var subject = new DIS_DiscountDetail();
		subject.DiscountTermsTypeCode = "htS";
		subject.DiscountBaseValue = 2;
		subject.DiscountControlLimitQualifier = "BQ";
		subject.DiscountControlLimit = 5;
		subject.DiscountBaseQualifier = discountBaseQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredDiscountBaseValue(decimal discountBaseValue, bool isValidExpected)
	{
		var subject = new DIS_DiscountDetail();
		subject.DiscountTermsTypeCode = "htS";
		subject.DiscountBaseQualifier = "rT";
		subject.DiscountControlLimitQualifier = "BQ";
		subject.DiscountControlLimit = 5;
		if (discountBaseValue > 0)
			subject.DiscountBaseValue = discountBaseValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("BQ", true)]
	public void Validation_RequiredDiscountControlLimitQualifier(string discountControlLimitQualifier, bool isValidExpected)
	{
		var subject = new DIS_DiscountDetail();
		subject.DiscountTermsTypeCode = "htS";
		subject.DiscountBaseQualifier = "rT";
		subject.DiscountBaseValue = 2;
		subject.DiscountControlLimit = 5;
		subject.DiscountControlLimitQualifier = discountControlLimitQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredDiscountControlLimit(int discountControlLimit, bool isValidExpected)
	{
		var subject = new DIS_DiscountDetail();
		subject.DiscountTermsTypeCode = "htS";
		subject.DiscountBaseQualifier = "rT";
		subject.DiscountBaseValue = 2;
		subject.DiscountControlLimitQualifier = "BQ";
		if (discountControlLimit > 0)
			subject.DiscountControlLimit = discountControlLimit;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
