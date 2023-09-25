using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class W02Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W02*1*XE*rH1R0WmllCbW*BS*z*R*7*m*W*6*8*4*7*5*8*3*8*2*1";

		var expected = new W02_ItemSummaryInventory()
		{
			QuantityOnHand = 1,
			UnitOfMeasurementCode = "XE",
			UPCCaseCode = "rH1R0WmllCbW",
			ProductServiceIDQualifier = "BS",
			ProductServiceID = "z",
			WarehouseLotNumber = "R",
			Weight = 7,
			WeightQualifier = "m",
			WeightUnitQualifier = "W",
			Weight2 = 6,
			WeightQualifier2 = "8",
			WeightUnitQualifier2 = "4",
			QuantityCommitted = 7,
			QuantityAvailable = 5,
			QuantityInTransit = 8,
			QuantityDamaged = 3,
			QuantityOnHold = 8,
			QuantityBackordered = 2,
			QuantityDeferred = 1,
		};

		var actual = Map.MapObject<W02_ItemSummaryInventory>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredQuantityOnHand(decimal quantityOnHand, bool isValidExpected)
	{
		var subject = new W02_ItemSummaryInventory();
		//Required fields
		subject.UnitOfMeasurementCode = "XE";
		//Test Parameters
		if (quantityOnHand > 0) 
			subject.QuantityOnHand = quantityOnHand;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XE", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new W02_ItemSummaryInventory();
		//Required fields
		subject.QuantityOnHand = 1;
		//Test Parameters
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
