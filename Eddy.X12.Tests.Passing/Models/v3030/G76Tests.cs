using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class G76Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G76*9*0B*4*O8*3*iz*5*U*e*u";

		var expected = new G76_TotalPurchaseOrder()
		{
			QuantityOrdered = 9,
			UnitOrBasisForMeasurementCode = "0B",
			Weight = 4,
			UnitOrBasisForMeasurementCode2 = "O8",
			Volume = 3,
			UnitOrBasisForMeasurementCode3 = "iz",
			EquivalentWeight = 5,
			TotalPurchaseOrderMonetaryAmount = "U",
			PriceBracketIdentifier = "e",
			PaymentMethodCode = "u",
		};

		var actual = Map.MapObject<G76_TotalPurchaseOrder>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredQuantityOrdered(decimal quantityOrdered, bool isValidExpected)
	{
		var subject = new G76_TotalPurchaseOrder();
		subject.UnitOrBasisForMeasurementCode = "0B";
		if (quantityOrdered > 0)
			subject.QuantityOrdered = quantityOrdered;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 4;
			subject.UnitOrBasisForMeasurementCode2 = "O8";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 3;
			subject.UnitOrBasisForMeasurementCode3 = "iz";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0B", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G76_TotalPurchaseOrder();
		subject.QuantityOrdered = 9;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 4;
			subject.UnitOrBasisForMeasurementCode2 = "O8";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 3;
			subject.UnitOrBasisForMeasurementCode3 = "iz";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "O8", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "O8", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G76_TotalPurchaseOrder();
		subject.QuantityOrdered = 9;
		subject.UnitOrBasisForMeasurementCode = "0B";
		if (weight > 0)
			subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 3;
			subject.UnitOrBasisForMeasurementCode3 = "iz";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "iz", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "iz", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new G76_TotalPurchaseOrder();
		subject.QuantityOrdered = 9;
		subject.UnitOrBasisForMeasurementCode = "0B";
		if (volume > 0)
			subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 4;
			subject.UnitOrBasisForMeasurementCode2 = "O8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "O8", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "O8", true)]
	public void Validation_ARequiresBEquivalentWeight(decimal equivalentWeight, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G76_TotalPurchaseOrder();
		subject.QuantityOrdered = 9;
		subject.UnitOrBasisForMeasurementCode = "0B";
		if (equivalentWeight > 0)
			subject.EquivalentWeight = equivalentWeight;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.Weight = 4;
			subject.UnitOrBasisForMeasurementCode2 = "O8";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.Volume = 3;
			subject.UnitOrBasisForMeasurementCode3 = "iz";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
