using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BFRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BFR*vR*O*O*Q4*L*pT7ImOmv*Oc58ntHZ*Ri4RvZmq*jQFoeChR*Z*X*v2*Y";

		var expected = new BFR_BeginningSegmentForPlanningSchedule()
		{
			TransactionSetPurposeCode = "vR",
			ReferenceIdentification = "O",
			ReleaseNumber = "O",
			ScheduleTypeQualifier = "Q4",
			ScheduleQuantityQualifier = "L",
			Date = "pT7ImOmv",
			Date2 = "Oc58ntHZ",
			Date3 = "Ri4RvZmq",
			Date4 = "jQFoeChR",
			ContractNumber = "Z",
			PurchaseOrderNumber = "X",
			PlanningScheduleTypeCode = "v2",
			ActionCode = "Y",
		};

		var actual = Map.MapObject<BFR_BeginningSegmentForPlanningSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vR", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.ScheduleTypeQualifier = "Q4";
		subject.ScheduleQuantityQualifier = "L";
		subject.Date = "pT7ImOmv";
		subject.Date3 = "Ri4RvZmq";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
			subject.ReferenceIdentification = "O";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("O", "O", true)]
	[InlineData("O", "", true)]
	[InlineData("", "O", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string releaseNumber, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "vR";
		subject.ScheduleTypeQualifier = "Q4";
		subject.ScheduleQuantityQualifier = "L";
		subject.Date = "pT7ImOmv";
		subject.Date3 = "Ri4RvZmq";
		subject.ReferenceIdentification = referenceIdentification;
		subject.ReleaseNumber = releaseNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q4", true)]
	public void Validation_RequiredScheduleTypeQualifier(string scheduleTypeQualifier, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "vR";
		subject.ScheduleQuantityQualifier = "L";
		subject.Date = "pT7ImOmv";
		subject.Date3 = "Ri4RvZmq";
		subject.ScheduleTypeQualifier = scheduleTypeQualifier;
			subject.ReferenceIdentification = "O";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredScheduleQuantityQualifier(string scheduleQuantityQualifier, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "vR";
		subject.ScheduleTypeQualifier = "Q4";
		subject.Date = "pT7ImOmv";
		subject.Date3 = "Ri4RvZmq";
		subject.ScheduleQuantityQualifier = scheduleQuantityQualifier;
			subject.ReferenceIdentification = "O";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("pT7ImOmv", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "vR";
		subject.ScheduleTypeQualifier = "Q4";
		subject.ScheduleQuantityQualifier = "L";
		subject.Date3 = "Ri4RvZmq";
		subject.Date = date;
			subject.ReferenceIdentification = "O";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ri4RvZmq", true)]
	public void Validation_RequiredDate3(string date3, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "vR";
		subject.ScheduleTypeQualifier = "Q4";
		subject.ScheduleQuantityQualifier = "L";
		subject.Date = "pT7ImOmv";
		subject.Date3 = date3;
			subject.ReferenceIdentification = "O";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
