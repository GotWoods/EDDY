using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class MNCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MNC*38*x*M*T5*F*E*K*4*2*4*A*RF*a*Ky*z*SF*a";

		var expected = new MNC_MortgageNoteCharacteristics()
		{
			CodeCategory = "38",
			RealEstateLoanTypeCode = "x",
			LienPriorityCode = "M",
			LoanPaymentTypeCode = "T5",
			LoanRateTypeCode = "F",
			FrequencyCode = "E",
			InterestRateCalculationMethodCode = "K",
			Number = 4,
			Number2 = 2,
			PaymentMethodCode = "4",
			InterestPaymentCode = "A",
			ProductServiceIDQualifier = "RF",
			ProductServiceID = "a",
			ProductProcessCharacteristicCode = "Ky",
			ProductDescriptionCode = "z",
			TypeOfRealEstateAssetCode = "SF",
			RealEstateLoanSecurityInstrumentCode = "a",
		};

		var actual = Map.MapObject<MNC_MortgageNoteCharacteristics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(4, 2, true)]
	[InlineData(4, 0, false)]
	[InlineData(0, 2, false)]
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
			subject.ProductServiceIDQualifier = "RF";
			subject.ProductServiceID = "a";
		}
		if(!string.IsNullOrEmpty(subject.ProductProcessCharacteristicCode) || !string.IsNullOrEmpty(subject.ProductProcessCharacteristicCode) || !string.IsNullOrEmpty(subject.ProductDescriptionCode))
		{
			subject.ProductProcessCharacteristicCode = "Ky";
			subject.ProductDescriptionCode = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("RF", "a", true)]
	[InlineData("RF", "", false)]
	[InlineData("", "a", false)]
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
			subject.ProductProcessCharacteristicCode = "Ky";
			subject.ProductDescriptionCode = "z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ky", "z", true)]
	[InlineData("Ky", "", false)]
	[InlineData("", "z", false)]
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
			subject.ProductServiceIDQualifier = "RF";
			subject.ProductServiceID = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
