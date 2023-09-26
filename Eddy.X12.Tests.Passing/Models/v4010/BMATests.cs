using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class BMATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BMA*ps*n*5b*3T78ckrM*E9LFXE5W*jr*5*4";

		var expected = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation()
		{
			TransactionSetPurposeCode = "ps",
			ReferenceIdentification = "n",
			AllowanceOrChargeMethodOfHandlingCode = "5b",
			Date = "3T78ckrM",
			Date2 = "E9LFXE5W",
			TransactionTypeCode = "jr",
			MonetaryAmount = 5,
			Description = "4",
		};

		var actual = Map.MapObject<BMA_BeginningSegmentForMarketDevelopmentFundAllocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ps", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		//Required fields
		subject.ReferenceIdentification = "n";
		subject.AllowanceOrChargeMethodOfHandlingCode = "5b";
		subject.Date = "3T78ckrM";
		subject.Date2 = "E9LFXE5W";
		subject.TransactionTypeCode = "jr";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		//Required fields
		subject.TransactionSetPurposeCode = "ps";
		subject.AllowanceOrChargeMethodOfHandlingCode = "5b";
		subject.Date = "3T78ckrM";
		subject.Date2 = "E9LFXE5W";
		subject.TransactionTypeCode = "jr";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5b", true)]
	public void Validation_RequiredAllowanceOrChargeMethodOfHandlingCode(string allowanceOrChargeMethodOfHandlingCode, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		//Required fields
		subject.TransactionSetPurposeCode = "ps";
		subject.ReferenceIdentification = "n";
		subject.Date = "3T78ckrM";
		subject.Date2 = "E9LFXE5W";
		subject.TransactionTypeCode = "jr";
		//Test Parameters
		subject.AllowanceOrChargeMethodOfHandlingCode = allowanceOrChargeMethodOfHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3T78ckrM", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		//Required fields
		subject.TransactionSetPurposeCode = "ps";
		subject.ReferenceIdentification = "n";
		subject.AllowanceOrChargeMethodOfHandlingCode = "5b";
		subject.Date2 = "E9LFXE5W";
		subject.TransactionTypeCode = "jr";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E9LFXE5W", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		//Required fields
		subject.TransactionSetPurposeCode = "ps";
		subject.ReferenceIdentification = "n";
		subject.AllowanceOrChargeMethodOfHandlingCode = "5b";
		subject.Date = "3T78ckrM";
		subject.TransactionTypeCode = "jr";
		//Test Parameters
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jr", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		//Required fields
		subject.TransactionSetPurposeCode = "ps";
		subject.ReferenceIdentification = "n";
		subject.AllowanceOrChargeMethodOfHandlingCode = "5b";
		subject.Date = "3T78ckrM";
		subject.Date2 = "E9LFXE5W";
		//Test Parameters
		subject.TransactionTypeCode = transactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
