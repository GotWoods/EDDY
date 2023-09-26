using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class BMATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BMA*je*b*SI*lRwbqr*CFfaNz*cZ*1*v";

		var expected = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation()
		{
			TransactionSetPurposeCode = "je",
			ReferenceNumber = "b",
			AllowanceOrChargeMethodOfHandlingCode = "SI",
			Date = "lRwbqr",
			Date2 = "CFfaNz",
			TransactionTypeCode = "cZ",
			MonetaryAmount = 1,
			Description = "v",
		};

		var actual = Map.MapObject<BMA_BeginningSegmentForMarketDevelopmentFundAllocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("je", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		//Required fields
		subject.ReferenceNumber = "b";
		subject.AllowanceOrChargeMethodOfHandlingCode = "SI";
		subject.Date = "lRwbqr";
		subject.Date2 = "CFfaNz";
		subject.TransactionTypeCode = "cZ";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("b", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		//Required fields
		subject.TransactionSetPurposeCode = "je";
		subject.AllowanceOrChargeMethodOfHandlingCode = "SI";
		subject.Date = "lRwbqr";
		subject.Date2 = "CFfaNz";
		subject.TransactionTypeCode = "cZ";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("SI", true)]
	public void Validation_RequiredAllowanceOrChargeMethodOfHandlingCode(string allowanceOrChargeMethodOfHandlingCode, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		//Required fields
		subject.TransactionSetPurposeCode = "je";
		subject.ReferenceNumber = "b";
		subject.Date = "lRwbqr";
		subject.Date2 = "CFfaNz";
		subject.TransactionTypeCode = "cZ";
		//Test Parameters
		subject.AllowanceOrChargeMethodOfHandlingCode = allowanceOrChargeMethodOfHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lRwbqr", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		//Required fields
		subject.TransactionSetPurposeCode = "je";
		subject.ReferenceNumber = "b";
		subject.AllowanceOrChargeMethodOfHandlingCode = "SI";
		subject.Date2 = "CFfaNz";
		subject.TransactionTypeCode = "cZ";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CFfaNz", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		//Required fields
		subject.TransactionSetPurposeCode = "je";
		subject.ReferenceNumber = "b";
		subject.AllowanceOrChargeMethodOfHandlingCode = "SI";
		subject.Date = "lRwbqr";
		subject.TransactionTypeCode = "cZ";
		//Test Parameters
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cZ", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		//Required fields
		subject.TransactionSetPurposeCode = "je";
		subject.ReferenceNumber = "b";
		subject.AllowanceOrChargeMethodOfHandlingCode = "SI";
		subject.Date = "lRwbqr";
		subject.Date2 = "CFfaNz";
		//Test Parameters
		subject.TransactionTypeCode = transactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
