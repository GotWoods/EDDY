using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class BPTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BPT*Ug*k*73IjoG*qu*bhQ*1*T*0FiT*3*0N";

		var expected = new BPT_BeginningSegmentForProductTransferAndResale()
		{
			TransactionSetPurposeCode = "Ug",
			ReferenceIdentification = "k",
			Date = "73IjoG",
			ReportTypeCode = "qu",
			PriceMultiplierQualifier = "bhQ",
			Multiplier = 1,
			ActionCode = "T",
			Time = "0FiT",
			ReferenceIdentification2 = "3",
			SecurityLevelCode = "0N",
		};

		var actual = Map.MapObject<BPT_BeginningSegmentForProductTransferAndResale>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ug", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BPT_BeginningSegmentForProductTransferAndResale();
		subject.Date = "73IjoG";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PriceMultiplierQualifier) || !string.IsNullOrEmpty(subject.PriceMultiplierQualifier) || subject.Multiplier > 0)
		{
			subject.PriceMultiplierQualifier = "bhQ";
			subject.Multiplier = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("73IjoG", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BPT_BeginningSegmentForProductTransferAndResale();
		subject.TransactionSetPurposeCode = "Ug";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.PriceMultiplierQualifier) || !string.IsNullOrEmpty(subject.PriceMultiplierQualifier) || subject.Multiplier > 0)
		{
			subject.PriceMultiplierQualifier = "bhQ";
			subject.Multiplier = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("bhQ", 1, true)]
	[InlineData("bhQ", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredPriceMultiplierQualifier(string priceMultiplierQualifier, decimal multiplier, bool isValidExpected)
	{
		var subject = new BPT_BeginningSegmentForProductTransferAndResale();
		subject.TransactionSetPurposeCode = "Ug";
		subject.Date = "73IjoG";
		subject.PriceMultiplierQualifier = priceMultiplierQualifier;
		if (multiplier > 0)
			subject.Multiplier = multiplier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
