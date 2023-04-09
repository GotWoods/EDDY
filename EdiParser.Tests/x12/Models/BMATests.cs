using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BMATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BMA*Ia*5*3D*mrplXDRF*OJST0hJJ*jK*7*C";

		var expected = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation()
		{
			TransactionSetPurposeCode = "Ia",
			ReferenceIdentification = "5",
			AllowanceOrChargeMethodOfHandlingCode = "3D",
			Date = "mrplXDRF",
			Date2 = "OJST0hJJ",
			TransactionTypeCode = "jK",
			MonetaryAmount = 7,
			Description = "C",
		};

		var actual = Map.MapObject<BMA_BeginningSegmentForMarketDevelopmentFundAllocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
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
	[InlineData("Ia", true)]
	public void Validatation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		subject.ReferenceIdentification = "5";
		subject.AllowanceOrChargeMethodOfHandlingCode = "3D";
		subject.Date = "mrplXDRF";
		subject.Date2 = "OJST0hJJ";
		subject.TransactionTypeCode = "jK";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validatation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		subject.TransactionSetPurposeCode = "Ia";
		subject.AllowanceOrChargeMethodOfHandlingCode = "3D";
		subject.Date = "mrplXDRF";
		subject.Date2 = "OJST0hJJ";
		subject.TransactionTypeCode = "jK";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3D", true)]
	public void Validatation_RequiredAllowanceOrChargeMethodOfHandlingCode(string allowanceOrChargeMethodOfHandlingCode, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		subject.TransactionSetPurposeCode = "Ia";
		subject.ReferenceIdentification = "5";
		subject.Date = "mrplXDRF";
		subject.Date2 = "OJST0hJJ";
		subject.TransactionTypeCode = "jK";
		subject.AllowanceOrChargeMethodOfHandlingCode = allowanceOrChargeMethodOfHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("mrplXDRF", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		subject.TransactionSetPurposeCode = "Ia";
		subject.ReferenceIdentification = "5";
		subject.AllowanceOrChargeMethodOfHandlingCode = "3D";
		subject.Date2 = "OJST0hJJ";
		subject.TransactionTypeCode = "jK";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("OJST0hJJ", true)]
	public void Validatation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		subject.TransactionSetPurposeCode = "Ia";
		subject.ReferenceIdentification = "5";
		subject.AllowanceOrChargeMethodOfHandlingCode = "3D";
		subject.Date = "mrplXDRF";
		subject.TransactionTypeCode = "jK";
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jK", true)]
	public void Validatation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		subject.TransactionSetPurposeCode = "Ia";
		subject.ReferenceIdentification = "5";
		subject.AllowanceOrChargeMethodOfHandlingCode = "3D";
		subject.Date = "mrplXDRF";
		subject.Date2 = "OJST0hJJ";
		subject.TransactionTypeCode = transactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
