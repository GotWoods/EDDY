using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G76Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G76*3*Hb*2*s8*6*6z*3*K*s";

		var expected = new G76_TotalPurchaseOrder()
		{
			QuantityOrdered = 3,
			UnitOfMeasurementCode = "Hb",
			Weight = 2,
			UnitOfMeasurementCode2 = "s8",
			Volume = 6,
			UnitOfMeasurementCode3 = "6z",
			EquivalentWeight = 3,
			TotalPurchaseOrderMonetaryAmount = "K",
			PriceBracketIdentifier = "s",
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
		subject.UnitOfMeasurementCode = "Hb";
		if (quantityOrdered > 0)
			subject.QuantityOrdered = quantityOrdered;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Hb", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new G76_TotalPurchaseOrder();
		subject.QuantityOrdered = 3;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
