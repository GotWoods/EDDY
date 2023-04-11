using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BSSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSS*7k*R*JTxZ0WDE*G5*vQxEDxHL*Lm4cmzj6*i*Q*C*u*8";

		var expected = new BSS_BeginningSegmentForShippingScheduleProductionSequence()
		{
			TransactionSetPurposeCode = "7k",
			ReferenceIdentification = "R",
			Date = "JTxZ0WDE",
			ScheduleTypeQualifier = "G5",
			Date2 = "vQxEDxHL",
			Date3 = "Lm4cmzj6",
			ReleaseNumber = "i",
			ReferenceIdentification2 = "Q",
			ContractNumber = "C",
			PurchaseOrderNumber = "u",
			ScheduleQuantityQualifier = "8",
		};

		var actual = Map.MapObject<BSS_BeginningSegmentForShippingScheduleProductionSequence>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
        Assert.Equivalent(expected, actual);
    }

	[Theory]
	[InlineData("", false)]
	[InlineData("7k", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.ReferenceIdentification = "R";
		subject.Date = "JTxZ0WDE";
		subject.ScheduleTypeQualifier = "G5";
		subject.Date2 = "vQxEDxHL";
		subject.Date3 = "Lm4cmzj6";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;

        subject.ReleaseNumber = "123";

        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "7k";
		subject.Date = "JTxZ0WDE";
		subject.ScheduleTypeQualifier = "G5";
		subject.Date2 = "vQxEDxHL";
		subject.Date3 = "Lm4cmzj6";
		subject.ReferenceIdentification = referenceIdentification;
        
        subject.ReleaseNumber = "123";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("JTxZ0WDE", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "7k";
		subject.ReferenceIdentification = "R";
		subject.ScheduleTypeQualifier = "G5";
		subject.Date2 = "vQxEDxHL";
		subject.Date3 = "Lm4cmzj6";
		subject.Date = date;

		subject.ReleaseNumber = "123";

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G5", true)]
	public void Validation_RequiredScheduleTypeQualifier(string scheduleTypeQualifier, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "7k";
		subject.ReferenceIdentification = "R";
		subject.Date = "JTxZ0WDE";
		subject.Date2 = "vQxEDxHL";
		subject.Date3 = "Lm4cmzj6";
		subject.ScheduleTypeQualifier = scheduleTypeQualifier;

        subject.ReleaseNumber = "123";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vQxEDxHL", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "7k";
		subject.ReferenceIdentification = "R";
		subject.Date = "JTxZ0WDE";
		subject.ScheduleTypeQualifier = "G5";
		subject.Date3 = "Lm4cmzj6";
		subject.Date2 = date2;

        subject.ReleaseNumber = "123";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Lm4cmzj6", true)]
	public void Validation_RequiredDate3(string date3, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "7k";
		subject.ReferenceIdentification = "R";
		subject.Date = "JTxZ0WDE";
		subject.ScheduleTypeQualifier = "G5";
		subject.Date2 = "vQxEDxHL";
		subject.Date3 = date3;

        subject.ReleaseNumber = "123";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("i","Q", true)]
	[InlineData("", "Q", true)]
	[InlineData("i", "", true)]
	public void Validation_AtLeastOneReleaseNumber(string releaseNumber, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "7k";
		subject.ReferenceIdentification = "R";
		subject.Date = "JTxZ0WDE";
		subject.ScheduleTypeQualifier = "G5";
		subject.Date2 = "vQxEDxHL";
		subject.Date3 = "Lm4cmzj6";
		subject.ReleaseNumber = releaseNumber;
		subject.ReferenceIdentification2 = referenceIdentification2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
