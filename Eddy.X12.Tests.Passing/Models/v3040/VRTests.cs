using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class VRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "VR*lH*w*59*S*dO*VCn*X*1*LVgn";

		var expected = new VR_RateOrigin()
		{
			TransactionSetPurposeCode = "lH",
			TariffNumber = "w",
			StandardCarrierAlphaCode = "59",
			IdentificationCodeQualifier = "S",
			IdentificationCode = "dO",
			CurrencyCode = "VCn",
			TariffAgencyCode = "X",
			TariffSupplementIdentifier = "1",
			ExParte = "LVgn",
		};

		var actual = Map.MapObject<VR_RateOrigin>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("lH", true)]
	public void Validation_RequiredTransactionSetPurposeCode(string transactionSetPurposeCode, bool isValidExpected)
	{
		var subject = new VR_RateOrigin();
		//Required fields
		subject.TariffNumber = "w";
		subject.StandardCarrierAlphaCode = "59";
		subject.IdentificationCodeQualifier = "S";
		subject.IdentificationCode = "dO";
		subject.CurrencyCode = "VCn";
		//Test Parameters
		subject.TransactionSetPurposeCode = transactionSetPurposeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredTariffNumber(string tariffNumber, bool isValidExpected)
	{
		var subject = new VR_RateOrigin();
		//Required fields
		subject.TransactionSetPurposeCode = "lH";
		subject.StandardCarrierAlphaCode = "59";
		subject.IdentificationCodeQualifier = "S";
		subject.IdentificationCode = "dO";
		subject.CurrencyCode = "VCn";
		//Test Parameters
		subject.TariffNumber = tariffNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("59", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new VR_RateOrigin();
		//Required fields
		subject.TransactionSetPurposeCode = "lH";
		subject.TariffNumber = "w";
		subject.IdentificationCodeQualifier = "S";
		subject.IdentificationCode = "dO";
		subject.CurrencyCode = "VCn";
		//Test Parameters
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("S", true)]
	public void Validation_RequiredIdentificationCodeQualifier(string identificationCodeQualifier, bool isValidExpected)
	{
		var subject = new VR_RateOrigin();
		//Required fields
		subject.TransactionSetPurposeCode = "lH";
		subject.TariffNumber = "w";
		subject.StandardCarrierAlphaCode = "59";
		subject.IdentificationCode = "dO";
		subject.CurrencyCode = "VCn";
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dO", true)]
	public void Validation_RequiredIdentificationCode(string identificationCode, bool isValidExpected)
	{
		var subject = new VR_RateOrigin();
		//Required fields
		subject.TransactionSetPurposeCode = "lH";
		subject.TariffNumber = "w";
		subject.StandardCarrierAlphaCode = "59";
		subject.IdentificationCodeQualifier = "S";
		subject.CurrencyCode = "VCn";
		//Test Parameters
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VCn", true)]
	public void Validation_RequiredCurrencyCode(string currencyCode, bool isValidExpected)
	{
		var subject = new VR_RateOrigin();
		//Required fields
		subject.TransactionSetPurposeCode = "lH";
		subject.TariffNumber = "w";
		subject.StandardCarrierAlphaCode = "59";
		subject.IdentificationCodeQualifier = "S";
		subject.IdentificationCode = "dO";
		//Test Parameters
		subject.CurrencyCode = currencyCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
