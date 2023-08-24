using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class DISTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DIS*qT1*Su*1*jI*3*2";

		var expected = new DIS_DiscountDetail()
		{
			DiscountTermsTypeCode = "qT1",
			DiscountBaseQualifier = "Su",
			DiscountBaseValue = 1,
			DiscountControlLimitQualifier = "jI",
			LowerDiscountControlLimit = 3,
			UpperDiscountControlLimit = 2,
		};

		var actual = Map.MapObject<DIS_DiscountDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qT1", true)]
	public void Validation_RequiredDiscountTermsTypeCode(string discountTermsTypeCode, bool isValidExpected)
	{
		var subject = new DIS_DiscountDetail();
		subject.DiscountBaseQualifier = "Su";
		subject.DiscountBaseValue = 1;
		subject.DiscountControlLimitQualifier = "jI";
		subject.LowerDiscountControlLimit = 3;
		subject.DiscountTermsTypeCode = discountTermsTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Su", true)]
	public void Validation_RequiredDiscountBaseQualifier(string discountBaseQualifier, bool isValidExpected)
	{
		var subject = new DIS_DiscountDetail();
		subject.DiscountTermsTypeCode = "qT1";
		subject.DiscountBaseValue = 1;
		subject.DiscountControlLimitQualifier = "jI";
		subject.LowerDiscountControlLimit = 3;
		subject.DiscountBaseQualifier = discountBaseQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredDiscountBaseValue(decimal discountBaseValue, bool isValidExpected)
	{
		var subject = new DIS_DiscountDetail();
		subject.DiscountTermsTypeCode = "qT1";
		subject.DiscountBaseQualifier = "Su";
		subject.DiscountControlLimitQualifier = "jI";
		subject.LowerDiscountControlLimit = 3;
		if (discountBaseValue > 0)
		subject.DiscountBaseValue = discountBaseValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jI", true)]
	public void Validation_RequiredDiscountControlLimitQualifier(string discountControlLimitQualifier, bool isValidExpected)
	{
		var subject = new DIS_DiscountDetail();
		subject.DiscountTermsTypeCode = "qT1";
		subject.DiscountBaseQualifier = "Su";
		subject.DiscountBaseValue = 1;
		subject.LowerDiscountControlLimit = 3;
		subject.DiscountControlLimitQualifier = discountControlLimitQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredLowerDiscountControlLimit(int lowerDiscountControlLimit, bool isValidExpected)
	{
		var subject = new DIS_DiscountDetail();
		subject.DiscountTermsTypeCode = "qT1";
		subject.DiscountBaseQualifier = "Su";
		subject.DiscountBaseValue = 1;
		subject.DiscountControlLimitQualifier = "jI";
		if (lowerDiscountControlLimit > 0)
		subject.LowerDiscountControlLimit = lowerDiscountControlLimit;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
