using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class W76Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W76*9*4*P5*4*CB*5";

		var expected = new W76_TotalShippingOrder()
		{
			Quantity = 9,
			Weight = 4,
			UnitOrBasisForMeasurementCode = "P5",
			Volume = 4,
			UnitOrBasisForMeasurementCode2 = "CB",
			OrderSizingFactor = 5,
		};

		var actual = Map.MapObject<W76_TotalShippingOrder>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new W76_TotalShippingOrder();
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(4, "P5", true)]
	[InlineData(0, "P5", false)]
	[InlineData(4, "", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new W76_TotalShippingOrder();
		subject.Quantity = 9;
		if (weight > 0)
		subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(4, "CB", true)]
	[InlineData(0, "CB", false)]
	[InlineData(4, "", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new W76_TotalShippingOrder();
		subject.Quantity = 9;
		if (volume > 0)
		subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(0, "P5", true)]
	[InlineData(5, "", false)]
	public void Validation_ARequiresBOrderSizingFactor(decimal orderSizingFactor, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new W76_TotalShippingOrder();
		subject.Quantity = 9;
		if (orderSizingFactor > 0)
		subject.OrderSizingFactor = orderSizingFactor;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
