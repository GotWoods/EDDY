using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class G13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G13*D4*7*mc*6*7*P";

		var expected = new G13_StoreSizeAttributes()
		{
			ClassOfTradeCode = "D4",
			Quantity = 7,
			UnitOrBasisForMeasurementCode = "mc",
			Number = 6,
			MonetaryAmount = 7,
			AmountQualifierCode = "P",
		};

		var actual = Map.MapObject<G13_StoreSizeAttributes>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D4", true)]
	public void Validation_RequiredClassOfTradeCode(string classOfTradeCode, bool isValidExpected)
	{
		var subject = new G13_StoreSizeAttributes();
		//Required fields
		//Test Parameters
		subject.ClassOfTradeCode = classOfTradeCode;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 7;
			subject.UnitOrBasisForMeasurementCode = "mc";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "mc", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "mc", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G13_StoreSizeAttributes();
		//Required fields
		subject.ClassOfTradeCode = "D4";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("P", 7, true)]
	[InlineData("P", 0, false)]
	[InlineData("", 7, true)]
	public void Validation_ARequiresBAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new G13_StoreSizeAttributes();
		//Required fields
		subject.ClassOfTradeCode = "D4";
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 7;
			subject.UnitOrBasisForMeasurementCode = "mc";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
