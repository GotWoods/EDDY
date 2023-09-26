using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BMATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BMA*KG*i*ep*xkMKoi*oNzbxy*as*1*M";

		var expected = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation()
		{
			TransactionSetPurposeCode = "KG",
			ReferenceIdentification = "i",
			AllowanceOrChargeMethodOfHandlingCode = "ep",
			Date = "xkMKoi",
			Date2 = "oNzbxy",
			TransactionTypeCode = "as",
			MonetaryAmount = 1,
			Description = "M",
		};

		var actual = Map.MapObject<BMA_BeginningSegmentForMarketDevelopmentFundAllocation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("KG", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		//Required fields
		subject.ReferenceIdentification = "i";
		subject.AllowanceOrChargeMethodOfHandlingCode = "ep";
		subject.Date = "xkMKoi";
		subject.Date2 = "oNzbxy";
		subject.TransactionTypeCode = "as";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		//Required fields
		subject.TransactionSetPurposeCode = "KG";
		subject.AllowanceOrChargeMethodOfHandlingCode = "ep";
		subject.Date = "xkMKoi";
		subject.Date2 = "oNzbxy";
		subject.TransactionTypeCode = "as";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ep", true)]
	public void Validation_RequiredAllowanceOrChargeMethodOfHandlingCode(string allowanceOrChargeMethodOfHandlingCode, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		//Required fields
		subject.TransactionSetPurposeCode = "KG";
		subject.ReferenceIdentification = "i";
		subject.Date = "xkMKoi";
		subject.Date2 = "oNzbxy";
		subject.TransactionTypeCode = "as";
		//Test Parameters
		subject.AllowanceOrChargeMethodOfHandlingCode = allowanceOrChargeMethodOfHandlingCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xkMKoi", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		//Required fields
		subject.TransactionSetPurposeCode = "KG";
		subject.ReferenceIdentification = "i";
		subject.AllowanceOrChargeMethodOfHandlingCode = "ep";
		subject.Date2 = "oNzbxy";
		subject.TransactionTypeCode = "as";
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oNzbxy", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		//Required fields
		subject.TransactionSetPurposeCode = "KG";
		subject.ReferenceIdentification = "i";
		subject.AllowanceOrChargeMethodOfHandlingCode = "ep";
		subject.Date = "xkMKoi";
		subject.TransactionTypeCode = "as";
		//Test Parameters
		subject.Date2 = date2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("as", true)]
	public void Validation_RequiredTransactionTypeCode(string transactionTypeCode, bool isValidExpected)
	{
		var subject = new BMA_BeginningSegmentForMarketDevelopmentFundAllocation();
		//Required fields
		subject.TransactionSetPurposeCode = "KG";
		subject.ReferenceIdentification = "i";
		subject.AllowanceOrChargeMethodOfHandlingCode = "ep";
		subject.Date = "xkMKoi";
		subject.Date2 = "oNzbxy";
		//Test Parameters
		subject.TransactionTypeCode = transactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
