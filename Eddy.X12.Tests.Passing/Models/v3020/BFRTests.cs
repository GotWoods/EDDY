using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class BFRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BFR*Sm*v*n*kn*a*kCJolU*8uhHNg*dl0FkM*WtEUSO*F*L*uG";

		var expected = new BFR_BeginningSegmentForPlanningSchedule()
		{
			TransactionSetPurposeCode = "Sm",
			ReferenceNumber = "v",
			ReleaseNumber = "n",
			ScheduleTypeQualifier = "kn",
			ScheduleQuantityQualifier = "a",
			Date = "kCJolU",
			Date2 = "8uhHNg",
			Date3 = "dl0FkM",
			Date4 = "WtEUSO",
			ContractNumber = "F",
			PurchaseOrderNumber = "L",
			PlanningScheduleTypeCode = "uG",
		};

		var actual = Map.MapObject<BFR_BeginningSegmentForPlanningSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Sm", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.ScheduleTypeQualifier = "kn";
		subject.ScheduleQuantityQualifier = "a";
		subject.Date = "kCJolU";
		subject.Date2 = "8uhHNg";
		subject.Date3 = "dl0FkM";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
			subject.ReferenceNumber = "v";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("v", "n", true)]
	[InlineData("v", "", true)]
	[InlineData("", "n", true)]
	public void Validation_AtLeastOneReferenceNumber(string referenceNumber, string releaseNumber, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "Sm";
		subject.ScheduleTypeQualifier = "kn";
		subject.ScheduleQuantityQualifier = "a";
		subject.Date = "kCJolU";
		subject.Date2 = "8uhHNg";
		subject.Date3 = "dl0FkM";
		subject.ReferenceNumber = referenceNumber;
		subject.ReleaseNumber = releaseNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kn", true)]
	public void Validation_RequiredScheduleTypeQualifier(string scheduleTypeQualifier, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "Sm";
		subject.ScheduleQuantityQualifier = "a";
		subject.Date = "kCJolU";
		subject.Date2 = "8uhHNg";
		subject.Date3 = "dl0FkM";
		subject.ScheduleTypeQualifier = scheduleTypeQualifier;
			subject.ReferenceNumber = "v";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredScheduleQuantityQualifier(string scheduleQuantityQualifier, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "Sm";
		subject.ScheduleTypeQualifier = "kn";
		subject.Date = "kCJolU";
		subject.Date2 = "8uhHNg";
		subject.Date3 = "dl0FkM";
		subject.ScheduleQuantityQualifier = scheduleQuantityQualifier;
			subject.ReferenceNumber = "v";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kCJolU", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "Sm";
		subject.ScheduleTypeQualifier = "kn";
		subject.ScheduleQuantityQualifier = "a";
		subject.Date2 = "8uhHNg";
		subject.Date3 = "dl0FkM";
		subject.Date = date;
			subject.ReferenceNumber = "v";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8uhHNg", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "Sm";
		subject.ScheduleTypeQualifier = "kn";
		subject.ScheduleQuantityQualifier = "a";
		subject.Date = "kCJolU";
		subject.Date3 = "dl0FkM";
		subject.Date2 = date2;
			subject.ReferenceNumber = "v";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dl0FkM", true)]
	public void Validation_RequiredDate3(string date3, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "Sm";
		subject.ScheduleTypeQualifier = "kn";
		subject.ScheduleQuantityQualifier = "a";
		subject.Date = "kCJolU";
		subject.Date2 = "8uhHNg";
		subject.Date3 = date3;
			subject.ReferenceNumber = "v";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
