using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6050;

namespace Eddy.x12.Tests.Models.v6050;

public class CLPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CLP*0*y*4*1*6*M*W*w*N*q**5*6*r*1636";

		var expected = new CLP_ClaimLevelData()
		{
			ClaimSubmittersIdentifier = "0",
			ClaimStatusCode = "y",
			MonetaryAmount = 4,
			MonetaryAmount2 = 1,
			MonetaryAmount3 = 6,
			ClaimFilingIndicatorCode = "M",
			ReferenceIdentification = "W",
			FacilityCodeValue = "w",
			ClaimFrequencyTypeCode = "N",
			PatientStatusCode = "q",
			HealthCareCodeInformation = null,
			Quantity = 5,
			PercentageAsDecimal = 6,
			YesNoConditionOrResponseCode = "r",
			ExchangeRate = 1636,
		};

		var actual = Map.MapObject<CLP_ClaimLevelData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredClaimSubmittersIdentifier(string claimSubmittersIdentifier, bool isValidExpected)
	{
		var subject = new CLP_ClaimLevelData();
		//Required fields
		subject.ClaimStatusCode = "y";
		subject.MonetaryAmount = 4;
		subject.MonetaryAmount2 = 1;
		//Test Parameters
		subject.ClaimSubmittersIdentifier = claimSubmittersIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredClaimStatusCode(string claimStatusCode, bool isValidExpected)
	{
		var subject = new CLP_ClaimLevelData();
		//Required fields
		subject.ClaimSubmittersIdentifier = "0";
		subject.MonetaryAmount = 4;
		subject.MonetaryAmount2 = 1;
		//Test Parameters
		subject.ClaimStatusCode = claimStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new CLP_ClaimLevelData();
		//Required fields
		subject.ClaimSubmittersIdentifier = "0";
		subject.ClaimStatusCode = "y";
		subject.MonetaryAmount2 = 1;
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredMonetaryAmount2(decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new CLP_ClaimLevelData();
		//Required fields
		subject.ClaimSubmittersIdentifier = "0";
		subject.ClaimStatusCode = "y";
		subject.MonetaryAmount = 4;
		//Test Parameters
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
