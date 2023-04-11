using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class F01Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F01*KnVwr2WL*T*I*vp*r*EOJ*5223*D*Pc";

		var expected = new F01_IdentificationOfClaimClaimantOriginated()
		{
			Date = "KnVwr2WL",
			ReferenceIdentification = "T",
			Amount = "I",
			StandardCarrierAlphaCode = "vp",
			SupportingEvidenceCode = "r",
			CurrencyCode = "EOJ",
			ExchangeRate = 5223,
			IdentificationCodeQualifier = "D",
			IdentificationCode = "Pc",
		};

		var actual = Map.MapObject<F01_IdentificationOfClaimClaimantOriginated>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("KnVwr2WL", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F01_IdentificationOfClaimClaimantOriginated();
		subject.ReferenceIdentification = "T";
		subject.Amount = "I";
		subject.StandardCarrierAlphaCode = "vp";
		subject.SupportingEvidenceCode = "r";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new F01_IdentificationOfClaimClaimantOriginated();
		subject.Date = "KnVwr2WL";
		subject.Amount = "I";
		subject.StandardCarrierAlphaCode = "vp";
		subject.SupportingEvidenceCode = "r";
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("I", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new F01_IdentificationOfClaimClaimantOriginated();
		subject.Date = "KnVwr2WL";
		subject.ReferenceIdentification = "T";
		subject.StandardCarrierAlphaCode = "vp";
		subject.SupportingEvidenceCode = "r";
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vp", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new F01_IdentificationOfClaimClaimantOriginated();
		subject.Date = "KnVwr2WL";
		subject.ReferenceIdentification = "T";
		subject.Amount = "I";
		subject.SupportingEvidenceCode = "r";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredSupportingEvidenceCode(string supportingEvidenceCode, bool isValidExpected)
	{
		var subject = new F01_IdentificationOfClaimClaimantOriginated();
		subject.Date = "KnVwr2WL";
		subject.ReferenceIdentification = "T";
		subject.Amount = "I";
		subject.StandardCarrierAlphaCode = "vp";
		subject.SupportingEvidenceCode = supportingEvidenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("D", "Pc", true)]
	[InlineData("", "Pc", false)]
	[InlineData("D", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new F01_IdentificationOfClaimClaimantOriginated();
		subject.Date = "KnVwr2WL";
		subject.ReferenceIdentification = "T";
		subject.Amount = "I";
		subject.StandardCarrierAlphaCode = "vp";
		subject.SupportingEvidenceCode = "r";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
