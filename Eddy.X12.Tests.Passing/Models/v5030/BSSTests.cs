using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BSSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSS*5p*2*4EIRoyAS*N3*6M2TgM1x*wJdHNaEX*a*3*W*3*K";

		var expected = new BSS_BeginningSegmentForShippingScheduleProductionSequence()
		{
			TransactionSetPurposeCode = "5p",
			ReferenceIdentification = "2",
			Date = "4EIRoyAS",
			ScheduleTypeQualifier = "N3",
			Date2 = "6M2TgM1x",
			Date3 = "wJdHNaEX",
			ReleaseNumber = "a",
			ReferenceIdentification2 = "3",
			ContractNumber = "W",
			PurchaseOrderNumber = "3",
			ScheduleQuantityQualifier = "K",
		};

		var actual = Map.MapObject<BSS_BeginningSegmentForShippingScheduleProductionSequence>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5p", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.ReferenceIdentification = "2";
		subject.Date = "4EIRoyAS";
		subject.ScheduleTypeQualifier = "N3";
		subject.Date2 = "6M2TgM1x";
		subject.Date3 = "wJdHNaEX";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
			subject.ReleaseNumber = "a";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "5p";
		subject.Date = "4EIRoyAS";
		subject.ScheduleTypeQualifier = "N3";
		subject.Date2 = "6M2TgM1x";
		subject.Date3 = "wJdHNaEX";
		subject.ReferenceIdentification = referenceIdentification;
			subject.ReleaseNumber = "a";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4EIRoyAS", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "5p";
		subject.ReferenceIdentification = "2";
		subject.ScheduleTypeQualifier = "N3";
		subject.Date2 = "6M2TgM1x";
		subject.Date3 = "wJdHNaEX";
		subject.Date = date;
			subject.ReleaseNumber = "a";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N3", true)]
	public void Validation_RequiredScheduleTypeQualifier(string scheduleTypeQualifier, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "5p";
		subject.ReferenceIdentification = "2";
		subject.Date = "4EIRoyAS";
		subject.Date2 = "6M2TgM1x";
		subject.Date3 = "wJdHNaEX";
		subject.ScheduleTypeQualifier = scheduleTypeQualifier;
			subject.ReleaseNumber = "a";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6M2TgM1x", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "5p";
		subject.ReferenceIdentification = "2";
		subject.Date = "4EIRoyAS";
		subject.ScheduleTypeQualifier = "N3";
		subject.Date3 = "wJdHNaEX";
		subject.Date2 = date2;
			subject.ReleaseNumber = "a";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wJdHNaEX", true)]
	public void Validation_RequiredDate3(string date3, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "5p";
		subject.ReferenceIdentification = "2";
		subject.Date = "4EIRoyAS";
		subject.ScheduleTypeQualifier = "N3";
		subject.Date2 = "6M2TgM1x";
		subject.Date3 = date3;
			subject.ReleaseNumber = "a";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("a", "3", true)]
	[InlineData("a", "", true)]
	[InlineData("", "3", true)]
	public void Validation_AtLeastOneReleaseNumber(string releaseNumber, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "5p";
		subject.ReferenceIdentification = "2";
		subject.Date = "4EIRoyAS";
		subject.ScheduleTypeQualifier = "N3";
		subject.Date2 = "6M2TgM1x";
		subject.Date3 = "wJdHNaEX";
		subject.ReleaseNumber = releaseNumber;
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
