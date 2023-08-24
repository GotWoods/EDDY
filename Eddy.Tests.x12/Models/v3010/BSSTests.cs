using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BSSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSS*DV*Q*muq782*eR*UmtTJB*Y8eLBG*T*Q*e*d*E";

		var expected = new BSS_BeginningSegmentForShippingScheduleProductionSequence()
		{
			TransactionSetPurposeCode = "DV",
			ReferenceNumber = "Q",
			Date = "muq782",
			ScheduleTypeQualifier = "eR",
			Date2 = "UmtTJB",
			Date3 = "Y8eLBG",
			ReleaseNumber = "T",
			ReferenceNumber2 = "Q",
			ContractNumber = "e",
			PurchaseOrderNumber = "d",
			ScheduleQuantityQualifier = "E",
		};

		var actual = Map.MapObject<BSS_BeginningSegmentForShippingScheduleProductionSequence>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DV", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.ReferenceNumber = "Q";
		subject.Date = "muq782";
		subject.ScheduleTypeQualifier = "eR";
		subject.Date2 = "UmtTJB";
		subject.Date3 = "Y8eLBG";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "DV";
		subject.Date = "muq782";
		subject.ScheduleTypeQualifier = "eR";
		subject.Date2 = "UmtTJB";
		subject.Date3 = "Y8eLBG";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("muq782", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "DV";
		subject.ReferenceNumber = "Q";
		subject.ScheduleTypeQualifier = "eR";
		subject.Date2 = "UmtTJB";
		subject.Date3 = "Y8eLBG";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eR", true)]
	public void Validation_RequiredScheduleTypeQualifier(string scheduleTypeQualifier, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "DV";
		subject.ReferenceNumber = "Q";
		subject.Date = "muq782";
		subject.Date2 = "UmtTJB";
		subject.Date3 = "Y8eLBG";
		subject.ScheduleTypeQualifier = scheduleTypeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("UmtTJB", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "DV";
		subject.ReferenceNumber = "Q";
		subject.Date = "muq782";
		subject.ScheduleTypeQualifier = "eR";
		subject.Date3 = "Y8eLBG";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y8eLBG", true)]
	public void Validation_RequiredDate3(string date3, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "DV";
		subject.ReferenceNumber = "Q";
		subject.Date = "muq782";
		subject.ScheduleTypeQualifier = "eR";
		subject.Date2 = "UmtTJB";
		subject.Date3 = date3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
