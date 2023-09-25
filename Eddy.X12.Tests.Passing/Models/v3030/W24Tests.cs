using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class W24Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W24*eO*1*6i*r*8*7*5*9*5*6*2*5*9";

		var expected = new W24_WarehouseQuantities()
		{
			UnitOrBasisForMeasurementCode = "eO",
			WarehouseLotNumber = "1",
			ReferenceNumberQualifier = "6i",
			ReferenceNumber = "r",
			BeginningBalanceQuantity = 8,
			QuantityAvailable = 7,
			EndingBalanceQuantity = 5,
			QuantityReceived = 9,
			NumberOfUnitsShipped = 5,
			QuantityDamagedOnHold = 6,
			QuantityAdjustment = 2,
			QuantityCommitted = 5,
			QuantityInTransit = 9,
		};

		var actual = Map.MapObject<W24_WarehouseQuantities>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("eO", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new W24_WarehouseQuantities();
		//Required fields
		subject.WarehouseLotNumber = "1";
		subject.ReferenceNumberQualifier = "6i";
		subject.ReferenceNumber = "r";
		subject.BeginningBalanceQuantity = 8;
		subject.QuantityAvailable = 7;
		subject.EndingBalanceQuantity = 5;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("1", true)]
	public void Validation_RequiredWarehouseLotNumber(string warehouseLotNumber, bool isValidExpected)
	{
		var subject = new W24_WarehouseQuantities();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "eO";
		subject.ReferenceNumberQualifier = "6i";
		subject.ReferenceNumber = "r";
		subject.BeginningBalanceQuantity = 8;
		subject.QuantityAvailable = 7;
		subject.EndingBalanceQuantity = 5;
		//Test Parameters
		subject.WarehouseLotNumber = warehouseLotNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6i", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new W24_WarehouseQuantities();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "eO";
		subject.WarehouseLotNumber = "1";
		subject.ReferenceNumber = "r";
		subject.BeginningBalanceQuantity = 8;
		subject.QuantityAvailable = 7;
		subject.EndingBalanceQuantity = 5;
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new W24_WarehouseQuantities();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "eO";
		subject.WarehouseLotNumber = "1";
		subject.ReferenceNumberQualifier = "6i";
		subject.BeginningBalanceQuantity = 8;
		subject.QuantityAvailable = 7;
		subject.EndingBalanceQuantity = 5;
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredBeginningBalanceQuantity(decimal beginningBalanceQuantity, bool isValidExpected)
	{
		var subject = new W24_WarehouseQuantities();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "eO";
		subject.WarehouseLotNumber = "1";
		subject.ReferenceNumberQualifier = "6i";
		subject.ReferenceNumber = "r";
		subject.QuantityAvailable = 7;
		subject.EndingBalanceQuantity = 5;
		//Test Parameters
		if (beginningBalanceQuantity > 0) 
			subject.BeginningBalanceQuantity = beginningBalanceQuantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredQuantityAvailable(decimal quantityAvailable, bool isValidExpected)
	{
		var subject = new W24_WarehouseQuantities();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "eO";
		subject.WarehouseLotNumber = "1";
		subject.ReferenceNumberQualifier = "6i";
		subject.ReferenceNumber = "r";
		subject.BeginningBalanceQuantity = 8;
		subject.EndingBalanceQuantity = 5;
		//Test Parameters
		if (quantityAvailable > 0) 
			subject.QuantityAvailable = quantityAvailable;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredEndingBalanceQuantity(decimal endingBalanceQuantity, bool isValidExpected)
	{
		var subject = new W24_WarehouseQuantities();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "eO";
		subject.WarehouseLotNumber = "1";
		subject.ReferenceNumberQualifier = "6i";
		subject.ReferenceNumber = "r";
		subject.BeginningBalanceQuantity = 8;
		subject.QuantityAvailable = 7;
		//Test Parameters
		if (endingBalanceQuantity > 0) 
			subject.EndingBalanceQuantity = endingBalanceQuantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
