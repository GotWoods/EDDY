using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class BMATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BMA*Qc*Z*y9*oq8eYOur*hk2JZUlI*oh*1*X";

		var expected = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation()
		{
			TransactionSetPurposeCode = "Qc",
			ReferenceIdentification = "Z",
			AllowanceOrChargeMethodOfHandlingCode = "y9",
			Date = "oq8eYOur",
			Date2 = "hk2JZUlI",
			TransactionTypeCode = "oh",
			MonetaryAmount = 1,
			Description = "X",
		};

		var actual = Map.MapObject<BMA_BeginningSegmentForMarketDevelopmentFundAllocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Qc", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		//Required fields
		subject.ReferenceIdentification = "Z";
		subject.AllowanceOrChargeMethodOfHandlingCode = "y9";
		subject.Date = "oq8eYOur";
		subject.Date2 = "hk2JZUlI";
		subject.TransactionTypeCode = "oh";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		//Required fields
		subject.TransactionSetPurposeCode = "Qc";
		subject.AllowanceOrChargeMethodOfHandlingCode = "y9";
		subject.Date = "oq8eYOur";
		subject.Date2 = "hk2JZUlI";
		subject.TransactionTypeCode = "oh";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y9", true)]
	public void Validation_RequiredAllowanceOrChargeMethodOfHandlingCode(string allowanceOrChargeMethodOfHandlingCode, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		//Required fields
		subject.TransactionSetPurposeCode = "Qc";
		subject.ReferenceIdentification = "Z";
		subject.Date = "oq8eYOur";
		subject.Date2 = "hk2JZUlI";
		subject.TransactionTypeCode = "oh";
		//Test Parameters
		subject.AllowanceOrChargeMethodOfHandlingCode = allowanceOrChargeMethodOfHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oq8eYOur", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		//Required fields
		subject.TransactionSetPurposeCode = "Qc";
		subject.ReferenceIdentification = "Z";
		subject.AllowanceOrChargeMethodOfHandlingCode = "y9";
		subject.Date2 = "hk2JZUlI";
		subject.TransactionTypeCode = "oh";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hk2JZUlI", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		//Required fields
		subject.TransactionSetPurposeCode = "Qc";
		subject.ReferenceIdentification = "Z";
		subject.AllowanceOrChargeMethodOfHandlingCode = "y9";
		subject.Date = "oq8eYOur";
		subject.TransactionTypeCode = "oh";
		//Test Parameters
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oh", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		//Required fields
		subject.TransactionSetPurposeCode = "Qc";
		subject.ReferenceIdentification = "Z";
		subject.AllowanceOrChargeMethodOfHandlingCode = "y9";
		subject.Date = "oq8eYOur";
		subject.Date2 = "hk2JZUlI";
		//Test Parameters
		subject.TransactionTypeCode = transactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
