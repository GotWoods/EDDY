using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class F01Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F01*bsBB2i*Y*l*dt*c*9WQ*5586*i*2v";

		var expected = new F01_IdentificationOfClaimClaimantOriginated()
		{
			Date = "bsBB2i",
			ReferenceNumber = "Y",
			Amount = "l",
			StandardCarrierAlphaCode = "dt",
			SupportingEvidenceCode = "c",
			CurrencyCode = "9WQ",
			ExchangeRate = 5586,
			IdentificationCodeQualifier = "i",
			IdentificationCode = "2v",
		};

		var actual = Map.MapObject<F01_IdentificationOfClaimClaimantOriginated>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bsBB2i", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F01_IdentificationOfClaimClaimantOriginated();
		subject.ReferenceNumber = "Y";
		subject.Amount = "l";
		subject.StandardCarrierAlphaCode = "dt";
		subject.SupportingEvidenceCode = "c";
		subject.Date = date;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "i";
			subject.IdentificationCode = "2v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new F01_IdentificationOfClaimClaimantOriginated();
		subject.Date = "bsBB2i";
		subject.Amount = "l";
		subject.StandardCarrierAlphaCode = "dt";
		subject.SupportingEvidenceCode = "c";
		subject.ReferenceNumber = referenceNumber;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "i";
			subject.IdentificationCode = "2v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("l", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new F01_IdentificationOfClaimClaimantOriginated();
		subject.Date = "bsBB2i";
		subject.ReferenceNumber = "Y";
		subject.StandardCarrierAlphaCode = "dt";
		subject.SupportingEvidenceCode = "c";
		subject.Amount = amount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "i";
			subject.IdentificationCode = "2v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dt", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new F01_IdentificationOfClaimClaimantOriginated();
		subject.Date = "bsBB2i";
		subject.ReferenceNumber = "Y";
		subject.Amount = "l";
		subject.SupportingEvidenceCode = "c";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "i";
			subject.IdentificationCode = "2v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredSupportingEvidenceCode(string supportingEvidenceCode, bool isValidExpected)
	{
		var subject = new F01_IdentificationOfClaimClaimantOriginated();
		subject.Date = "bsBB2i";
		subject.ReferenceNumber = "Y";
		subject.Amount = "l";
		subject.StandardCarrierAlphaCode = "dt";
		subject.SupportingEvidenceCode = supportingEvidenceCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCodeQualifier) || !string.IsNullOrEmpty(subject.IdentificationCode))
		{
			subject.IdentificationCodeQualifier = "i";
			subject.IdentificationCode = "2v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("i", "2v", true)]
	[InlineData("i", "", false)]
	[InlineData("", "2v", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new F01_IdentificationOfClaimClaimantOriginated();
		subject.Date = "bsBB2i";
		subject.ReferenceNumber = "Y";
		subject.Amount = "l";
		subject.StandardCarrierAlphaCode = "dt";
		subject.SupportingEvidenceCode = "c";
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
