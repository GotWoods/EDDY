using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class DEFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DEF*m*P*0T*B*D*r";

		var expected = new DEF_DelayedRepayment()
		{
			DelayedRepaymentQualifierCode = "m",
			DelayedRepaymentReasonCode = "P",
			DateTimePeriodFormatQualifier = "0T",
			DateTimePeriod = "B",
			InterestPaymentCode = "D",
			YesNoConditionOrResponseCode = "r",
		};

		var actual = Map.MapObject<DEF_DelayedRepayment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredDelayedRepaymentQualifierCode(string delayedRepaymentQualifierCode, bool isValidExpected)
	{
		var subject = new DEF_DelayedRepayment();
		//Required fields
		subject.DelayedRepaymentReasonCode = "P";
		subject.DateTimePeriodFormatQualifier = "0T";
		subject.DateTimePeriod = "B";
		//Test Parameters
		subject.DelayedRepaymentQualifierCode = delayedRepaymentQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredDelayedRepaymentReasonCode(string delayedRepaymentReasonCode, bool isValidExpected)
	{
		var subject = new DEF_DelayedRepayment();
		//Required fields
		subject.DelayedRepaymentQualifierCode = "m";
		subject.DateTimePeriodFormatQualifier = "0T";
		subject.DateTimePeriod = "B";
		//Test Parameters
		subject.DelayedRepaymentReasonCode = delayedRepaymentReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0T", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new DEF_DelayedRepayment();
		//Required fields
		subject.DelayedRepaymentQualifierCode = "m";
		subject.DelayedRepaymentReasonCode = "P";
		subject.DateTimePeriod = "B";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new DEF_DelayedRepayment();
		//Required fields
		subject.DelayedRepaymentQualifierCode = "m";
		subject.DelayedRepaymentReasonCode = "P";
		subject.DateTimePeriodFormatQualifier = "0T";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
