using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class G76Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G76*4*71*1*lJ*7*h3*9*q*F*Q";

		var expected = new G76_TotalPurchaseOrder()
		{
			QuantityOrdered = 4,
			UnitOrBasisForMeasurementCode = "71",
			Weight = 1,
			UnitOrBasisForMeasurementCode2 = "lJ",
			Volume = 7,
			UnitOrBasisForMeasurementCode3 = "h3",
			EquivalentWeight = 9,
			Amount = "q",
			PriceBracketIdentifier = "F",
			PaymentMethodCode = "Q",
		};

		var actual = Map.MapObject<G76_TotalPurchaseOrder>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredQuantityOrdered(decimal quantityOrdered, bool isValidExpected)
	{
		var subject = new G76_TotalPurchaseOrder();
		subject.UnitOrBasisForMeasurementCode = "71";
		if (quantityOrdered > 0)
			subject.QuantityOrdered = quantityOrdered;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode2 = "lJ";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 7;
			subject.UnitOrBasisForMeasurementCode3 = "h3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("71", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G76_TotalPurchaseOrder();
		subject.QuantityOrdered = 4;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode2 = "lJ";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 7;
			subject.UnitOrBasisForMeasurementCode3 = "h3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "lJ", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "lJ", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G76_TotalPurchaseOrder();
		subject.QuantityOrdered = 4;
		subject.UnitOrBasisForMeasurementCode = "71";
		if (weight > 0)
			subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 7;
			subject.UnitOrBasisForMeasurementCode3 = "h3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "h3", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "h3", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new G76_TotalPurchaseOrder();
		subject.QuantityOrdered = 4;
		subject.UnitOrBasisForMeasurementCode = "71";
		if (volume > 0)
			subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode2 = "lJ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "lJ", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "lJ", true)]
	public void Validation_ARequiresBEquivalentWeight(decimal equivalentWeight, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G76_TotalPurchaseOrder();
		subject.QuantityOrdered = 4;
		subject.UnitOrBasisForMeasurementCode = "71";
		if (equivalentWeight > 0)
			subject.EquivalentWeight = equivalentWeight;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 1;
			subject.UnitOrBasisForMeasurementCode2 = "lJ";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 7;
			subject.UnitOrBasisForMeasurementCode3 = "h3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
