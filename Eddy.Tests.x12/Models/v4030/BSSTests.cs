using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BSSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSS*GB*z*yuC5lzLA*lw*5BNjUyf7*ZaBLRZFP*z*u*c*T*p";

		var expected = new BSS_BeginningSegmentForShippingScheduleProductionSequence()
		{
			TransactionSetPurposeCode = "GB",
			ReferenceIdentification = "z",
			Date = "yuC5lzLA",
			ScheduleTypeQualifier = "lw",
			Date2 = "5BNjUyf7",
			Date3 = "ZaBLRZFP",
			ReleaseNumber = "z",
			ReferenceIdentification2 = "u",
			ContractNumber = "c",
			PurchaseOrderNumber = "T",
			ScheduleQuantityQualifier = "p",
		};

		var actual = Map.MapObject<BSS_BeginningSegmentForShippingScheduleProductionSequence>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GB", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.ReferenceIdentification = "z";
		subject.Date = "yuC5lzLA";
		subject.ScheduleTypeQualifier = "lw";
		subject.Date2 = "5BNjUyf7";
		subject.Date3 = "ZaBLRZFP";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
			subject.ReleaseNumber = "z";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "GB";
		subject.Date = "yuC5lzLA";
		subject.ScheduleTypeQualifier = "lw";
		subject.Date2 = "5BNjUyf7";
		subject.Date3 = "ZaBLRZFP";
		subject.ReferenceIdentification = referenceIdentification;
			subject.ReleaseNumber = "z";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yuC5lzLA", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "GB";
		subject.ReferenceIdentification = "z";
		subject.ScheduleTypeQualifier = "lw";
		subject.Date2 = "5BNjUyf7";
		subject.Date3 = "ZaBLRZFP";
		subject.Date = date;
			subject.ReleaseNumber = "z";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lw", true)]
	public void Validation_RequiredScheduleTypeQualifier(string scheduleTypeQualifier, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "GB";
		subject.ReferenceIdentification = "z";
		subject.Date = "yuC5lzLA";
		subject.Date2 = "5BNjUyf7";
		subject.Date3 = "ZaBLRZFP";
		subject.ScheduleTypeQualifier = scheduleTypeQualifier;
			subject.ReleaseNumber = "z";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5BNjUyf7", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "GB";
		subject.ReferenceIdentification = "z";
		subject.Date = "yuC5lzLA";
		subject.ScheduleTypeQualifier = "lw";
		subject.Date3 = "ZaBLRZFP";
		subject.Date2 = date2;
			subject.ReleaseNumber = "z";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZaBLRZFP", true)]
	public void Validation_RequiredDate3(string date3, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "GB";
		subject.ReferenceIdentification = "z";
		subject.Date = "yuC5lzLA";
		subject.ScheduleTypeQualifier = "lw";
		subject.Date2 = "5BNjUyf7";
		subject.Date3 = date3;
			subject.ReleaseNumber = "z";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("z", "u", true)]
	[InlineData("z", "", true)]
	[InlineData("", "u", true)]
	public void Validation_AtLeastOneReleaseNumber(string releaseNumber, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "GB";
		subject.ReferenceIdentification = "z";
		subject.Date = "yuC5lzLA";
		subject.ScheduleTypeQualifier = "lw";
		subject.Date2 = "5BNjUyf7";
		subject.Date3 = "ZaBLRZFP";
		subject.ReleaseNumber = releaseNumber;
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
