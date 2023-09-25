using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class W76Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W76*6*4*Az*6*cd*6";

		var expected = new W76_TotalShippingOrder()
		{
			QuantityOrdered = 6,
			Weight = 4,
			UnitOfMeasurementCode = "Az",
			Volume = 6,
			UnitOfMeasurementCode2 = "cd",
			EquivalentWeight = 6,
		};

		var actual = Map.MapObject<W76_TotalShippingOrder>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantityOrdered(decimal quantityOrdered, bool isValidExpected)
	{
		var subject = new W76_TotalShippingOrder();
		//Required fields
		//Test Parameters
		if (quantityOrdered > 0) 
			subject.QuantityOrdered = quantityOrdered;
		//If one filled, all required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.Weight = 4;
			subject.UnitOfMeasurementCode = "Az";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Volume = 6;
			subject.UnitOfMeasurementCode2 = "cd";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "Az", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "Az", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new W76_TotalShippingOrder();
		//Required fields
		subject.QuantityOrdered = 6;
		//Test Parameters
		if (weight > 0) 
			subject.Weight = weight;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//If one filled, all required
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Volume = 6;
			subject.UnitOfMeasurementCode2 = "cd";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "cd", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "cd", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new W76_TotalShippingOrder();
		//Required fields
		subject.QuantityOrdered = 6;
		//Test Parameters
		if (volume > 0) 
			subject.Volume = volume;
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		//If one filled, all required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.Weight = 4;
			subject.UnitOfMeasurementCode = "Az";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "Az", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "Az", true)]
	public void Validation_ARequiresBEquivalentWeight(decimal equivalentWeight, string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new W76_TotalShippingOrder();
		//Required fields
		subject.QuantityOrdered = 6;
		//Test Parameters
		if (equivalentWeight > 0) 
			subject.EquivalentWeight = equivalentWeight;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//If one filled, all required
		if(subject.Weight > 0 || subject.Weight > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode))
		{
			subject.Weight = 4;
			subject.UnitOfMeasurementCode = "Az";
		}
		if(subject.Volume > 0 || subject.Volume > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.Volume = 6;
			subject.UnitOfMeasurementCode2 = "cd";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
