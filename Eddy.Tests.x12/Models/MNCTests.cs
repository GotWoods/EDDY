using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class MNCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MNC*zr*Q*4*su*4*s*P*8*9*L*O*uU*P*Eb*Z*WW*j";

		var expected = new MNC_MortgageNoteCharacteristics()
		{
			CodeCategory = "zr",
			RealEstateLoanTypeCode = "Q",
			LienPriorityCode = "4",
			LoanPaymentTypeCode = "su",
			LoanRateTypeCode = "4",
			FrequencyCode = "s",
			InterestRateCalculationMethodCode = "P",
			Number = 8,
			Number2 = 9,
			PaymentMethodTypeCode = "L",
			InterestPaymentCode = "O",
			ProductServiceIDQualifier = "uU",
			ProductServiceID = "P",
			ProductProcessCharacteristicCode = "Eb",
			ProductDescriptionCode = "Z",
			TypeOfRealEstateAssetCode = "WW",
			RealEstateLoanSecurityInstrumentCode = "j",
		};

		var actual = Map.MapObject<MNC_MortgageNoteCharacteristics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0,0, true)]
	[InlineData(8, 9, true)]
	[InlineData(0, 9, false)]
	[InlineData(8, 0, false)]
	public void Validation_AllAreRequiredNumber(int number, int number2, bool isValidExpected)
	{
		var subject = new MNC_MortgageNoteCharacteristics();
		if (number > 0)
		subject.Number = number;
		if (number2 > 0)
		subject.Number2 = number2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("uU", "P", true)]
	[InlineData("", "P", false)]
	[InlineData("uU", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new MNC_MortgageNoteCharacteristics();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Eb", "Z", true)]
	[InlineData("", "Z", false)]
	[InlineData("Eb", "", false)]
	public void Validation_AllAreRequiredProductProcessCharacteristicCode(string productProcessCharacteristicCode, string productDescriptionCode, bool isValidExpected)
	{
		var subject = new MNC_MortgageNoteCharacteristics();
		subject.ProductProcessCharacteristicCode = productProcessCharacteristicCode;
		subject.ProductDescriptionCode = productDescriptionCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
