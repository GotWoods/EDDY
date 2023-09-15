using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class F01Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F01*OU8SbSgJ*x*X*G8*8*Gt9*7612*9*Dw";

		var expected = new F01_IdentificationOfClaimClaimantOriginated()
		{
			Date = "OU8SbSgJ",
			ReferenceIdentification = "x",
			Amount = "X",
			StandardCarrierAlphaCode = "G8",
			SupportingEvidenceCode = "8",
			CurrencyCode = "Gt9",
			ExchangeRate = 7612,
			IdentificationCodeQualifier = "9",
			IdentificationCode = "Dw",
		};

		var actual = Map.MapObject<F01_IdentificationOfClaimClaimantOriginated>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("OU8SbSgJ", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F01_IdentificationOfClaimClaimantOriginated();
		subject.ReferenceIdentification = "x";
		subject.Amount = "X";
		subject.StandardCarrierAlphaCode = "G8";
		subject.SupportingEvidenceCode = "8";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "9";
			subject.IdentificationCode = "Dw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new F01_IdentificationOfClaimClaimantOriginated();
		subject.Date = "OU8SbSgJ";
		subject.Amount = "X";
		subject.StandardCarrierAlphaCode = "G8";
		subject.SupportingEvidenceCode = "8";
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "9";
			subject.IdentificationCode = "Dw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("X", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new F01_IdentificationOfClaimClaimantOriginated();
		subject.Date = "OU8SbSgJ";
		subject.ReferenceIdentification = "x";
		subject.StandardCarrierAlphaCode = "G8";
		subject.SupportingEvidenceCode = "8";
		subject.Amount = amount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "9";
			subject.IdentificationCode = "Dw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G8", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new F01_IdentificationOfClaimClaimantOriginated();
		subject.Date = "OU8SbSgJ";
		subject.ReferenceIdentification = "x";
		subject.Amount = "X";
		subject.SupportingEvidenceCode = "8";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "9";
			subject.IdentificationCode = "Dw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8", true)]
	public void Validation_RequiredSupportingEvidenceCode(string supportingEvidenceCode, bool isValidExpected)
	{
		var subject = new F01_IdentificationOfClaimClaimantOriginated();
		subject.Date = "OU8SbSgJ";
		subject.ReferenceIdentification = "x";
		subject.Amount = "X";
		subject.StandardCarrierAlphaCode = "G8";
		subject.SupportingEvidenceCode = supportingEvidenceCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "9";
			subject.IdentificationCode = "Dw";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("9", "Dw", true)]
	[InlineData("9", "", false)]
	[InlineData("", "Dw", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new F01_IdentificationOfClaimClaimantOriginated();
		subject.Date = "OU8SbSgJ";
		subject.ReferenceIdentification = "x";
		subject.Amount = "X";
		subject.StandardCarrierAlphaCode = "G8";
		subject.SupportingEvidenceCode = "8";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
