using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class W25Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W25*e*5*C7OxkU*0YAM*SO*5*5*T*H*3*c*l";

		var expected = new W25_TransactionDetail()
		{
			InventoryTransactionTypeCode = "e",
			Quantity = 5,
			Date = "C7OxkU",
			Time = "0YAM",
			ReferenceNumberQualifier = "SO",
			ReferenceNumber = "5",
			Weight = 5,
			WeightQualifier = "T",
			WeightUnitCode = "H",
			Weight2 = 3,
			WeightQualifier2 = "c",
			WeightUnitCode2 = "l",
		};

		var actual = Map.MapObject<W25_TransactionDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredInventoryTransactionTypeCode(string inventoryTransactionTypeCode, bool isValidExpected)
	{
		var subject = new W25_TransactionDetail();
		//Required fields
		subject.Quantity = 5;
		subject.Date = "C7OxkU";
		//Test Parameters
		subject.InventoryTransactionTypeCode = inventoryTransactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new W25_TransactionDetail();
		//Required fields
		subject.InventoryTransactionTypeCode = "e";
		subject.Date = "C7OxkU";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C7OxkU", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new W25_TransactionDetail();
		//Required fields
		subject.InventoryTransactionTypeCode = "e";
		subject.Quantity = 5;
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
