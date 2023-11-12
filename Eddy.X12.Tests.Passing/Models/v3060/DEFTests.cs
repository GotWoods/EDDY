using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class DEFTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "DEF*d*R*Sc*3*w";

		var expected = new DEF_DelayedRepayment()
		{
			DelayedRepaymentQualifierCode = "d",
			DelayedRepaymentReasonCode = "R",
			DateTimePeriodFormatQualifier = "Sc",
			DateTimePeriod = "3",
			InterestPaymentCode = "w",
		};

		var actual = Map.MapObject<DEF_DelayedRepayment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredDelayedRepaymentQualifierCode(string delayedRepaymentQualifierCode, bool isValidExpected)
	{
		var subject = new DEF_DelayedRepayment();
		//Required fields
		subject.DelayedRepaymentReasonCode = "R";
		subject.DateTimePeriodFormatQualifier = "Sc";
		subject.DateTimePeriod = "3";
		//Test Parameters
		subject.DelayedRepaymentQualifierCode = delayedRepaymentQualifierCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredDelayedRepaymentReasonCode(string delayedRepaymentReasonCode, bool isValidExpected)
	{
		var subject = new DEF_DelayedRepayment();
		//Required fields
		subject.DelayedRepaymentQualifierCode = "d";
		subject.DateTimePeriodFormatQualifier = "Sc";
		subject.DateTimePeriod = "3";
		//Test Parameters
		subject.DelayedRepaymentReasonCode = delayedRepaymentReasonCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Sc", true)]
	public void Validation_RequiredDateTimePeriodFormatQualifier(string dateTimePeriodFormatQualifier, bool isValidExpected)
	{
		var subject = new DEF_DelayedRepayment();
		//Required fields
		subject.DelayedRepaymentQualifierCode = "d";
		subject.DelayedRepaymentReasonCode = "R";
		subject.DateTimePeriod = "3";
		//Test Parameters
		subject.DateTimePeriodFormatQualifier = dateTimePeriodFormatQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredDateTimePeriod(string dateTimePeriod, bool isValidExpected)
	{
		var subject = new DEF_DelayedRepayment();
		//Required fields
		subject.DelayedRepaymentQualifierCode = "d";
		subject.DelayedRepaymentReasonCode = "R";
		subject.DateTimePeriodFormatQualifier = "Sc";
		//Test Parameters
		subject.DateTimePeriod = dateTimePeriod;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
