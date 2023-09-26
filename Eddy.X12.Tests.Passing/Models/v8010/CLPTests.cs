using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.Tests.Models.v8010;

public class CLPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CLP*q*O*3*2*7*d*E*H*J*t**3*7*S*1566*mX";

		var expected = new CLP_ClaimLevelData()
		{
			ClaimSubmittersIdentifier = "q",
			ClaimStatusCode = "O",
			MonetaryAmount = 3,
			MonetaryAmount2 = 2,
			MonetaryAmount3 = 7,
			ClaimFilingIndicatorCode = "d",
			ReferenceIdentification = "E",
			FacilityCodeValue = "H",
			ClaimFrequencyTypeCode = "J",
			PatientDischargeStatus = "t",
			HealthCareCodeInformation = null,
			Quantity = 3,
			PercentageAsDecimal = 7,
			YesNoConditionOrResponseCode = "S",
			ExchangeRate = 1566,
			SourceOfPaymentTypologyCode = "mX",
		};

		var actual = Map.MapObject<CLP_ClaimLevelData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredClaimSubmittersIdentifier(string claimSubmittersIdentifier, bool isValidExpected)
	{
		var subject = new CLP_ClaimLevelData();
		//Required fields
		subject.ClaimStatusCode = "O";
		subject.MonetaryAmount = 3;
		subject.MonetaryAmount2 = 2;
		//Test Parameters
		subject.ClaimSubmittersIdentifier = claimSubmittersIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredClaimStatusCode(string claimStatusCode, bool isValidExpected)
	{
		var subject = new CLP_ClaimLevelData();
		//Required fields
		subject.ClaimSubmittersIdentifier = "q";
		subject.MonetaryAmount = 3;
		subject.MonetaryAmount2 = 2;
		//Test Parameters
		subject.ClaimStatusCode = claimStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new CLP_ClaimLevelData();
		//Required fields
		subject.ClaimSubmittersIdentifier = "q";
		subject.ClaimStatusCode = "O";
		subject.MonetaryAmount2 = 2;
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredMonetaryAmount2(decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new CLP_ClaimLevelData();
		//Required fields
		subject.ClaimSubmittersIdentifier = "q";
		subject.ClaimStatusCode = "O";
		subject.MonetaryAmount = 3;
		//Test Parameters
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
