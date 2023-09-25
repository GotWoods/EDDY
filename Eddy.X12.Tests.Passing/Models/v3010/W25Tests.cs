using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class W25Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W25*4*4*0G6oRR*zQR2*sl*U*5*U*l*3*Y*1";

		var expected = new W25_TransactionDetail()
		{
			InventoryTransactionTypeCode = "4",
			Quantity = 4,
			EventDate = "0G6oRR",
			EventTime = "zQR2",
			ReferenceNumberQualifier = "sl",
			ReferenceNumber = "U",
			Weight = 5,
			WeightQualifier = "U",
			WeightUnitQualifier = "l",
			Weight2 = 3,
			WeightQualifier2 = "Y",
			WeightUnitQualifier2 = "1",
		};

		var actual = Map.MapObject<W25_TransactionDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredInventoryTransactionTypeCode(string inventoryTransactionTypeCode, bool isValidExpected)
	{
		var subject = new W25_TransactionDetail();
		//Required fields
		subject.Quantity = 4;
		subject.EventDate = "0G6oRR";
		//Test Parameters
		subject.InventoryTransactionTypeCode = inventoryTransactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new W25_TransactionDetail();
		//Required fields
		subject.InventoryTransactionTypeCode = "4";
		subject.EventDate = "0G6oRR";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0G6oRR", true)]
	public void Validation_RequiredEventDate(string eventDate, bool isValidExpected)
	{
		var subject = new W25_TransactionDetail();
		//Required fields
		subject.InventoryTransactionTypeCode = "4";
		subject.Quantity = 4;
		//Test Parameters
		subject.EventDate = eventDate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
