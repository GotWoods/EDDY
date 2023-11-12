using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class W13Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W13*8*zQ*jj*u*ga";

		var expected = new W13_ItemDetailException()
		{
			Quantity = 8,
			UnitOrBasisForMeasurementCode = "zQ",
			ReceivingConditionCode = "jj",
			WarehouseLotNumber = "u",
			DamageReasonCode = "ga",
		};

		var actual = Map.MapObject<W13_ItemDetailException>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new W13_ItemDetailException();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "zQ";
		subject.ReceivingConditionCode = "jj";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("zQ", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new W13_ItemDetailException();
		//Required fields
		subject.Quantity = 8;
		subject.ReceivingConditionCode = "jj";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jj", true)]
	public void Validation_RequiredReceivingConditionCode(string receivingConditionCode, bool isValidExpected)
	{
		var subject = new W13_ItemDetailException();
		//Required fields
		subject.Quantity = 8;
		subject.UnitOrBasisForMeasurementCode = "zQ";
		//Test Parameters
		subject.ReceivingConditionCode = receivingConditionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
