using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.Tests.Models.v4050;

public class G76Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G76*6*h7*6*Mo*4*8B*6*U*s*W";

		var expected = new G76_TotalPurchaseOrder()
		{
			Quantity = 6,
			UnitOrBasisForMeasurementCode = "h7",
			Weight = 6,
			UnitOrBasisForMeasurementCode2 = "Mo",
			Volume = 4,
			UnitOrBasisForMeasurementCode3 = "8B",
			OrderSizingFactor = 6,
			Amount = "U",
			PriceBracketIdentifier = "s",
			PaymentMethodTypeCode = "W",
		};

		var actual = Map.MapObject<G76_TotalPurchaseOrder>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new G76_TotalPurchaseOrder();
		subject.UnitOrBasisForMeasurementCode = "h7";
		if (quantity > 0)
			subject.Quantity = quantity;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 6;
			subject.UnitOrBasisForMeasurementCode2 = "Mo";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 4;
			subject.UnitOrBasisForMeasurementCode3 = "8B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h7", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G76_TotalPurchaseOrder();
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 6;
			subject.UnitOrBasisForMeasurementCode2 = "Mo";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 4;
			subject.UnitOrBasisForMeasurementCode3 = "8B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "Mo", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "Mo", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G76_TotalPurchaseOrder();
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "h7";
		if (weight > 0)
			subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 4;
			subject.UnitOrBasisForMeasurementCode3 = "8B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "8B", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "8B", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new G76_TotalPurchaseOrder();
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "h7";
		if (volume > 0)
			subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 6;
			subject.UnitOrBasisForMeasurementCode2 = "Mo";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "Mo", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "Mo", true)]
	public void Validation_ARequiresBOrderSizingFactor(decimal orderSizingFactor, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G76_TotalPurchaseOrder();
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "h7";
		if (orderSizingFactor > 0)
			subject.OrderSizingFactor = orderSizingFactor;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 6;
			subject.UnitOrBasisForMeasurementCode2 = "Mo";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 4;
			subject.UnitOrBasisForMeasurementCode3 = "8B";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
