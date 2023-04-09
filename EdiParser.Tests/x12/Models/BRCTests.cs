using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BRCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BRC*0C*F7mljGLd*z1*0*H5Rr";

		var expected = new BRC_BeginningSegmentForResponseToProductTransferAccountAdjustment()
		{
			TransactionSetPurposeCode = "0C",
			Date = "F7mljGLd",
			ReferenceIdentificationQualifier = "z1",
			ReferenceIdentification = "0",
			Time = "H5Rr",
		};

		var actual = Map.MapObject<BRC_BeginningSegmentForResponseToProductTransferAccountAdjustment>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0C", true)]
	public void Validatation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BRC_BeginningSegmentForResponseToProductTransferAccountAdjustment();
		subject.Date = "F7mljGLd";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F7mljGLd", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BRC_BeginningSegmentForResponseToProductTransferAccountAdjustment();
		subject.TransactionSetPurposeCode = "0C";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("z1", "0", true)]
	[InlineData("", "0", false)]
	[InlineData("z1", "", false)]
	public void Validation_AllAreRequiredReferenceIdentificationQualifier(string referenceIdentificationQualifier, string referenceIdentification, bool isValidExpected)
	{
		var subject = new BRC_BeginningSegmentForResponseToProductTransferAccountAdjustment();
		subject.TransactionSetPurposeCode = "0C";
		subject.Date = "F7mljGLd";
		subject.ReferenceIdentificationQualifier = referenceIdentificationQualifier;
		subject.ReferenceIdentification = referenceIdentification;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
