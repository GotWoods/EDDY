using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class VRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VR*uP*E*ha*4*tl*zGt*x*p*YwER";

		var expected = new VR_RateOrigin()
		{
			TransactionSetPurposeCode = "uP",
			TariffNumber = "E",
			StandardCarrierAlphaCode = "ha",
			IdentificationCodeQualifier = "4",
			IdentificationCode = "tl",
			CurrencyCode = "zGt",
			TariffAgencyCode = "x",
			TariffSupplementIdentifier = "p",
			ExParte = "YwER",
		};

		var actual = Map.MapObject<VR_RateOrigin>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uP", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new VR_RateOrigin();
		//Required fields
		subject.TariffNumber = "E";
		subject.StandardCarrierAlphaCode = "ha";
		subject.IdentificationCodeQualifier = "4";
		subject.IdentificationCode = "tl";
		subject.CurrencyCode = "zGt";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E", true)]
	public void Validation_RequiredTariffNumber(string tariffNumber, bool isValidExpected)
	{
		var subject = new VR_RateOrigin();
		//Required fields
		subject.TransactionSetPurposeCode = "uP";
		subject.StandardCarrierAlphaCode = "ha";
		subject.IdentificationCodeQualifier = "4";
		subject.IdentificationCode = "tl";
		subject.CurrencyCode = "zGt";
		//Test Parameters
		subject.TariffNumber = tariffNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ha", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new VR_RateOrigin();
		//Required fields
		subject.TransactionSetPurposeCode = "uP";
		subject.TariffNumber = "E";
		subject.IdentificationCodeQualifier = "4";
		subject.IdentificationCode = "tl";
		subject.CurrencyCode = "zGt";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new VR_RateOrigin();
		//Required fields
		subject.TransactionSetPurposeCode = "uP";
		subject.TariffNumber = "E";
		subject.StandardCarrierAlphaCode = "ha";
		subject.IdentificationCode = "tl";
		subject.CurrencyCode = "zGt";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tl", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new VR_RateOrigin();
		//Required fields
		subject.TransactionSetPurposeCode = "uP";
		subject.TariffNumber = "E";
		subject.StandardCarrierAlphaCode = "ha";
		subject.IdentificationCodeQualifier = "4";
		subject.CurrencyCode = "zGt";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zGt", true)]
	public void Validation_RequiredCurrencyCode(string currencyCode, bool isValidExpected)
	{
		var subject = new VR_RateOrigin();
		//Required fields
		subject.TransactionSetPurposeCode = "uP";
		subject.TariffNumber = "E";
		subject.StandardCarrierAlphaCode = "ha";
		subject.IdentificationCodeQualifier = "4";
		subject.IdentificationCode = "tl";
		//Test Parameters
		subject.CurrencyCode = currencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
