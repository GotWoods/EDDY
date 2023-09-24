using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class W13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W13*9*36*8C*R*0O";

		var expected = new W13_ItemDetailException()
		{
			Quantity = 9,
			UnitOfMeasurementCode = "36",
			ReceivingConditionCode = "8C",
			WarehouseLotNumber = "R",
			DamageReasonCode = "0O",
		};

		var actual = Map.MapObject<W13_ItemDetailException>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new W13_ItemDetailException();
		//Required fields
		subject.UnitOfMeasurementCode = "36";
		subject.ReceivingConditionCode = "8C";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("36", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new W13_ItemDetailException();
		//Required fields
		subject.Quantity = 9;
		subject.ReceivingConditionCode = "8C";
		//Test Parameters
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8C", true)]
	public void Validation_RequiredReceivingConditionCode(string receivingConditionCode, bool isValidExpected)
	{
		var subject = new W13_ItemDetailException();
		//Required fields
		subject.Quantity = 9;
		subject.UnitOfMeasurementCode = "36";
		//Test Parameters
		subject.ReceivingConditionCode = receivingConditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
