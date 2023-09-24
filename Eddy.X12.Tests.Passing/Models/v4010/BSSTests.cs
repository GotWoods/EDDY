using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BSSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSS*kz*b*VyBMDGev*9d*V9Y8lBBe*Ilzg2Ko6*y*O*3*N*A";

		var expected = new BSS_BeginningSegmentForShippingScheduleProductionSequence()
		{
			TransactionSetPurposeCode = "kz",
			ReferenceIdentification = "b",
			Date = "VyBMDGev",
			ScheduleTypeQualifier = "9d",
			Date2 = "V9Y8lBBe",
			Date3 = "Ilzg2Ko6",
			ReleaseNumber = "y",
			ReferenceIdentification2 = "O",
			ContractNumber = "3",
			PurchaseOrderNumber = "N",
			ScheduleQuantityQualifier = "A",
		};

		var actual = Map.MapObject<BSS_BeginningSegmentForShippingScheduleProductionSequence>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kz", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.ReferenceIdentification = "b";
		subject.Date = "VyBMDGev";
		subject.ScheduleTypeQualifier = "9d";
		subject.Date2 = "V9Y8lBBe";
		subject.Date3 = "Ilzg2Ko6";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
			subject.ReleaseNumber = "y";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "kz";
		subject.Date = "VyBMDGev";
		subject.ScheduleTypeQualifier = "9d";
		subject.Date2 = "V9Y8lBBe";
		subject.Date3 = "Ilzg2Ko6";
		subject.ReferenceIdentification = referenceIdentification;
			subject.ReleaseNumber = "y";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VyBMDGev", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "kz";
		subject.ReferenceIdentification = "b";
		subject.ScheduleTypeQualifier = "9d";
		subject.Date2 = "V9Y8lBBe";
		subject.Date3 = "Ilzg2Ko6";
		subject.Date = date;
			subject.ReleaseNumber = "y";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9d", true)]
	public void Validation_RequiredScheduleTypeQualifier(string scheduleTypeQualifier, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "kz";
		subject.ReferenceIdentification = "b";
		subject.Date = "VyBMDGev";
		subject.Date2 = "V9Y8lBBe";
		subject.Date3 = "Ilzg2Ko6";
		subject.ScheduleTypeQualifier = scheduleTypeQualifier;
			subject.ReleaseNumber = "y";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V9Y8lBBe", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "kz";
		subject.ReferenceIdentification = "b";
		subject.Date = "VyBMDGev";
		subject.ScheduleTypeQualifier = "9d";
		subject.Date3 = "Ilzg2Ko6";
		subject.Date2 = date2;
			subject.ReleaseNumber = "y";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ilzg2Ko6", true)]
	public void Validation_RequiredDate3(string date3, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "kz";
		subject.ReferenceIdentification = "b";
		subject.Date = "VyBMDGev";
		subject.ScheduleTypeQualifier = "9d";
		subject.Date2 = "V9Y8lBBe";
		subject.Date3 = date3;
			subject.ReleaseNumber = "y";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("y", "O", true)]
	[InlineData("y", "", true)]
	[InlineData("", "O", true)]
	public void Validation_AtLeastOneReleaseNumber(string releaseNumber, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "kz";
		subject.ReferenceIdentification = "b";
		subject.Date = "VyBMDGev";
		subject.ScheduleTypeQualifier = "9d";
		subject.Date2 = "V9Y8lBBe";
		subject.Date3 = "Ilzg2Ko6";
		subject.ReleaseNumber = releaseNumber;
		subject.ReferenceIdentification2 = referenceIdentification2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
