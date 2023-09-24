using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class W23Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W23*Pb*2*9*7*tU9KtAEvtRsK*GY*Y*Y2*O*2*5*5*7*4";

		var expected = new W23_DetailActivityInventory()
		{
			UnitOfMeasurementCode = "Pb",
			BeginningBalanceQuantity = 2,
			QuantityAvailable = 9,
			EndingBalanceQuantity = 7,
			UPCCaseCode = "tU9KtAEvtRsK",
			ProductServiceIDQualifier = "GY",
			ProductServiceID = "Y",
			ProductServiceIDQualifier2 = "Y2",
			ProductServiceID2 = "O",
			QuantityReceived = 2,
			NumberOfUnitsShipped = 5,
			QuantityDamagedOnHold = 5,
			QuantityCommitted = 7,
			QuantityInTransit = 4,
		};

		var actual = Map.MapObject<W23_DetailActivityInventory>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Pb", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new W23_DetailActivityInventory();
		//Required fields
		subject.BeginningBalanceQuantity = 2;
		subject.QuantityAvailable = 9;
		subject.EndingBalanceQuantity = 7;
		//Test Parameters
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredBeginningBalanceQuantity(decimal beginningBalanceQuantity, bool isValidExpected)
	{
		var subject = new W23_DetailActivityInventory();
		//Required fields
		subject.UnitOfMeasurementCode = "Pb";
		subject.QuantityAvailable = 9;
		subject.EndingBalanceQuantity = 7;
		//Test Parameters
		if (beginningBalanceQuantity > 0) 
			subject.BeginningBalanceQuantity = beginningBalanceQuantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredQuantityAvailable(decimal quantityAvailable, bool isValidExpected)
	{
		var subject = new W23_DetailActivityInventory();
		//Required fields
		subject.UnitOfMeasurementCode = "Pb";
		subject.BeginningBalanceQuantity = 2;
		subject.EndingBalanceQuantity = 7;
		//Test Parameters
		if (quantityAvailable > 0) 
			subject.QuantityAvailable = quantityAvailable;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredEndingBalanceQuantity(decimal endingBalanceQuantity, bool isValidExpected)
	{
		var subject = new W23_DetailActivityInventory();
		//Required fields
		subject.UnitOfMeasurementCode = "Pb";
		subject.BeginningBalanceQuantity = 2;
		subject.QuantityAvailable = 9;
		//Test Parameters
		if (endingBalanceQuantity > 0) 
			subject.EndingBalanceQuantity = endingBalanceQuantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
