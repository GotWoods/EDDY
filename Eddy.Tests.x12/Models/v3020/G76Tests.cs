using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G76Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G76*3*zP*2*TS*6*hn*9*1*1";

		var expected = new G76_TotalPurchaseOrder()
		{
			QuantityOrdered = 3,
			UnitOfMeasurementCode = "zP",
			Weight = 2,
			UnitOfMeasurementCode2 = "TS",
			Volume = 6,
			UnitOfMeasurementCode3 = "hn",
			EquivalentWeight = 9,
			TotalPurchaseOrderMonetaryAmount = "1",
			PriceBracketIdentifier = "1",
		};

		var actual = Map.MapObject<G76_TotalPurchaseOrder>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredQuantityOrdered(decimal quantityOrdered, bool isValidExpected)
	{
		var subject = new G76_TotalPurchaseOrder();
		subject.UnitOfMeasurementCode = "zP";
		if (quantityOrdered > 0)
			subject.QuantityOrdered = quantityOrdered;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Weight = 2;
			subject.UnitOfMeasurementCode2 = "TS";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Volume = 6;
			subject.UnitOfMeasurementCode3 = "hn";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zP", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new G76_TotalPurchaseOrder();
		subject.QuantityOrdered = 3;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Weight = 2;
			subject.UnitOfMeasurementCode2 = "TS";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Volume = 6;
			subject.UnitOfMeasurementCode3 = "hn";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "TS", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "TS", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new G76_TotalPurchaseOrder();
		subject.QuantityOrdered = 3;
		subject.UnitOfMeasurementCode = "zP";
		if (weight > 0)
			subject.Weight = weight;
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Volume = 6;
			subject.UnitOfMeasurementCode3 = "hn";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "hn", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "hn", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOfMeasurementCode3, bool isValidExpected)
	{
		var subject = new G76_TotalPurchaseOrder();
		subject.QuantityOrdered = 3;
		subject.UnitOfMeasurementCode = "zP";
		if (volume > 0)
			subject.Volume = volume;
		subject.UnitOfMeasurementCode3 = unitOfMeasurementCode3;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Weight = 2;
			subject.UnitOfMeasurementCode2 = "TS";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "TS", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "TS", true)]
	public void Validation_ARequiresBEquivalentWeight(decimal equivalentWeight, string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new G76_TotalPurchaseOrder();
		subject.QuantityOrdered = 3;
		subject.UnitOfMeasurementCode = "zP";
		if (equivalentWeight > 0)
			subject.EquivalentWeight = equivalentWeight;
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		//If one is filled, all are required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Weight = 2;
			subject.UnitOfMeasurementCode2 = "TS";
		}
		//If one is filled, all are required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode3))
		{
			subject.Volume = 6;
			subject.UnitOfMeasurementCode3 = "hn";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
