using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BFRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BFR*bm*i*X*is*v*yqq0G7oZ*D2l2gSpu*kNS0LIaa*owW94HQU*8*b*Yl*s";

		var expected = new BFR_BeginningSegmentForPlanningSchedule()
		{
			TransactionSetPurposeCode = "bm",
			ReferenceIdentification = "i",
			ReleaseNumber = "X",
			ScheduleTypeQualifier = "is",
			ScheduleQuantityQualifier = "v",
			Date = "yqq0G7oZ",
			Date2 = "D2l2gSpu",
			Date3 = "kNS0LIaa",
			Date4 = "owW94HQU",
			ContractNumber = "8",
			PurchaseOrderNumber = "b",
			PlanningScheduleTypeCode = "Yl",
			ActionCode = "s",
		};

		var actual = Map.MapObject<BFR_BeginningSegmentForPlanningSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bm", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.ScheduleTypeQualifier = "is";
		subject.ScheduleQuantityQualifier = "v";
		subject.Date = "yqq0G7oZ";
		subject.Date3 = "kNS0LIaa";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
			subject.ReferenceIdentification = "i";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("i", "X", true)]
	[InlineData("i", "", true)]
	[InlineData("", "X", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string releaseNumber, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "bm";
		subject.ScheduleTypeQualifier = "is";
		subject.ScheduleQuantityQualifier = "v";
		subject.Date = "yqq0G7oZ";
		subject.Date3 = "kNS0LIaa";
		subject.ReferenceIdentification = referenceIdentification;
		subject.ReleaseNumber = releaseNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("is", true)]
	public void Validation_RequiredScheduleTypeQualifier(string scheduleTypeQualifier, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "bm";
		subject.ScheduleQuantityQualifier = "v";
		subject.Date = "yqq0G7oZ";
		subject.Date3 = "kNS0LIaa";
		subject.ScheduleTypeQualifier = scheduleTypeQualifier;
			subject.ReferenceIdentification = "i";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredScheduleQuantityQualifier(string scheduleQuantityQualifier, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "bm";
		subject.ScheduleTypeQualifier = "is";
		subject.Date = "yqq0G7oZ";
		subject.Date3 = "kNS0LIaa";
		subject.ScheduleQuantityQualifier = scheduleQuantityQualifier;
			subject.ReferenceIdentification = "i";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yqq0G7oZ", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "bm";
		subject.ScheduleTypeQualifier = "is";
		subject.ScheduleQuantityQualifier = "v";
		subject.Date3 = "kNS0LIaa";
		subject.Date = date;
			subject.ReferenceIdentification = "i";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kNS0LIaa", true)]
	public void Validation_RequiredDate3(string date3, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "bm";
		subject.ScheduleTypeQualifier = "is";
		subject.ScheduleQuantityQualifier = "v";
		subject.Date = "yqq0G7oZ";
		subject.Date3 = date3;
			subject.ReferenceIdentification = "i";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
