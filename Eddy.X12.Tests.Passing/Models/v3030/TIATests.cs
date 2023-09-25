using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class TIATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TIA*5*8*Z*2*Zt*9*7";

		var expected = new TIA_TaxInformationAndAmount()
		{
			TaxInformationIdentificationNumber = "5",
			MonetaryAmount = 8,
			FixedFormatInformation = "Z",
			Quantity = 2,
			UnitOrBasisForMeasurementCode = "Zt",
			Percent = 9,
			MonetaryAmount2 = 7,
		};

		var actual = Map.MapObject<TIA_TaxInformationAndAmount>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredTaxInformationIdentificationNumber(string taxInformationIdentificationNumber, bool isValidExpected)
	{
		var subject = new TIA_TaxInformationAndAmount();
		//Required fields
		//Test Parameters
		subject.TaxInformationIdentificationNumber = taxInformationIdentificationNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "Zt", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "Zt", true)]
	public void Validation_ARequiresBQuantity(decimal quantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new TIA_TaxInformationAndAmount();
		//Required fields
		subject.TaxInformationIdentificationNumber = "5";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData(0, 0, true)]
	[InlineData(9, 7, false)]
	[InlineData(9, 0, true)]
	[InlineData(0, 7, true)]
	public void Validation_OnlyOneOfPercent(decimal percent, decimal monetaryAmount2, bool isValidExpected)
	{
		var subject = new TIA_TaxInformationAndAmount();
		//Required fields
		subject.TaxInformationIdentificationNumber = "5";
		//Test Parameters
		if (percent > 0) 
			subject.Percent = percent;
		if (monetaryAmount2 > 0) 
			subject.MonetaryAmount2 = monetaryAmount2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.OnlyOneOf);
	}

}
