using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G76Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G76*4*bJ*3*rE*3*l8*3*f*X*r";

		var expected = new G76_TotalPurchaseOrder()
		{
			Quantity = 4,
			UnitOrBasisForMeasurementCode = "bJ",
			Weight = 3,
			UnitOrBasisForMeasurementCode2 = "rE",
			Volume = 3,
			UnitOrBasisForMeasurementCode3 = "l8",
			OrderSizingFactor = 3,
			Amount = "f",
			PriceBracketIdentifier = "X",
			PaymentMethodTypeCode = "r",
		};

		var actual = Map.MapObject<G76_TotalPurchaseOrder>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new G76_TotalPurchaseOrder();
		subject.UnitOrBasisForMeasurementCode = "bJ";
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bJ", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G76_TotalPurchaseOrder();
		subject.Quantity = 4;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(3, "rE", true)]
	[InlineData(0, "rE", false)]
	[InlineData(3, "", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G76_TotalPurchaseOrder();
		subject.Quantity = 4;
		subject.UnitOrBasisForMeasurementCode = "bJ";
		if (weight > 0)
		subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(3, "l8", true)]
	[InlineData(0, "l8", false)]
	[InlineData(3, "", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new G76_TotalPurchaseOrder();
		subject.Quantity = 4;
		subject.UnitOrBasisForMeasurementCode = "bJ";
		if (volume > 0)
		subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "rE", true)]
	[InlineData(3, "", false)]
	public void Validation_ARequiresBOrderSizingFactor(decimal orderSizingFactor, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G76_TotalPurchaseOrder();
		subject.Quantity = 4;
		subject.UnitOrBasisForMeasurementCode = "bJ";
		if (orderSizingFactor > 0)
		subject.OrderSizingFactor = orderSizingFactor;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
