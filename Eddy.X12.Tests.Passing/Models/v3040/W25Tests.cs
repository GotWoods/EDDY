using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class W25Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W25*x*3*MbfLNl*k237*Ti*4*8*0*D*7*c*e";

		var expected = new W25_TransactionDetail()
		{
			InventoryTransactionTypeCode = "x",
			Quantity = 3,
			Date = "MbfLNl",
			Time = "k237",
			ReferenceNumberQualifier = "Ti",
			ReferenceNumber = "4",
			Weight = 8,
			WeightQualifier = "0",
			WeightUnitCode = "D",
			Weight2 = 7,
			WeightQualifier2 = "c",
			WeightUnitCode2 = "e",
		};

		var actual = Map.MapObject<W25_TransactionDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredInventoryTransactionTypeCode(string inventoryTransactionTypeCode, bool isValidExpected)
	{
		var subject = new W25_TransactionDetail();
		//Required fields
		subject.Quantity = 3;
		subject.Date = "MbfLNl";
		//Test Parameters
		subject.InventoryTransactionTypeCode = inventoryTransactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new W25_TransactionDetail();
		//Required fields
		subject.InventoryTransactionTypeCode = "x";
		subject.Date = "MbfLNl";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MbfLNl", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new W25_TransactionDetail();
		//Required fields
		subject.InventoryTransactionTypeCode = "x";
		subject.Quantity = 3;
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
