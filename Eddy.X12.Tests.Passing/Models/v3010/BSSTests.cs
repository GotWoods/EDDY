using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class BSSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BSS*3I*v*2pxILa*qq*HWlFtJ*GL3CCe*y*o*f*C*q";

		var expected = new BSS_BeginningSegmentForShippingScheduleProductionSequence()
		{
			TransactionSetPurposeCode = "3I",
			ReferenceNumber = "v",
			Date = "2pxILa",
			ScheduleTypeQualifier = "qq",
			Date2 = "HWlFtJ",
			Date3 = "GL3CCe",
			ReleaseNumber = "y",
			ReferenceNumber2 = "o",
			ContractNumber = "f",
			PurchaseOrderNumber = "C",
			ScheduleQuantityQualifier = "q",
		};

		var actual = Map.MapObject<BSS_BeginningSegmentForShippingScheduleProductionSequence>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3I", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.ReferenceNumber = "v";
		subject.Date = "2pxILa";
		subject.ScheduleTypeQualifier = "qq";
		subject.Date2 = "HWlFtJ";
		subject.Date3 = "GL3CCe";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "3I";
		subject.Date = "2pxILa";
		subject.ScheduleTypeQualifier = "qq";
		subject.Date2 = "HWlFtJ";
		subject.Date3 = "GL3CCe";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2pxILa", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "3I";
		subject.ReferenceNumber = "v";
		subject.ScheduleTypeQualifier = "qq";
		subject.Date2 = "HWlFtJ";
		subject.Date3 = "GL3CCe";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qq", true)]
	public void Validation_RequiredScheduleTypeQualifier(string scheduleTypeQualifier, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "3I";
		subject.ReferenceNumber = "v";
		subject.Date = "2pxILa";
		subject.Date2 = "HWlFtJ";
		subject.Date3 = "GL3CCe";
		subject.ScheduleTypeQualifier = scheduleTypeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("HWlFtJ", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "3I";
		subject.ReferenceNumber = "v";
		subject.Date = "2pxILa";
		subject.ScheduleTypeQualifier = "qq";
		subject.Date3 = "GL3CCe";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GL3CCe", true)]
	public void Validation_RequiredDate3(string date3, bool isValidExpected)
	{
		var subject = new BSS_BeginningSegmentForShippingScheduleProductionSequence();
		subject.TransactionSetPurposeCode = "3I";
		subject.ReferenceNumber = "v";
		subject.Date = "2pxILa";
		subject.ScheduleTypeQualifier = "qq";
		subject.Date2 = "HWlFtJ";
		subject.Date3 = date3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
