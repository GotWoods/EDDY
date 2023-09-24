using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class VRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VR*wy*4*LK*r*1i*WP5*q*U*ujPU";

		var expected = new VR_RateOrigin()
		{
			TransactionSetPurposeCode = "wy",
			TariffNumber = "4",
			StandardCarrierAlphaCode = "LK",
			IdentificationCodeQualifier = "r",
			IdentificationCode = "1i",
			CurrencyCode = "WP5",
			TariffAgencyCode = "q",
			TariffSupplementIdentifier = "U",
			ExParte = "ujPU",
		};

		var actual = Map.MapObject<VR_RateOrigin>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("wy", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new VR_RateOrigin();
		subject.TariffNumber = "4";
		subject.StandardCarrierAlphaCode = "LK";
		subject.IdentificationCodeQualifier = "r";
		subject.IdentificationCode = "1i";
		subject.CurrencyCode = "WP5";
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredTariffNumber(string tariffNumber, bool isValidExpected)
	{
		var subject = new VR_RateOrigin();
		subject.TransactionSetPurposeCode = "wy";
		subject.StandardCarrierAlphaCode = "LK";
		subject.IdentificationCodeQualifier = "r";
		subject.IdentificationCode = "1i";
		subject.CurrencyCode = "WP5";
		subject.TariffNumber = tariffNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("LK", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new VR_RateOrigin();
		subject.TransactionSetPurposeCode = "wy";
		subject.TariffNumber = "4";
		subject.IdentificationCodeQualifier = "r";
		subject.IdentificationCode = "1i";
		subject.CurrencyCode = "WP5";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new VR_RateOrigin();
		subject.TransactionSetPurposeCode = "wy";
		subject.TariffNumber = "4";
		subject.StandardCarrierAlphaCode = "LK";
		subject.IdentificationCode = "1i";
		subject.CurrencyCode = "WP5";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1i", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new VR_RateOrigin();
		subject.TransactionSetPurposeCode = "wy";
		subject.TariffNumber = "4";
		subject.StandardCarrierAlphaCode = "LK";
		subject.IdentificationCodeQualifier = "r";
		subject.CurrencyCode = "WP5";
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("WP5", true)]
	public void Validation_RequiredCurrencyCode(string currencyCode, bool isValidExpected)
	{
		var subject = new VR_RateOrigin();
		subject.TransactionSetPurposeCode = "wy";
		subject.TariffNumber = "4";
		subject.StandardCarrierAlphaCode = "LK";
		subject.IdentificationCodeQualifier = "r";
		subject.IdentificationCode = "1i";
		subject.CurrencyCode = currencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
