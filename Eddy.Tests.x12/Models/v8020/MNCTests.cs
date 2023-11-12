using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.Tests.Models.v8020;

public class MNCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MNC*sA*8*J*FD*a*G*o*4*1*k*Q*vO*F*eW*0*91*f";

		var expected = new MNC_MortgageNoteCharacteristics()
		{
			CodeCategory = "sA",
			RealEstateLoanTypeCode = "8",
			LienPriorityCode = "J",
			LoanPaymentTypeCode = "FD",
			LoanRateTypeCode = "a",
			FrequencyCode = "G",
			InterestRateCalculationMethodCode = "o",
			Number = 4,
			Number2 = 1,
			PaymentMethodTypeCode = "k",
			InterestPaymentCode = "Q",
			ProductServiceIDQualifier = "vO",
			ProductServiceID = "F",
			ProductProcessCharacteristicCode = "eW",
			ProductDescriptionCode = "0",
			TypeOfRealEstateAssetCode = "91",
			RealEstateLoanSecurityInstrumentCode = "f",
		};

		var actual = Map.MapObject<MNC_MortgageNoteCharacteristics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(4, 1, true)]
	[InlineData(4, 0, false)]
	[InlineData(0, 1, false)]
	public void Validation_AllAreRequiredNumber(int number, int number2, bool isValidExpected)
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
			subject.ProductServiceIDQualifier = "vO";
			subject.ProductServiceID = "F";
		}
		if(!string.IsNullOrEmpty(subject.ProductProcessCharacteristicCode) || !string.IsNullOrEmpty(subject.ProductProcessCharacteristicCode) || !string.IsNullOrEmpty(subject.ProductDescriptionCode))
		{
			subject.ProductProcessCharacteristicCode = "eW";
			subject.ProductDescriptionCode = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("vO", "F", true)]
	[InlineData("vO", "", false)]
	[InlineData("", "F", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new MNC_MortgageNoteCharacteristics();
		//Required fields
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(subject.Number > 0 || subject.Number > 0 || subject.Number2 > 0)
		{
			subject.Number = 4;
			subject.Number2 = 1;
		}
		if(!string.IsNullOrEmpty(subject.ProductProcessCharacteristicCode) || !string.IsNullOrEmpty(subject.ProductProcessCharacteristicCode) || !string.IsNullOrEmpty(subject.ProductDescriptionCode))
		{
			subject.ProductProcessCharacteristicCode = "eW";
			subject.ProductDescriptionCode = "0";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("eW", "0", true)]
	[InlineData("eW", "", false)]
	[InlineData("", "0", false)]
	public void Validation_AllAreRequiredProductProcessCharacteristicCode(string productProcessCharacteristicCode, string productDescriptionCode, bool isValidExpected)
	{
		var subject = new MNC_MortgageNoteCharacteristics();
		//Required fields
		//Test Parameters
		subject.ProductProcessCharacteristicCode = productProcessCharacteristicCode;
		subject.ProductDescriptionCode = productDescriptionCode;
		//If one filled, all required
		if(subject.Number > 0 || subject.Number > 0 || subject.Number2 > 0)
		{
			subject.Number = 4;
			subject.Number2 = 1;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "vO";
			subject.ProductServiceID = "F";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
