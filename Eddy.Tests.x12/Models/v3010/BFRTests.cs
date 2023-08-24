using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BFRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BFR*4f*k*A*JS*B*vlvtoo*L7JxEy*ThxXHw*hx8PXC*7*B*qG";

		var expected = new BFR_BeginningSegmentForPlanningSchedule()
		{
			TransactionSetPurposeCode = "4f",
			ReferenceNumber = "k",
			ReleaseNumber = "A",
			ScheduleTypeQualifier = "JS",
			ScheduleQuantityQualifier = "B",
			Date = "vlvtoo",
			Date2 = "L7JxEy",
			Date3 = "ThxXHw",
			Date4 = "hx8PXC",
			ContractNumber = "7",
			PurchaseOrderNumber = "B",
			PlanningScheduleTypeCode = "qG",
		};

		var actual = Map.MapObject<BFR_BeginningSegmentForPlanningSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4f", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.ScheduleTypeQualifier = "JS";
		subject.ScheduleQuantityQualifier = "B";
		subject.Date = "vlvtoo";
		subject.Date2 = "L7JxEy";
		subject.Date3 = "ThxXHw";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JS", true)]
	public void Validation_RequiredScheduleTypeQualifier(string scheduleTypeQualifier, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "4f";
		subject.ScheduleQuantityQualifier = "B";
		subject.Date = "vlvtoo";
		subject.Date2 = "L7JxEy";
		subject.Date3 = "ThxXHw";
		subject.ScheduleTypeQualifier = scheduleTypeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredScheduleQuantityQualifier(string scheduleQuantityQualifier, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "4f";
		subject.ScheduleTypeQualifier = "JS";
		subject.Date = "vlvtoo";
		subject.Date2 = "L7JxEy";
		subject.Date3 = "ThxXHw";
		subject.ScheduleQuantityQualifier = scheduleQuantityQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vlvtoo", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "4f";
		subject.ScheduleTypeQualifier = "JS";
		subject.ScheduleQuantityQualifier = "B";
		subject.Date2 = "L7JxEy";
		subject.Date3 = "ThxXHw";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L7JxEy", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "4f";
		subject.ScheduleTypeQualifier = "JS";
		subject.ScheduleQuantityQualifier = "B";
		subject.Date = "vlvtoo";
		subject.Date3 = "ThxXHw";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ThxXHw", true)]
	public void Validation_RequiredDate3(string date3, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "4f";
		subject.ScheduleTypeQualifier = "JS";
		subject.ScheduleQuantityQualifier = "B";
		subject.Date = "vlvtoo";
		subject.Date2 = "L7JxEy";
		subject.Date3 = date3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
