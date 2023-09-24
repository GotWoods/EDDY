using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class BPTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BPT*uB*H*RrnRXfjG*5J*gSg*3*6*UqoZ*t*qp";

		var expected = new BPT_BeginningSegmentForProductTransferAndResale()
		{
			TransactionSetPurposeCode = "uB",
			ReferenceIdentification = "H",
			Date = "RrnRXfjG",
			ReportTypeCode = "5J",
			PriceMultiplierQualifier = "gSg",
			Multiplier = 3,
			ActionCode = "6",
			Time = "UqoZ",
			ReferenceIdentification2 = "t",
			SecurityLevelCode = "qp",
		};

		var actual = Map.MapObject<BPT_BeginningSegmentForProductTransferAndResale>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uB", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BPT_BeginningSegmentForProductTransferAndResale();
		subject.Date = "RrnRXfjG";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PriceMultiplierQualifier) || !string.IsNullOrEmpty(subject.PriceMultiplierQualifier) || subject.Multiplier > 0)
		{
			subject.PriceMultiplierQualifier = "gSg";
			subject.Multiplier = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RrnRXfjG", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BPT_BeginningSegmentForProductTransferAndResale();
		subject.TransactionSetPurposeCode = "uB";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PriceMultiplierQualifier) || !string.IsNullOrEmpty(subject.PriceMultiplierQualifier) || subject.Multiplier > 0)
		{
			subject.PriceMultiplierQualifier = "gSg";
			subject.Multiplier = 3;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("gSg", 3, true)]
	[InlineData("gSg", 0, false)]
	[InlineData("", 3, false)]
	public void Validation_AllAreRequiredPriceMultiplierQualifier(string priceMultiplierQualifier, decimal multiplier, bool isValidExpected)
	{
		var subject = new BPT_BeginningSegmentForProductTransferAndResale();
		subject.TransactionSetPurposeCode = "uB";
		subject.Date = "RrnRXfjG";
		subject.PriceMultiplierQualifier = priceMultiplierQualifier;
		if (multiplier > 0)
			subject.Multiplier = multiplier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
