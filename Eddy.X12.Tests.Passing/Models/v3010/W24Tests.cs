using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class W24Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W24*f3*B*Tr*y*3*5*9*2*4*8*1*4*2";

		var expected = new W24_WarehouseQuantities()
		{
			UnitOfMeasurementCode = "f3",
			WarehouseLotNumber = "B",
			ReferenceNumberQualifier = "Tr",
			ReferenceNumber = "y",
			BeginningBalanceQuantity = 3,
			QuantityAvailable = 5,
			EndingBalanceQuantity = 9,
			QuantityReceived = 2,
			NumberOfUnitsShipped = 4,
			QuantityDamagedOnHold = 8,
			QuantityAdjustment = 1,
			QuantityCommitted = 4,
			QuantityInTransit = 2,
		};

		var actual = Map.MapObject<W24_WarehouseQuantities>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f3", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new W24_WarehouseQuantities();
		//Required fields
		subject.WarehouseLotNumber = "B";
		subject.ReferenceNumberQualifier = "Tr";
		subject.ReferenceNumber = "y";
		subject.BeginningBalanceQuantity = 3;
		subject.QuantityAvailable = 5;
		subject.EndingBalanceQuantity = 9;
		//Test Parameters
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("B", true)]
	public void Validation_RequiredWarehouseLotNumber(string warehouseLotNumber, bool isValidExpected)
	{
		var subject = new W24_WarehouseQuantities();
		//Required fields
		subject.UnitOfMeasurementCode = "f3";
		subject.ReferenceNumberQualifier = "Tr";
		subject.ReferenceNumber = "y";
		subject.BeginningBalanceQuantity = 3;
		subject.QuantityAvailable = 5;
		subject.EndingBalanceQuantity = 9;
		//Test Parameters
		subject.WarehouseLotNumber = warehouseLotNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Tr", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new W24_WarehouseQuantities();
		//Required fields
		subject.UnitOfMeasurementCode = "f3";
		subject.WarehouseLotNumber = "B";
		subject.ReferenceNumber = "y";
		subject.BeginningBalanceQuantity = 3;
		subject.QuantityAvailable = 5;
		subject.EndingBalanceQuantity = 9;
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new W24_WarehouseQuantities();
		//Required fields
		subject.UnitOfMeasurementCode = "f3";
		subject.WarehouseLotNumber = "B";
		subject.ReferenceNumberQualifier = "Tr";
		subject.BeginningBalanceQuantity = 3;
		subject.QuantityAvailable = 5;
		subject.EndingBalanceQuantity = 9;
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredBeginningBalanceQuantity(decimal beginningBalanceQuantity, bool isValidExpected)
	{
		var subject = new W24_WarehouseQuantities();
		//Required fields
		subject.UnitOfMeasurementCode = "f3";
		subject.WarehouseLotNumber = "B";
		subject.ReferenceNumberQualifier = "Tr";
		subject.ReferenceNumber = "y";
		subject.QuantityAvailable = 5;
		subject.EndingBalanceQuantity = 9;
		//Test Parameters
		if (beginningBalanceQuantity > 0) 
			subject.BeginningBalanceQuantity = beginningBalanceQuantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredQuantityAvailable(decimal quantityAvailable, bool isValidExpected)
	{
		var subject = new W24_WarehouseQuantities();
		//Required fields
		subject.UnitOfMeasurementCode = "f3";
		subject.WarehouseLotNumber = "B";
		subject.ReferenceNumberQualifier = "Tr";
		subject.ReferenceNumber = "y";
		subject.BeginningBalanceQuantity = 3;
		subject.EndingBalanceQuantity = 9;
		//Test Parameters
		if (quantityAvailable > 0) 
			subject.QuantityAvailable = quantityAvailable;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredEndingBalanceQuantity(decimal endingBalanceQuantity, bool isValidExpected)
	{
		var subject = new W24_WarehouseQuantities();
		//Required fields
		subject.UnitOfMeasurementCode = "f3";
		subject.WarehouseLotNumber = "B";
		subject.ReferenceNumberQualifier = "Tr";
		subject.ReferenceNumber = "y";
		subject.BeginningBalanceQuantity = 3;
		subject.QuantityAvailable = 5;
		//Test Parameters
		if (endingBalanceQuantity > 0) 
			subject.EndingBalanceQuantity = endingBalanceQuantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
