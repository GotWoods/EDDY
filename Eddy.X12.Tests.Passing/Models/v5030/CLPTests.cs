using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class CLPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CLP*Y*t*8*3*7*2*a*c*G*M*P*9*5*O*6137";

		var expected = new CLP_ClaimLevelData()
		{
			ClaimSubmittersIdentifier = "Y",
			ClaimStatusCode = "t",
			MonetaryAmount = 8,
			MonetaryAmount2 = 3,
			MonetaryAmount3 = 7,
			ClaimFilingIndicatorCode = "2",
			ReferenceIdentification = "a",
			FacilityCodeValue = "c",
			ClaimFrequencyTypeCode = "G",
			PatientStatusCode = "M",
			DiagnosisRelatedGroupDRGCode = "P",
			Quantity = 9,
			PercentageAsDecimal = 5,
			YesNoConditionOrResponseCode = "O",
			ExchangeRate = 6137,
		};

		var actual = Map.MapObject<CLP_ClaimLevelData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredClaimSubmittersIdentifier(string claimSubmittersIdentifier, bool isValidExpected)
	{
		var subject = new CLP_ClaimLevelData();
		//Required fields
		subject.ClaimStatusCode = "t";
		subject.MonetaryAmount = 8;
		subject.MonetaryAmount2 = 3;
		//Test Parameters
		subject.ClaimSubmittersIdentifier = claimSubmittersIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredClaimStatusCode(string claimStatusCode, bool isValidExpected)
	{
		var subject = new CLP_ClaimLevelData();
		//Required fields
		subject.ClaimSubmittersIdentifier = "Y";
		subject.MonetaryAmount = 8;
		subject.MonetaryAmount2 = 3;
		//Test Parameters
		subject.ClaimStatusCode = claimStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new CLP_ClaimLevelData();
		//Required fields
		subject.ClaimSubmittersIdentifier = "Y";
		subject.ClaimStatusCode = "t";
		subject.MonetaryAmount2 = 3;
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredMonetaryAmount2(decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new CLP_ClaimLevelData();
		//Required fields
		subject.ClaimSubmittersIdentifier = "Y";
		subject.ClaimStatusCode = "t";
		subject.MonetaryAmount = 8;
		//Test Parameters
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
