using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class G13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G13*8O*2*ro*9*5*n";

		var expected = new G13_StoreSizeAttributes()
		{
			ClassOfTradeCode = "8O",
			Quantity = 2,
			UnitOrBasisForMeasurementCode = "ro",
			Number = 9,
			MonetaryAmount = 5,
			AmountQualifierCode = "n",
		};

		var actual = Map.MapObject<G13_StoreSizeAttributes>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8O", true)]
	public void Validation_RequiredClassOfTradeCode(string classOfTradeCode, bool isValidExpected)
	{
		var subject = new G13_StoreSizeAttributes();
		//Required fields
		//Test Parameters
		subject.ClassOfTradeCode = classOfTradeCode;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 2;
			subject.UnitOrBasisForMeasurementCode = "ro";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "ro", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "ro", false)]
	public void Validation_AllAreRequiredQuantity(decimal quantity, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G13_StoreSizeAttributes();
		//Required fields
		subject.ClassOfTradeCode = "8O";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("n", 5, true)]
	[InlineData("n", 0, false)]
	[InlineData("", 5, true)]
	public void Validation_ARequiresBAmountQualifierCode(string amountQualifierCode, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new G13_StoreSizeAttributes();
		//Required fields
		subject.ClassOfTradeCode = "8O";
		//Test Parameters
		subject.AmountQualifierCode = amountQualifierCode;
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(subject.Quantity > 0 || subject.Quantity > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.Quantity = 2;
			subject.UnitOrBasisForMeasurementCode = "ro";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
