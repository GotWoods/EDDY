using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class VRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VR*vp*P*gu*O*hk*gEO*n*5*L0V3";

		var expected = new VR_RateOrigin()
		{
			TransactionSetPurposeCode = "vp",
			TariffNumber = "P",
			StandardCarrierAlphaCode = "gu",
			IdentificationCodeQualifier = "O",
			IdentificationCode = "hk",
			CurrencyCode = "gEO",
			TariffAgencyCode = "n",
			TariffSupplementIdentifier = "5",
			ExParte = "L0V3",
		};

		var actual = Map.MapObject<VR_RateOrigin>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vp", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new VR_RateOrigin();
		//Required fields
		subject.TariffNumber = "P";
		subject.StandardCarrierAlphaCode = "gu";
		subject.IdentificationCodeQualifier = "O";
		subject.IdentificationCode = "hk";
		subject.CurrencyCode = "gEO";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("P", true)]
	public void Validation_RequiredTariffNumber(string tariffNumber, bool isValidExpected)
	{
		var subject = new VR_RateOrigin();
		//Required fields
		subject.TransactionSetPurposeCode = "vp";
		subject.StandardCarrierAlphaCode = "gu";
		subject.IdentificationCodeQualifier = "O";
		subject.IdentificationCode = "hk";
		subject.CurrencyCode = "gEO";
		//Test Parameters
		subject.TariffNumber = tariffNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gu", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new VR_RateOrigin();
		//Required fields
		subject.TransactionSetPurposeCode = "vp";
		subject.TariffNumber = "P";
		subject.IdentificationCodeQualifier = "O";
		subject.IdentificationCode = "hk";
		subject.CurrencyCode = "gEO";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new VR_RateOrigin();
		//Required fields
		subject.TransactionSetPurposeCode = "vp";
		subject.TariffNumber = "P";
		subject.StandardCarrierAlphaCode = "gu";
		subject.IdentificationCode = "hk";
		subject.CurrencyCode = "gEO";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hk", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new VR_RateOrigin();
		//Required fields
		subject.TransactionSetPurposeCode = "vp";
		subject.TariffNumber = "P";
		subject.StandardCarrierAlphaCode = "gu";
		subject.IdentificationCodeQualifier = "O";
		subject.CurrencyCode = "gEO";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gEO", true)]
	public void Validation_RequiredCurrencyCode(string currencyCode, bool isValidExpected)
	{
		var subject = new VR_RateOrigin();
		//Required fields
		subject.TransactionSetPurposeCode = "vp";
		subject.TariffNumber = "P";
		subject.StandardCarrierAlphaCode = "gu";
		subject.IdentificationCodeQualifier = "O";
		subject.IdentificationCode = "hk";
		//Test Parameters
		subject.CurrencyCode = currencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
