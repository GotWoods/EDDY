using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class BPTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BPT*F6*j*dCVcXvWB*OQ*Sv0*7*M*2L9R*1*Cl";

		var expected = new BPT_BeginningSegmentForProductTransferAndResale()
		{
			TransactionSetPurposeCode = "F6",
			ReferenceIdentification = "j",
			Date = "dCVcXvWB",
			ReportTypeCode = "OQ",
			PriceMultiplierQualifier = "Sv0",
			Multiplier = 7,
			ActionCode = "M",
			Time = "2L9R",
			ReferenceIdentification2 = "1",
			SecurityLevelCode = "Cl",
		};

		var actual = Map.MapObject<BPT_BeginningSegmentForProductTransferAndResale>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F6", true)]
	public void Validatation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new BPT_BeginningSegmentForProductTransferAndResale();
		subject.Date = "dCVcXvWB";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dCVcXvWB", true)]
	public void Validatation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new BPT_BeginningSegmentForProductTransferAndResale();
		subject.TransactionSetPurposeCode = "F6";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("Sv0", 7, true)]
	[InlineData("", 7, false)]
	[InlineData("Sv0", 0, false)]
	public void Validation_AllAreRequiredPriceMultiplierQualifier(string priceMultiplierQualifier, decimal multiplier, bool isValidExpected)
	{
		var subject = new BPT_BeginningSegmentForProductTransferAndResale();
		subject.TransactionSetPurposeCode = "F6";
		subject.Date = "dCVcXvWB";
		subject.PriceMultiplierQualifier = priceMultiplierQualifier;
		if (multiplier > 0)
		subject.Multiplier = multiplier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
