using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5020;

namespace Eddy.x12.Tests.Models.v5020;

public class CLPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CLP*4*j*1*5*4*v*f*q*A*d*y*6*3*4*6939";

		var expected = new CLP_ClaimLevelData()
		{
			ClaimSubmittersIdentifier = "4",
			ClaimStatusCode = "j",
			MonetaryAmount = 1,
			MonetaryAmount2 = 5,
			MonetaryAmount3 = 4,
			ClaimFilingIndicatorCode = "v",
			ReferenceIdentification = "f",
			FacilityCodeValue = "q",
			ClaimFrequencyTypeCode = "A",
			PatientStatusCode = "d",
			DiagnosisRelatedGroupDRGCode = "y",
			Quantity = 6,
			PercentageAsDecimal = 3,
			YesNoConditionOrResponseCode = "4",
			ExchangeRate = 6939,
		};

		var actual = Map.MapObject<CLP_ClaimLevelData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredClaimSubmittersIdentifier(string claimSubmittersIdentifier, bool isValidExpected)
	{
		var subject = new CLP_ClaimLevelData();
		//Required fields
		subject.ClaimStatusCode = "j";
		subject.MonetaryAmount = 1;
		subject.MonetaryAmount2 = 5;
		//Test Parameters
		subject.ClaimSubmittersIdentifier = claimSubmittersIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredClaimStatusCode(string claimStatusCode, bool isValidExpected)
	{
		var subject = new CLP_ClaimLevelData();
		//Required fields
		subject.ClaimSubmittersIdentifier = "4";
		subject.MonetaryAmount = 1;
		subject.MonetaryAmount2 = 5;
		//Test Parameters
		subject.ClaimStatusCode = claimStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new CLP_ClaimLevelData();
		//Required fields
		subject.ClaimSubmittersIdentifier = "4";
		subject.ClaimStatusCode = "j";
		subject.MonetaryAmount2 = 5;
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredMonetaryAmount2(decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new CLP_ClaimLevelData();
		//Required fields
		subject.ClaimSubmittersIdentifier = "4";
		subject.ClaimStatusCode = "j";
		subject.MonetaryAmount = 1;
		//Test Parameters
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
