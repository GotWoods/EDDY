using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class BFRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BFR*Dn*m*M*fa*1*Q96cTQ*H6XW5W*s6VWdd*w7ju0i*p*F*KJ*i";

		var expected = new BFR_BeginningSegmentForPlanningSchedule()
		{
			TransactionSetPurposeCode = "Dn",
			ReferenceNumber = "m",
			ReleaseNumber = "M",
			ScheduleTypeQualifier = "fa",
			ScheduleQuantityQualifier = "1",
			Date = "Q96cTQ",
			Date2 = "H6XW5W",
			Date3 = "s6VWdd",
			Date4 = "w7ju0i",
			ContractNumber = "p",
			PurchaseOrderNumber = "F",
			PlanningScheduleTypeCode = "KJ",
			ActionCode = "i",
		};

		var actual = Map.MapObject<BFR_BeginningSegmentForPlanningSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Dn", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.ScheduleTypeQualifier = "fa";
		subject.ScheduleQuantityQualifier = "1";
		subject.Date = "Q96cTQ";
		subject.Date3 = "s6VWdd";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
			subject.ReferenceNumber = "m";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("m", "M", true)]
	[InlineData("m", "", true)]
	[InlineData("", "M", true)]
	public void Validation_AtLeastOneReferenceNumber(string referenceNumber, string releaseNumber, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "Dn";
		subject.ScheduleTypeQualifier = "fa";
		subject.ScheduleQuantityQualifier = "1";
		subject.Date = "Q96cTQ";
		subject.Date3 = "s6VWdd";
		subject.ReferenceNumber = referenceNumber;
		subject.ReleaseNumber = releaseNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("fa", true)]
	public void Validation_RequiredScheduleTypeQualifier(string scheduleTypeQualifier, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "Dn";
		subject.ScheduleQuantityQualifier = "1";
		subject.Date = "Q96cTQ";
		subject.Date3 = "s6VWdd";
		subject.ScheduleTypeQualifier = scheduleTypeQualifier;
			subject.ReferenceNumber = "m";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredScheduleQuantityQualifier(string scheduleQuantityQualifier, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "Dn";
		subject.ScheduleTypeQualifier = "fa";
		subject.Date = "Q96cTQ";
		subject.Date3 = "s6VWdd";
		subject.ScheduleQuantityQualifier = scheduleQuantityQualifier;
			subject.ReferenceNumber = "m";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q96cTQ", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "Dn";
		subject.ScheduleTypeQualifier = "fa";
		subject.ScheduleQuantityQualifier = "1";
		subject.Date3 = "s6VWdd";
		subject.Date = date;
			subject.ReferenceNumber = "m";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s6VWdd", true)]
	public void Validation_RequiredDate3(string date3, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "Dn";
		subject.ScheduleTypeQualifier = "fa";
		subject.ScheduleQuantityQualifier = "1";
		subject.Date = "Q96cTQ";
		subject.Date3 = date3;
			subject.ReferenceNumber = "m";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
