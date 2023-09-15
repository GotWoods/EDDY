using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class BPTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BPT*Z0*U*A4q7pF*3E*pnC*8*z*HQj6*A";

		var expected = new BPT_BeginningSegmentForProductTransferAndResale()
		{
			TransactionSetPurposeCode = "Z0",
			ReferenceNumber = "U",
			Date = "A4q7pF",
			ReportTypeCode = "3E",
			PriceMultiplierQualifier = "pnC",
			Multiplier = 8,
			ActionCode = "z",
			Time = "HQj6",
			ReferenceNumber2 = "A",
		};

		var actual = Map.MapObject<BPT_BeginningSegmentForProductTransferAndResale>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z0", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BPT_BeginningSegmentForProductTransferAndResale();
		subject.Date = "A4q7pF";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PriceMultiplierQualifier) || !string.IsNullOrEmpty(subject.PriceMultiplierQualifier) || subject.Multiplier > 0)
		{
			subject.PriceMultiplierQualifier = "pnC";
			subject.Multiplier = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A4q7pF", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BPT_BeginningSegmentForProductTransferAndResale();
		subject.TransactionSetPurposeCode = "Z0";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PriceMultiplierQualifier) || !string.IsNullOrEmpty(subject.PriceMultiplierQualifier) || subject.Multiplier > 0)
		{
			subject.PriceMultiplierQualifier = "pnC";
			subject.Multiplier = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("pnC", 8, true)]
	[InlineData("pnC", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredPriceMultiplierQualifier(string priceMultiplierQualifier, decimal multiplier, bool isValidExpected)
	{
		var subject = new BPT_BeginningSegmentForProductTransferAndResale();
		subject.TransactionSetPurposeCode = "Z0";
		subject.Date = "A4q7pF";
		subject.PriceMultiplierQualifier = priceMultiplierQualifier;
		if (multiplier > 0)
			subject.Multiplier = multiplier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
