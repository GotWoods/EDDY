using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BMATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BMA*Vd*1*ga*A1SbSqdp*I8pAD5eT*NT*3*E";

		var expected = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation()
		{
			TransactionSetPurposeCode = "Vd",
			ReferenceIdentification = "1",
			AllowanceOrChargeMethodOfHandlingCode = "ga",
			Date = "A1SbSqdp",
			Date2 = "I8pAD5eT",
			TransactionTypeCode = "NT",
			MonetaryAmount = 3,
			Description = "E",
		};

		var actual = Map.MapObject<BMA_BeginningSegmentForMarketDevelopmentFundAllocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Vd", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		//Required fields
		subject.ReferenceIdentification = "1";
		subject.AllowanceOrChargeMethodOfHandlingCode = "ga";
		subject.Date = "A1SbSqdp";
		subject.Date2 = "I8pAD5eT";
		subject.TransactionTypeCode = "NT";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		//Required fields
		subject.TransactionSetPurposeCode = "Vd";
		subject.AllowanceOrChargeMethodOfHandlingCode = "ga";
		subject.Date = "A1SbSqdp";
		subject.Date2 = "I8pAD5eT";
		subject.TransactionTypeCode = "NT";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ga", true)]
	public void Validation_RequiredAllowanceOrChargeMethodOfHandlingCode(string allowanceOrChargeMethodOfHandlingCode, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		//Required fields
		subject.TransactionSetPurposeCode = "Vd";
		subject.ReferenceIdentification = "1";
		subject.Date = "A1SbSqdp";
		subject.Date2 = "I8pAD5eT";
		subject.TransactionTypeCode = "NT";
		//Test Parameters
		subject.AllowanceOrChargeMethodOfHandlingCode = allowanceOrChargeMethodOfHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A1SbSqdp", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		//Required fields
		subject.TransactionSetPurposeCode = "Vd";
		subject.ReferenceIdentification = "1";
		subject.AllowanceOrChargeMethodOfHandlingCode = "ga";
		subject.Date2 = "I8pAD5eT";
		subject.TransactionTypeCode = "NT";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I8pAD5eT", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		//Required fields
		subject.TransactionSetPurposeCode = "Vd";
		subject.ReferenceIdentification = "1";
		subject.AllowanceOrChargeMethodOfHandlingCode = "ga";
		subject.Date = "A1SbSqdp";
		subject.TransactionTypeCode = "NT";
		//Test Parameters
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("NT", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		//Required fields
		subject.TransactionSetPurposeCode = "Vd";
		subject.ReferenceIdentification = "1";
		subject.AllowanceOrChargeMethodOfHandlingCode = "ga";
		subject.Date = "A1SbSqdp";
		subject.Date2 = "I8pAD5eT";
		//Test Parameters
		subject.TransactionTypeCode = transactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
