using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.Tests.Models.v7010;

public class CLPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CLP*j*Q*5*8*4*4*1*A*I*r**5*9*n*4443*U3";

		var expected = new CLP_ClaimLevelData()
		{
			ClaimSubmittersIdentifier = "j",
			ClaimStatusCode = "Q",
			MonetaryAmount = 5,
			MonetaryAmount2 = 8,
			MonetaryAmount3 = 4,
			ClaimFilingIndicatorCode = "4",
			ReferenceIdentification = "1",
			FacilityCodeValue = "A",
			ClaimFrequencyTypeCode = "I",
			PatientStatusCode = "r",
			HealthCareCodeInformation = null,
			Quantity = 5,
			PercentageAsDecimal = 9,
			YesNoConditionOrResponseCode = "n",
			ExchangeRate = 4443,
			SourceOfPaymentTypologyCode = "U3",
		};

		var actual = Map.MapObject<CLP_ClaimLevelData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredClaimSubmittersIdentifier(string claimSubmittersIdentifier, bool isValidExpected)
	{
		var subject = new CLP_ClaimLevelData();
		//Required fields
		subject.ClaimStatusCode = "Q";
		subject.MonetaryAmount = 5;
		subject.MonetaryAmount2 = 8;
		//Test Parameters
		subject.ClaimSubmittersIdentifier = claimSubmittersIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Q", true)]
	public void Validation_RequiredClaimStatusCode(string claimStatusCode, bool isValidExpected)
	{
		var subject = new CLP_ClaimLevelData();
		//Required fields
		subject.ClaimSubmittersIdentifier = "j";
		subject.MonetaryAmount = 5;
		subject.MonetaryAmount2 = 8;
		//Test Parameters
		subject.ClaimStatusCode = claimStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new CLP_ClaimLevelData();
		//Required fields
		subject.ClaimSubmittersIdentifier = "j";
		subject.ClaimStatusCode = "Q";
		subject.MonetaryAmount2 = 8;
		//Test Parameters
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
		//Required fields
		subject.ClaimSubmittersIdentifier = "j";
		subject.ClaimStatusCode = "Q";
		subject.MonetaryAmount = 5;
		//Test Parameters
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
