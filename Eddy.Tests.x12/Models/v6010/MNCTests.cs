using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class MNCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MNC*GV*V*p*L7*L*e*n*2*5*8*y*jQ*K*0v*0*3s*s";

		var expected = new MNC_MortgageNoteCharacteristics()
		{
			CodeCategory = "GV",
			RealEstateLoanTypeCode = "V",
			LienPriorityCode = "p",
			LoanPaymentTypeCode = "L7",
			LoanRateTypeCode = "L",
			FrequencyCode = "e",
			InterestRateCalculationMethodCode = "n",
			Number = 2,
			Number2 = 5,
			PaymentMethodTypeCode = "8",
			InterestPaymentCode = "y",
			ProductServiceIDQualifier = "jQ",
			ProductServiceID = "K",
			ProductProcessCharacteristicCode = "0v",
			ProductDescriptionCode = "0",
			TypeOfRealEstateAssetCode = "3s",
			RealEstateLoanSecurityInstrumentCode = "s",
		};

		var actual = Map.MapObject<MNC_MortgageNoteCharacteristics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(2, 5, true)]
	[InlineData(2, 0, false)]
	[InlineData(0, 5, false)]
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
			subject.ProductServiceIDQualifier = "jQ";
			subject.ProductServiceID = "K";
		}
		if(!string.IsNullOrEmpty(subject.ProductProcessCharacteristicCode) || !string.IsNullOrEmpty(subject.ProductProcessCharacteristicCode) || !string.IsNullOrEmpty(subject.ProductDescriptionCode))
		{
			subject.ProductProcessCharacteristicCode = "0v";
			subject.ProductDescriptionCode = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("jQ", "K", true)]
	[InlineData("jQ", "", false)]
	[InlineData("", "K", false)]
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
			subject.ProductProcessCharacteristicCode = "0v";
			subject.ProductDescriptionCode = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("0v", "0", true)]
	[InlineData("0v", "", false)]
	[InlineData("", "0", false)]
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
			subject.ProductServiceIDQualifier = "jQ";
			subject.ProductServiceID = "K";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
