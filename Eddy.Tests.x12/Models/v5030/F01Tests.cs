using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class F01Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F01*T7vN5a5u*t*4*uo*l*ac6*2279*5*6j";

		var expected = new F01_IdentificationOfClaimClaimantOriginated()
		{
			Date = "T7vN5a5u",
			ReferenceIdentification = "t",
			Amount = "4",
			StandardCarrierAlphaCode = "uo",
			SupportingEvidenceCode = "l",
			CurrencyCode = "ac6",
			ExchangeRate = 2279,
			IdentificationCodeQualifier = "5",
			IdentificationCode = "6j",
		};

		var actual = Map.MapObject<F01_IdentificationOfClaimClaimantOriginated>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T7vN5a5u", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F01_IdentificationOfClaimClaimantOriginated();
		subject.ReferenceIdentification = "t";
		subject.Amount = "4";
		subject.StandardCarrierAlphaCode = "uo";
		subject.SupportingEvidenceCode = "l";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "5";
			subject.IdentificationCode = "6j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new F01_IdentificationOfClaimClaimantOriginated();
		subject.Date = "T7vN5a5u";
		subject.Amount = "4";
		subject.StandardCarrierAlphaCode = "uo";
		subject.SupportingEvidenceCode = "l";
		subject.ReferenceIdentification = referenceIdentification;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "5";
			subject.IdentificationCode = "6j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new F01_IdentificationOfClaimClaimantOriginated();
		subject.Date = "T7vN5a5u";
		subject.ReferenceIdentification = "t";
		subject.StandardCarrierAlphaCode = "uo";
		subject.SupportingEvidenceCode = "l";
		subject.Amount = amount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "5";
			subject.IdentificationCode = "6j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("uo", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new F01_IdentificationOfClaimClaimantOriginated();
		subject.Date = "T7vN5a5u";
		subject.ReferenceIdentification = "t";
		subject.Amount = "4";
		subject.SupportingEvidenceCode = "l";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "5";
			subject.IdentificationCode = "6j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredSupportingEvidenceCode(string supportingEvidenceCode, bool isValidExpected)
	{
		var subject = new F01_IdentificationOfClaimClaimantOriginated();
		subject.Date = "T7vN5a5u";
		subject.ReferenceIdentification = "t";
		subject.Amount = "4";
		subject.StandardCarrierAlphaCode = "uo";
		subject.SupportingEvidenceCode = supportingEvidenceCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "5";
			subject.IdentificationCode = "6j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("5", "6j", true)]
	[InlineData("5", "", false)]
	[InlineData("", "6j", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new F01_IdentificationOfClaimClaimantOriginated();
		subject.Date = "T7vN5a5u";
		subject.ReferenceIdentification = "t";
		subject.Amount = "4";
		subject.StandardCarrierAlphaCode = "uo";
		subject.SupportingEvidenceCode = "l";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
