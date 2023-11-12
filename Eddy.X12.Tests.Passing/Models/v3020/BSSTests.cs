using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class BSSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSS*Gt*E*jDFeBP*13*T2F3gv*27D4vx*Y*2*y*3*1";

		var expected = new BSS_BeginningSegmentForShippingScheduleProductionSequence()
		{
			TransactionSetPurposeCode = "Gt",
			ReferenceNumber = "E",
			Date = "jDFeBP",
			ScheduleTypeQualifier = "13",
			Date2 = "T2F3gv",
			Date3 = "27D4vx",
			ReleaseNumber = "Y",
			ReferenceNumber2 = "2",
			ContractNumber = "y",
			PurchaseOrderNumber = "3",
			ScheduleQuantityQualifier = "1",
		};

		var actual = Map.MapObject<BSS_BeginningSegmentForShippingScheduleProductionSequence>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Gt", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.ReferenceNumber = "E";
		subject.Date = "jDFeBP";
		subject.ScheduleTypeQualifier = "13";
		subject.Date2 = "T2F3gv";
		subject.Date3 = "27D4vx";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
			subject.ReleaseNumber = "Y";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "Gt";
		subject.Date = "jDFeBP";
		subject.ScheduleTypeQualifier = "13";
		subject.Date2 = "T2F3gv";
		subject.Date3 = "27D4vx";
		subject.ReferenceNumber = referenceNumber;
			subject.ReleaseNumber = "Y";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jDFeBP", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "Gt";
		subject.ReferenceNumber = "E";
		subject.ScheduleTypeQualifier = "13";
		subject.Date2 = "T2F3gv";
		subject.Date3 = "27D4vx";
		subject.Date = date;
			subject.ReleaseNumber = "Y";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("13", true)]
	public void Validation_RequiredScheduleTypeQualifier(string scheduleTypeQualifier, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "Gt";
		subject.ReferenceNumber = "E";
		subject.Date = "jDFeBP";
		subject.Date2 = "T2F3gv";
		subject.Date3 = "27D4vx";
		subject.ScheduleTypeQualifier = scheduleTypeQualifier;
			subject.ReleaseNumber = "Y";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T2F3gv", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "Gt";
		subject.ReferenceNumber = "E";
		subject.Date = "jDFeBP";
		subject.ScheduleTypeQualifier = "13";
		subject.Date3 = "27D4vx";
		subject.Date2 = date2;
			subject.ReleaseNumber = "Y";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("27D4vx", true)]
	public void Validation_RequiredDate3(string date3, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "Gt";
		subject.ReferenceNumber = "E";
		subject.Date = "jDFeBP";
		subject.ScheduleTypeQualifier = "13";
		subject.Date2 = "T2F3gv";
		subject.Date3 = date3;
			subject.ReleaseNumber = "Y";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("Y", "2", true)]
	[InlineData("Y", "", true)]
	[InlineData("", "2", true)]
	public void Validation_AtLeastOneReleaseNumber(string releaseNumber, string referenceNumber2, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "Gt";
		subject.ReferenceNumber = "E";
		subject.Date = "jDFeBP";
		subject.ScheduleTypeQualifier = "13";
		subject.Date2 = "T2F3gv";
		subject.Date3 = "27D4vx";
		subject.ReleaseNumber = releaseNumber;
		subject.ReferenceNumber2 = referenceNumber2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

}
