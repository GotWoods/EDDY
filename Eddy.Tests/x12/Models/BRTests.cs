using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BR*Xk*7U*xgGcpE2G*Xv*r*V*S6*H*cZdJ*Ip*b";

		var expected = new BR_BeginningSegmentForMaterialManagement()
		{
			TransactionSetPurposeCode = "Xk",
			TransactionTypeCode = "7U",
			Date = "xgGcpE2G",
			IdentificationCode = "Xv",
			IdentificationCodeQualifier = "r",
			ActionCode = "V",
			ReferenceIdentificationQualifier = "S6",
			ReferenceIdentification = "H",
			Time = "cZdJ",
			ReferenceIdentificationQualifier2 = "Ip",
			ReferenceIdentification2 = "b",
		};

		var actual = Map.MapObject<BR_BeginningSegmentForMaterialManagement>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Xk", true)]
	public void Validatation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BR_BeginningSegmentForMaterialManagement();
		subject.TransactionTypeCode = "7U";
		subject.Date = "xgGcpE2G";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7U", true)]
	public void Validatation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BR_BeginningSegmentForMaterialManagement();
		subject.TransactionSetPurposeCode = "Xk";
		subject.Date = "xgGcpE2G";
		subject.TransactionTypeCode = transactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xgGcpE2G", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BR_BeginningSegmentForMaterialManagement();
		subject.TransactionSetPurposeCode = "Xk";
		subject.TransactionTypeCode = "7U";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "Xv", true)]
	[InlineData("r", "", false)]
	public void Validation_ARequiresBIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new BR_BeginningSegmentForMaterialManagement();
		subject.TransactionSetPurposeCode = "Xk";
		subject.TransactionTypeCode = "7U";
		subject.Date = "xgGcpE2G";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("S6", "H", true)]
	[InlineData("", "H", false)]
	[InlineData("S6", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new BR_BeginningSegmentForMaterialManagement();
		subject.TransactionSetPurposeCode = "Xk";
		subject.TransactionTypeCode = "7U";
		subject.Date = "xgGcpE2G";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Ip", "b", true)]
	[InlineData("", "b", false)]
	[InlineData("Ip", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier2(string referenceIdentificationQualifier2, string referenceIdentification2, bool isValidExpected)
	{
		var subject = new BR_BeginningSegmentForMaterialManagement();
		subject.TransactionSetPurposeCode = "Xk";
		subject.TransactionTypeCode = "7U";
		subject.Date = "xgGcpE2G";
		subject.ReferenceIdentificationQualifier2 = referenceIdentificationQualifier2;
		subject.ReferenceIdentification2 = referenceIdentification2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
