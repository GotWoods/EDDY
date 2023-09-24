using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class DISTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DIS*L7w*J7*7*8C*3*2";

		var expected = new DIS_DiscountDetail()
		{
			DiscountTermsTypeCode = "L7w",
			DiscountBaseQualifier = "J7",
			DiscountBaseValue = 7,
			DiscountControlLimitQualifier = "8C",
			LowerDiscountControlLimit = 3,
			UpperDiscountControlLimit = 2,
		};

		var actual = Map.MapObject<DIS_DiscountDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L7w", true)]
	public void Validation_RequiredDiscountTermsTypeCode(string discountTermsTypeCode, bool isValidExpected)
	{
		var subject = new DIS_DiscountDetail();
		subject.DiscountBaseQualifier = "J7";
		subject.DiscountBaseValue = 7;
		subject.DiscountControlLimitQualifier = "8C";
		subject.LowerDiscountControlLimit = 3;
		subject.DiscountTermsTypeCode = discountTermsTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J7", true)]
	public void Validation_RequiredDiscountBaseQualifier(string discountBaseQualifier, bool isValidExpected)
	{
		var subject = new DIS_DiscountDetail();
		subject.DiscountTermsTypeCode = "L7w";
		subject.DiscountBaseValue = 7;
		subject.DiscountControlLimitQualifier = "8C";
		subject.LowerDiscountControlLimit = 3;
		subject.DiscountBaseQualifier = discountBaseQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredDiscountBaseValue(decimal discountBaseValue, bool isValidExpected)
	{
		var subject = new DIS_DiscountDetail();
		subject.DiscountTermsTypeCode = "L7w";
		subject.DiscountBaseQualifier = "J7";
		subject.DiscountControlLimitQualifier = "8C";
		subject.LowerDiscountControlLimit = 3;
		if (discountBaseValue > 0)
			subject.DiscountBaseValue = discountBaseValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8C", true)]
	public void Validation_RequiredDiscountControlLimitQualifier(string discountControlLimitQualifier, bool isValidExpected)
	{
		var subject = new DIS_DiscountDetail();
		subject.DiscountTermsTypeCode = "L7w";
		subject.DiscountBaseQualifier = "J7";
		subject.DiscountBaseValue = 7;
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
		subject.DiscountTermsTypeCode = "L7w";
		subject.DiscountBaseQualifier = "J7";
		subject.DiscountBaseValue = 7;
		subject.DiscountControlLimitQualifier = "8C";
		if (lowerDiscountControlLimit > 0)
			subject.LowerDiscountControlLimit = lowerDiscountControlLimit;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
