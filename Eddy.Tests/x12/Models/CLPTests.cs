using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class CLPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CLP*d*Q*6*8*2*Z*V*A*V*F*AA>BB*8*6*X*3384*L2";

		var expected = new CLP_ClaimLevelData()
		{
			ClaimSubmittersIdentifier = "d",
			ClaimStatusCode = "Q",
			MonetaryAmount = 6,
			MonetaryAmount2 = 8,
			MonetaryAmount3 = 2,
			ClaimFilingIndicatorCode = "Z",
			ReferenceIdentification = "V",
			FacilityCodeValue = "A",
			ClaimFrequencyTypeCode = "V",
			PatientDischargeStatus = "F",
			HealthCareCodeInformation = new C022_HealthCareCodeInformation() { CodeListQualifierCode = "AA", IndustryCode = "BB"},
			Quantity = 8,
			PercentageAsDecimal = 6,
			YesNoConditionOrResponseCode = "X",
			ExchangeRate = 3384,
			SourceOfPaymentTypologyCode = "L2",
		};

		var actual = Map.MapObject<CLP_ClaimLevelData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
		
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredClaimSubmittersIdentifier(string claimSubmittersIdentifier, bool isValidExpected)
	{
		var subject = new CLP_ClaimLevelData();
		subject.ClaimStatusCode = "Q";
		subject.MonetaryAmount = 6;
		subject.MonetaryAmount2 = 8;
		subject.ClaimSubmittersIdentifier = claimSubmittersIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredClaimStatusCode(string claimStatusCode, bool isValidExpected)
	{
		var subject = new CLP_ClaimLevelData();
		subject.ClaimSubmittersIdentifier = "d";
		subject.MonetaryAmount = 6;
		subject.MonetaryAmount2 = 8;
		subject.ClaimStatusCode = claimStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new CLP_ClaimLevelData();
		subject.ClaimSubmittersIdentifier = "d";
		subject.ClaimStatusCode = "Q";
		subject.MonetaryAmount2 = 8;
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredMonetaryAmount2(decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new CLP_ClaimLevelData();
		subject.ClaimSubmittersIdentifier = "d";
		subject.ClaimStatusCode = "Q";
		subject.MonetaryAmount = 6;
		if (monetaryAmount2 > 0)
		subject.MonetaryAmount2 = monetaryAmount2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
