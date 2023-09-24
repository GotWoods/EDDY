using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BSSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSS*X5*w*4xBpwH*bU*v9ieRC*lB7TJx*a*y*d*m*d";

		var expected = new BSS_BeginningSegmentForShippingScheduleProductionSequence()
		{
			TransactionSetPurposeCode = "X5",
			ReferenceIdentification = "w",
			Date = "4xBpwH",
			ScheduleTypeQualifier = "bU",
			Date2 = "v9ieRC",
			Date3 = "lB7TJx",
			ReleaseNumber = "a",
			ReferenceIdentification2 = "y",
			ContractNumber = "d",
			PurchaseOrderNumber = "m",
			ScheduleQuantityQualifier = "d",
		};

		var actual = Map.MapObject<BSS_BeginningSegmentForShippingScheduleProductionSequence>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X5", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.ReferenceIdentification = "w";
		subject.Date = "4xBpwH";
		subject.ScheduleTypeQualifier = "bU";
		subject.Date2 = "v9ieRC";
		subject.Date3 = "lB7TJx";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
			subject.ReleaseNumber = "a";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "X5";
		subject.Date = "4xBpwH";
		subject.ScheduleTypeQualifier = "bU";
		subject.Date2 = "v9ieRC";
		subject.Date3 = "lB7TJx";
		subject.ReferenceIdentification = referenceIdentification;
			subject.ReleaseNumber = "a";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4xBpwH", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "X5";
		subject.ReferenceIdentification = "w";
		subject.ScheduleTypeQualifier = "bU";
		subject.Date2 = "v9ieRC";
		subject.Date3 = "lB7TJx";
		subject.Date = date;
			subject.ReleaseNumber = "a";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bU", true)]
	public void Validation_RequiredScheduleTypeQualifier(string scheduleTypeQualifier, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "X5";
		subject.ReferenceIdentification = "w";
		subject.Date = "4xBpwH";
		subject.Date2 = "v9ieRC";
		subject.Date3 = "lB7TJx";
		subject.ScheduleTypeQualifier = scheduleTypeQualifier;
			subject.ReleaseNumber = "a";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v9ieRC", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "X5";
		subject.ReferenceIdentification = "w";
		subject.Date = "4xBpwH";
		subject.ScheduleTypeQualifier = "bU";
		subject.Date3 = "lB7TJx";
		subject.Date2 = date2;
			subject.ReleaseNumber = "a";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lB7TJx", true)]
	public void Validation_RequiredDate3(string date3, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "X5";
		subject.ReferenceIdentification = "w";
		subject.Date = "4xBpwH";
		subject.ScheduleTypeQualifier = "bU";
		subject.Date2 = "v9ieRC";
		subject.Date3 = date3;
			subject.ReleaseNumber = "a";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("a", "y", true)]
	[InlineData("a", "", true)]
	[InlineData("", "y", true)]
	public void Validation_AtLeastOneReleaseNumber(string releaseNumber, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "X5";
		subject.ReferenceIdentification = "w";
		subject.Date = "4xBpwH";
		subject.ScheduleTypeQualifier = "bU";
		subject.Date2 = "v9ieRC";
		subject.Date3 = "lB7TJx";
		subject.ReleaseNumber = releaseNumber;
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
