using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BFRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BFR*yd*l*r*QU*a*Ng5nTN*sLgoi3*DkgVeO*CaKfan*j*4*jw*J";

		var expected = new BFR_BeginningSegmentForPlanningSchedule()
		{
			TransactionSetPurposeCode = "yd",
			ReferenceIdentification = "l",
			ReleaseNumber = "r",
			ScheduleTypeQualifier = "QU",
			ScheduleQuantityQualifier = "a",
			Date = "Ng5nTN",
			Date2 = "sLgoi3",
			Date3 = "DkgVeO",
			Date4 = "CaKfan",
			ContractNumber = "j",
			PurchaseOrderNumber = "4",
			PlanningScheduleTypeCode = "jw",
			ActionCode = "J",
		};

		var actual = Map.MapObject<BFR_BeginningSegmentForPlanningSchedule>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yd", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.ScheduleTypeQualifier = "QU";
		subject.ScheduleQuantityQualifier = "a";
		subject.Date = "Ng5nTN";
		subject.Date3 = "DkgVeO";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
			subject.ReferenceIdentification = "l";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("l", "r", true)]
	[InlineData("l", "", true)]
	[InlineData("", "r", true)]
	public void Validation_AtLeastOneReferenceIdentification(string referenceIdentification, string releaseNumber, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "yd";
		subject.ScheduleTypeQualifier = "QU";
		subject.ScheduleQuantityQualifier = "a";
		subject.Date = "Ng5nTN";
		subject.Date3 = "DkgVeO";
		subject.ReferenceIdentification = referenceIdentification;
		subject.ReleaseNumber = releaseNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("QU", true)]
	public void Validation_RequiredScheduleTypeQualifier(string scheduleTypeQualifier, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "yd";
		subject.ScheduleQuantityQualifier = "a";
		subject.Date = "Ng5nTN";
		subject.Date3 = "DkgVeO";
		subject.ScheduleTypeQualifier = scheduleTypeQualifier;
			subject.ReferenceIdentification = "l";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredScheduleQuantityQualifier(string scheduleQuantityQualifier, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "yd";
		subject.ScheduleTypeQualifier = "QU";
		subject.Date = "Ng5nTN";
		subject.Date3 = "DkgVeO";
		subject.ScheduleQuantityQualifier = scheduleQuantityQualifier;
			subject.ReferenceIdentification = "l";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ng5nTN", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "yd";
		subject.ScheduleTypeQualifier = "QU";
		subject.ScheduleQuantityQualifier = "a";
		subject.Date3 = "DkgVeO";
		subject.Date = date;
			subject.ReferenceIdentification = "l";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DkgVeO", true)]
	public void Validation_RequiredDate3(string date3, bool isValidExpected)
	{
		var subject = new BFR_BeginningSegmentForPlanningSchedule();
		subject.TransactionSetPurposeCode = "yd";
		subject.ScheduleTypeQualifier = "QU";
		subject.ScheduleQuantityQualifier = "a";
		subject.Date = "Ng5nTN";
		subject.Date3 = date3;
			subject.ReferenceIdentification = "l";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
