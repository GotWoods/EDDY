using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class W13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W13*6*Ql*MQ*7*2l";

		var expected = new W13_ItemDetailException()
		{
			Quantity = 6,
			UnitOfMeasurementCode = "Ql",
			ReceivingConditionCode = "MQ",
			WarehouseLotNumber = "7",
			DamageReasonCode = "2l",
		};

		var actual = Map.MapObject<W13_ItemDetailException>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new W13_ItemDetailException();
		//Required fields
		subject.UnitOfMeasurementCode = "Ql";
		subject.ReceivingConditionCode = "MQ";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ql", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new W13_ItemDetailException();
		//Required fields
		subject.Quantity = 6;
		subject.ReceivingConditionCode = "MQ";
		//Test Parameters
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MQ", true)]
	public void Validation_RequiredReceivingConditionCode(string receivingConditionCode, bool isValidExpected)
	{
		var subject = new W13_ItemDetailException();
		//Required fields
		subject.Quantity = 6;
		subject.UnitOfMeasurementCode = "Ql";
		//Test Parameters
		subject.ReceivingConditionCode = receivingConditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
