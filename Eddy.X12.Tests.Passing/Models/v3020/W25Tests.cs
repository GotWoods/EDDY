using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class W25Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W25*M*2*1c1F5x*RnTs*qn*D*9*3*a*8*Q*8";

		var expected = new W25_TransactionDetail()
		{
			InventoryTransactionTypeCode = "M",
			Quantity = 2,
			Date = "1c1F5x",
			Time = "RnTs",
			ReferenceNumberQualifier = "qn",
			ReferenceNumber = "D",
			Weight = 9,
			WeightQualifier = "3",
			WeightUnitQualifier = "a",
			Weight2 = 8,
			WeightQualifier2 = "Q",
			WeightUnitQualifier2 = "8",
		};

		var actual = Map.MapObject<W25_TransactionDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredInventoryTransactionTypeCode(string inventoryTransactionTypeCode, bool isValidExpected)
	{
		var subject = new W25_TransactionDetail();
		//Required fields
		subject.Quantity = 2;
		subject.Date = "1c1F5x";
		//Test Parameters
		subject.InventoryTransactionTypeCode = inventoryTransactionTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new W25_TransactionDetail();
		//Required fields
		subject.InventoryTransactionTypeCode = "M";
		subject.Date = "1c1F5x";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1c1F5x", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new W25_TransactionDetail();
		//Required fields
		subject.InventoryTransactionTypeCode = "M";
		subject.Quantity = 2;
		//Test Parameters
		subject.Date = date;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
