using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class CLPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CLP*m*V*3*5*9*Y*n*X*w*F*i*4*5";

		var expected = new CLP_ClaimLevelData()
		{
			ClaimSubmittersIdentifier = "m",
			ClaimStatusCode = "V",
			MonetaryAmount = 3,
			MonetaryAmount2 = 5,
			MonetaryAmount3 = 9,
			ClaimFilingIndicatorCode = "Y",
			ReferenceIdentification = "n",
			FacilityCodeValue = "X",
			ClaimFrequencyTypeCode = "w",
			PatientStatusCode = "F",
			DiagnosisRelatedGroupDRGCode = "i",
			Quantity = 4,
			Percent = 5,
		};

		var actual = Map.MapObject<CLP_ClaimLevelData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredClaimSubmittersIdentifier(string claimSubmittersIdentifier, bool isValidExpected)
	{
		var subject = new CLP_ClaimLevelData();
		//Required fields
		subject.ClaimStatusCode = "V";
		subject.MonetaryAmount = 3;
		subject.MonetaryAmount2 = 5;
		//Test Parameters
		subject.ClaimSubmittersIdentifier = claimSubmittersIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredClaimStatusCode(string claimStatusCode, bool isValidExpected)
	{
		var subject = new CLP_ClaimLevelData();
		//Required fields
		subject.ClaimSubmittersIdentifier = "m";
		subject.MonetaryAmount = 3;
		subject.MonetaryAmount2 = 5;
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
		subject.ClaimSubmittersIdentifier = "m";
		subject.ClaimStatusCode = "V";
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
		subject.ClaimSubmittersIdentifier = "m";
		subject.ClaimStatusCode = "V";
		subject.MonetaryAmount = 3;
		//Test Parameters
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
