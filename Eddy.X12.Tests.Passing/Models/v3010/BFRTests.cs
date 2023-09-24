using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BFRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BFR*3k*9*I*Sh*L*JkdJT5*JbR4HO*44xVTN*RaJTmv*K*R*Hu";

		var expected = new BFR_BeginningSegmentForPlanningSchedule()
		{
			TransactionSetPurposeCode = "3k",
			ReferenceNumber = "9",
			ReleaseNumber = "I",
			ScheduleTypeQualifier = "Sh",
			ScheduleQuantityQualifier = "L",
			Date = "JkdJT5",
			Date2 = "JbR4HO",
			Date3 = "44xVTN",
			Date4 = "RaJTmv",
			ContractNumber = "K",
			PurchaseOrderNumber = "R",
			PlanningScheduleTypeCode = "Hu",
		};

		var actual = Map.MapObject<BFR_BeginningSegmentForPlanningSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3k", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.ScheduleTypeQualifier = "Sh";
		subject.ScheduleQuantityQualifier = "L";
		subject.Date = "JkdJT5";
		subject.Date2 = "JbR4HO";
		subject.Date3 = "44xVTN";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Sh", true)]
	public void Validation_RequiredScheduleTypeQualifier(string scheduleTypeQualifier, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "3k";
		subject.ScheduleQuantityQualifier = "L";
		subject.Date = "JkdJT5";
		subject.Date2 = "JbR4HO";
		subject.Date3 = "44xVTN";
		subject.ScheduleTypeQualifier = scheduleTypeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredScheduleQuantityQualifier(string scheduleQuantityQualifier, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "3k";
		subject.ScheduleTypeQualifier = "Sh";
		subject.Date = "JkdJT5";
		subject.Date2 = "JbR4HO";
		subject.Date3 = "44xVTN";
		subject.ScheduleQuantityQualifier = scheduleQuantityQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JkdJT5", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "3k";
		subject.ScheduleTypeQualifier = "Sh";
		subject.ScheduleQuantityQualifier = "L";
		subject.Date2 = "JbR4HO";
		subject.Date3 = "44xVTN";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JbR4HO", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "3k";
		subject.ScheduleTypeQualifier = "Sh";
		subject.ScheduleQuantityQualifier = "L";
		subject.Date = "JkdJT5";
		subject.Date3 = "44xVTN";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("44xVTN", true)]
	public void Validation_RequiredDate3(string date3, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "3k";
		subject.ScheduleTypeQualifier = "Sh";
		subject.ScheduleQuantityQualifier = "L";
		subject.Date = "JkdJT5";
		subject.Date2 = "JbR4HO";
		subject.Date3 = date3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
