using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BFRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BFR*iZ*n*T*kU*b*GlzE337i*VS0L0ugA*FZAh29nR*05AAtoKV*y*O*7d*p";

		var expected = new BFR_BeginningSegmentForPlanningSchedule()
		{
			TransactionSetPurposeCode = "iZ",
			ReferenceIdentification = "n",
			ReleaseNumber = "T",
			ScheduleTypeQualifier = "kU",
			ScheduleQuantityQualifier = "b",
			Date = "GlzE337i",
			Date2 = "VS0L0ugA",
			Date3 = "FZAh29nR",
			Date4 = "05AAtoKV",
			ContractNumber = "y",
			PurchaseOrderNumber = "O",
			PlanningScheduleTypeCode = "7d",
			ActionCode = "p",
		};

		var actual = Map.MapObject<BFR_BeginningSegmentForPlanningSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iZ", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.ScheduleTypeQualifier = "kU";
		subject.ScheduleQuantityQualifier = "b";
		subject.Date = "GlzE337i";
		subject.Date3 = "FZAh29nR";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
			subject.ReferenceIdentification = "n";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("n", "T", true)]
	[InlineData("n", "", true)]
	[InlineData("", "T", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string releaseNumber, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "iZ";
		subject.ScheduleTypeQualifier = "kU";
		subject.ScheduleQuantityQualifier = "b";
		subject.Date = "GlzE337i";
		subject.Date3 = "FZAh29nR";
		subject.ReferenceIdentification = referenceIdentification;
		subject.ReleaseNumber = releaseNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kU", true)]
	public void Validation_RequiredScheduleTypeQualifier(string scheduleTypeQualifier, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "iZ";
		subject.ScheduleQuantityQualifier = "b";
		subject.Date = "GlzE337i";
		subject.Date3 = "FZAh29nR";
		subject.ScheduleTypeQualifier = scheduleTypeQualifier;
			subject.ReferenceIdentification = "n";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredScheduleQuantityQualifier(string scheduleQuantityQualifier, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "iZ";
		subject.ScheduleTypeQualifier = "kU";
		subject.Date = "GlzE337i";
		subject.Date3 = "FZAh29nR";
		subject.ScheduleQuantityQualifier = scheduleQuantityQualifier;
			subject.ReferenceIdentification = "n";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GlzE337i", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "iZ";
		subject.ScheduleTypeQualifier = "kU";
		subject.ScheduleQuantityQualifier = "b";
		subject.Date3 = "FZAh29nR";
		subject.Date = date;
			subject.ReferenceIdentification = "n";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("FZAh29nR", true)]
	public void Validation_RequiredDate3(string date3, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "iZ";
		subject.ScheduleTypeQualifier = "kU";
		subject.ScheduleQuantityQualifier = "b";
		subject.Date = "GlzE337i";
		subject.Date3 = date3;
			subject.ReferenceIdentification = "n";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
