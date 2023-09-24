using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class W11Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W11*EI*M*9*Jq*2*E2*3*DE*3*A0*4*w2*8*cG*9*wA";

		var expected = new W11_WarehouseQuantitiesDetail()
		{
			ReferenceNumberQualifier = "EI",
			ReferenceNumber = "M",
			BeginningBalanceQuantity = 9,
			UnitOfMeasurementCode = "Jq",
			QuantityAvailable = 2,
			UnitOfMeasurementCode2 = "E2",
			EndingBalanceQuantity = 3,
			UnitOfMeasurementCode3 = "DE",
			QuantityReceived = 3,
			UnitOfMeasurementCode4 = "A0",
			NumberOfUnitsShipped = 4,
			UnitOfMeasurementCode5 = "w2",
			QuantityDamagedOnHold = 8,
			UnitOfMeasurementCode6 = "cG",
			QuantityOrdered = 9,
			UnitOfMeasurementCode7 = "wA",
		};

		var actual = Map.MapObject<W11_WarehouseQuantitiesDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("EI", true)]
	public void Validation_RequiredReferenceNumberQualifier(string referenceNumberQualifier, bool isValidExpected)
	{
		var subject = new W11_WarehouseQuantitiesDetail();
		//Required fields
		subject.ReferenceNumber = "M";
		subject.BeginningBalanceQuantity = 9;
		subject.UnitOfMeasurementCode = "Jq";
		subject.QuantityAvailable = 2;
		subject.UnitOfMeasurementCode2 = "E2";
		subject.EndingBalanceQuantity = 3;
		subject.UnitOfMeasurementCode3 = "DE";
		//Test Parameters
		subject.ReferenceNumberQualifier = referenceNumberQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("M", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new W11_WarehouseQuantitiesDetail();
		//Required fields
		subject.ReferenceNumberQualifier = "EI";
		subject.BeginningBalanceQuantity = 9;
		subject.UnitOfMeasurementCode = "Jq";
		subject.QuantityAvailable = 2;
		subject.UnitOfMeasurementCode2 = "E2";
		subject.EndingBalanceQuantity = 3;
		subject.UnitOfMeasurementCode3 = "DE";
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredBeginningBalanceQuantity(decimal beginningBalanceQuantity, bool isValidExpected)
	{
		var subject = new W11_WarehouseQuantitiesDetail();
		//Required fields
		subject.ReferenceNumberQualifier = "EI";
		subject.ReferenceNumber = "M";
		subject.UnitOfMeasurementCode = "Jq";
		subject.QuantityAvailable = 2;
		subject.UnitOfMeasurementCode2 = "E2";
		subject.EndingBalanceQuantity = 3;
		subject.UnitOfMeasurementCode3 = "DE";
		//Test Parameters
		if (beginningBalanceQuantity > 0) 
			subject.BeginningBalanceQuantity = beginningBalanceQuantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Jq", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new W11_WarehouseQuantitiesDetail();
		//Required fields
		subject.ReferenceNumberQualifier = "EI";
		subject.ReferenceNumber = "M";
		subject.BeginningBalanceQuantity = 9;
		subject.QuantityAvailable = 2;
		subject.UnitOfMeasurementCode2 = "E2";
		subject.EndingBalanceQuantity = 3;
		subject.UnitOfMeasurementCode3 = "DE";
		//Test Parameters
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredQuantityAvailable(decimal quantityAvailable, bool isValidExpected)
	{
		var subject = new W11_WarehouseQuantitiesDetail();
		//Required fields
		subject.ReferenceNumberQualifier = "EI";
		subject.ReferenceNumber = "M";
		subject.BeginningBalanceQuantity = 9;
		subject.UnitOfMeasurementCode = "Jq";
		subject.UnitOfMeasurementCode2 = "E2";
		subject.EndingBalanceQuantity = 3;
		subject.UnitOfMeasurementCode3 = "DE";
		//Test Parameters
		if (quantityAvailable > 0) 
			subject.QuantityAvailable = quantityAvailable;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("E2", true)]
	public void Validation_RequiredUnitOfMeasurementCode2(string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new W11_WarehouseQuantitiesDetail();
		//Required fields
		subject.ReferenceNumberQualifier = "EI";
		subject.ReferenceNumber = "M";
		subject.BeginningBalanceQuantity = 9;
		subject.UnitOfMeasurementCode = "Jq";
		subject.QuantityAvailable = 2;
		subject.EndingBalanceQuantity = 3;
		subject.UnitOfMeasurementCode3 = "DE";
		//Test Parameters
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredEndingBalanceQuantity(decimal endingBalanceQuantity, bool isValidExpected)
	{
		var subject = new W11_WarehouseQuantitiesDetail();
		//Required fields
		subject.ReferenceNumberQualifier = "EI";
		subject.ReferenceNumber = "M";
		subject.BeginningBalanceQuantity = 9;
		subject.UnitOfMeasurementCode = "Jq";
		subject.QuantityAvailable = 2;
		subject.UnitOfMeasurementCode2 = "E2";
		subject.UnitOfMeasurementCode3 = "DE";
		//Test Parameters
		if (endingBalanceQuantity > 0) 
			subject.EndingBalanceQuantity = endingBalanceQuantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DE", true)]
	public void Validation_RequiredUnitOfMeasurementCode3(string unitOfMeasurementCode3, bool isValidExpected)
	{
		var subject = new W11_WarehouseQuantitiesDetail();
		//Required fields
		subject.ReferenceNumberQualifier = "EI";
		subject.ReferenceNumber = "M";
		subject.BeginningBalanceQuantity = 9;
		subject.UnitOfMeasurementCode = "Jq";
		subject.QuantityAvailable = 2;
		subject.UnitOfMeasurementCode2 = "E2";
		subject.EndingBalanceQuantity = 3;
		//Test Parameters
		subject.UnitOfMeasurementCode3 = unitOfMeasurementCode3;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
