using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class MNCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MNC*8S*T*8*bX*L*B*6*6*9*X*E*c5*g*cm*h*5Q*I";

		var expected = new MNC_MortgageNoteCharacteristics()
		{
			CodeCategory = "8S",
			RealEstateLoanTypeCode = "T",
			LienPriorityCode = "8",
			LoanPaymentTypeCode = "bX",
			LoanRateTypeCode = "L",
			FrequencyCode = "B",
			InterestRateCalculationMethodCode = "6",
			Number = 6,
			Number2 = 9,
			PaymentMethodCode = "X",
			InterestPaymentCode = "E",
			ProductServiceIDQualifier = "c5",
			ProductServiceID = "g",
			ProductProcessCharacteristicCode = "cm",
			ProductDescriptionCode = "h",
			TypeOfRealEstateAssetCode = "5Q",
			RealEstateLoanSecurityInstrumentCode = "I",
		};

		var actual = Map.MapObject<MNC_MortgageNoteCharacteristics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(6, 9, true)]
	[InlineData(6, 0, false)]
	[InlineData(0, 9, false)]
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
			subject.ProductServiceIDQualifier = "c5";
			subject.ProductServiceID = "g";
		}
		if(!string.IsNullOrEmpty(subject.ProductProcessCharacteristicCode) || !string.IsNullOrEmpty(subject.ProductProcessCharacteristicCode) || !string.IsNullOrEmpty(subject.ProductDescriptionCode))
		{
			subject.ProductProcessCharacteristicCode = "cm";
			subject.ProductDescriptionCode = "h";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("c5", "g", true)]
	[InlineData("c5", "", false)]
	[InlineData("", "g", false)]
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
			subject.ProductProcessCharacteristicCode = "cm";
			subject.ProductDescriptionCode = "h";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("cm", "h", true)]
	[InlineData("cm", "", false)]
	[InlineData("", "h", false)]
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
			subject.ProductServiceIDQualifier = "c5";
			subject.ProductServiceID = "g";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
