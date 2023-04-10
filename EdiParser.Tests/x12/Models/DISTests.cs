using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class DISTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DIS*Sa8*rX*1*zm*5*4";

		var expected = new DIS_DiscountDetail()
		{
			DiscountTermsTypeCode = "Sa8",
			DiscountBaseQualifier = "rX",
			DiscountBaseValue = 1,
			DiscountControlLimitQualifier = "zm",
			DiscountControlLimit = 5,
			DiscountControlLimit2 = 4,
		};

		var actual = Map.MapObject<DIS_DiscountDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Sa8", true)]
	public void Validatation_RequiredDiscountTermsTypeCode(string discountTermsTypeCode, bool isValidExpected)
	{
		var subject = new DIS_DiscountDetail();
		subject.DiscountBaseQualifier = "rX";
		subject.DiscountBaseValue = 1;
		subject.DiscountControlLimitQualifier = "zm";
		subject.DiscountControlLimit = 5;
		subject.DiscountTermsTypeCode = discountTermsTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rX", true)]
	public void Validatation_RequiredDiscountBaseQualifier(string discountBaseQualifier, bool isValidExpected)
	{
		var subject = new DIS_DiscountDetail();
		subject.DiscountTermsTypeCode = "Sa8";
		subject.DiscountBaseValue = 1;
		subject.DiscountControlLimitQualifier = "zm";
		subject.DiscountControlLimit = 5;
		subject.DiscountBaseQualifier = discountBaseQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validatation_RequiredDiscountBaseValue(decimal discountBaseValue, bool isValidExpected)
	{
		var subject = new DIS_DiscountDetail();
		subject.DiscountTermsTypeCode = "Sa8";
		subject.DiscountBaseQualifier = "rX";
		subject.DiscountControlLimitQualifier = "zm";
		subject.DiscountControlLimit = 5;
		if (discountBaseValue > 0)
		subject.DiscountBaseValue = discountBaseValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zm", true)]
	public void Validatation_RequiredDiscountControlLimitQualifier(string discountControlLimitQualifier, bool isValidExpected)
	{
		var subject = new DIS_DiscountDetail();
		subject.DiscountTermsTypeCode = "Sa8";
		subject.DiscountBaseQualifier = "rX";
		subject.DiscountBaseValue = 1;
		subject.DiscountControlLimit = 5;
		subject.DiscountControlLimitQualifier = discountControlLimitQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validatation_RequiredDiscountControlLimit(int discountControlLimit, bool isValidExpected)
	{
		var subject = new DIS_DiscountDetail();
		subject.DiscountTermsTypeCode = "Sa8";
		subject.DiscountBaseQualifier = "rX";
		subject.DiscountBaseValue = 1;
		subject.DiscountControlLimitQualifier = "zm";
		if (discountControlLimit > 0)
		subject.DiscountControlLimit = discountControlLimit;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
