using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class MNCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MNC*Ta*h*L*K8*D*r*z*9*1*k*C*fn*7*dy*Q*tH*b";

		var expected = new MNC_MortgageNoteCharacteristics()
		{
			CodeCategory = "Ta",
			RealEstateLoanTypeCode = "h",
			LienPriorityCode = "L",
			LoanPaymentTypeCode = "K8",
			LoanRateTypeCode = "D",
			FrequencyCode = "r",
			InterestRateCalculationMethodCode = "z",
			Number = 9,
			Number2 = 1,
			PaymentMethodTypeCode = "k",
			InterestPaymentCode = "C",
			ProductServiceIDQualifier = "fn",
			ProductServiceID = "7",
			ProductProcessCharacteristicCode = "dy",
			ProductDescriptionCode = "Q",
			TypeOfRealEstateAssetCode = "tH",
			RealEstateLoanSecurityInstrumentCode = "b",
		};

		var actual = Map.MapObject<MNC_MortgageNoteCharacteristics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(9, 1, true)]
	[InlineData(9, 0, false)]
	[InlineData(0, 1, false)]
	public void Validation_AllAreRequiredNumber2(int number, int number2, bool isValidExpected)
	{
		var subject = new MNC_MortgageNoteCharacteristics();
		//Required fields
		//Test Parameters
		if (number > 0) 
			subject.Number = number;
		if (number2 > 0) 
			subject.Number2 = number2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "fn";
			subject.ProductServiceID = "7";
		}
		if(!string.IsNullOrEmpty(subject.ProductProcessCharacteristicCode) || !string.IsNullOrEmpty(subject.ProductProcessCharacteristicCode) || !string.IsNullOrEmpty(subject.ProductDescriptionCode))
		{
			subject.ProductProcessCharacteristicCode = "dy";
			subject.ProductDescriptionCode = "Q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("fn", "7", true)]
	[InlineData("fn", "", false)]
	[InlineData("", "7", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new MNC_MortgageNoteCharacteristics();
		//Required fields
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductProcessCharacteristicCode) || !string.IsNullOrEmpty(subject.ProductProcessCharacteristicCode) || !string.IsNullOrEmpty(subject.ProductDescriptionCode))
		{
			subject.ProductProcessCharacteristicCode = "dy";
			subject.ProductDescriptionCode = "Q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("dy", "Q", true)]
	[InlineData("dy", "", false)]
	[InlineData("", "Q", false)]
	public void Validation_AllAreRequiredProductProcessCharacteristicCode(string productProcessCharacteristicCode, string productDescriptionCode, bool isValidExpected)
	{
		var subject = new MNC_MortgageNoteCharacteristics();
		//Required fields
		//Test Parameters
		subject.ProductProcessCharacteristicCode = productProcessCharacteristicCode;
		subject.ProductDescriptionCode = productDescriptionCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "fn";
			subject.ProductServiceID = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
