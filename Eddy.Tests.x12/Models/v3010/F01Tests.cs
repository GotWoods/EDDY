using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class F01Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "F01*7y2hXV*q*W*SQ*6*mZx*6626*m*Xa";

		var expected = new F01_IdentificationOfClaimClaimantOriginated()
		{
			Date = "7y2hXV",
			ReferenceNumber = "q",
			Amount = "W",
			StandardCarrierAlphaCode = "SQ",
			SupportingEvidenceCode = "6",
			CurrencyCode = "mZx",
			ExchangeRate = 6626,
			IdentificationCodeQualifier = "m",
			IdentificationCode = "Xa",
		};

		var actual = Map.MapObject<F01_IdentificationOfClaimClaimantOriginated>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("7y2hXV", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new F01_IdentificationOfClaimClaimantOriginated();
		subject.ReferenceNumber = "q";
		subject.Amount = "W";
		subject.StandardCarrierAlphaCode = "SQ";
		subject.SupportingEvidenceCode = "6";
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new F01_IdentificationOfClaimClaimantOriginated();
		subject.Date = "7y2hXV";
		subject.Amount = "W";
		subject.StandardCarrierAlphaCode = "SQ";
		subject.SupportingEvidenceCode = "6";
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredAmount(string amount, bool isValidExpected)
	{
		var subject = new F01_IdentificationOfClaimClaimantOriginated();
		subject.Date = "7y2hXV";
		subject.ReferenceNumber = "q";
		subject.StandardCarrierAlphaCode = "SQ";
		subject.SupportingEvidenceCode = "6";
		subject.Amount = amount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("SQ", true)]
	public void Validation_RequiredStandardCarrierAlphaCode(string standardCarrierAlphaCode, bool isValidExpected)
	{
		var subject = new F01_IdentificationOfClaimClaimantOriginated();
		subject.Date = "7y2hXV";
		subject.ReferenceNumber = "q";
		subject.Amount = "W";
		subject.SupportingEvidenceCode = "6";
		subject.StandardCarrierAlphaCode = standardCarrierAlphaCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredSupportingEvidenceCode(string supportingEvidenceCode, bool isValidExpected)
	{
		var subject = new F01_IdentificationOfClaimClaimantOriginated();
		subject.Date = "7y2hXV";
		subject.ReferenceNumber = "q";
		subject.Amount = "W";
		subject.StandardCarrierAlphaCode = "SQ";
		subject.SupportingEvidenceCode = supportingEvidenceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
