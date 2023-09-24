using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class W01Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W01*5*vW*K6HpIB0kC65S*sR*j*PG*b*Rv*O*g*2*529921*v*UM";

		var expected = new W01_LineItemDetailWarehouse()
		{
			QuantityOrdered = 5,
			UnitOfMeasurementCode = "vW",
			UPCCaseCode = "K6HpIB0kC65S",
			ProductServiceIDQualifier = "sR",
			ProductServiceID = "j",
			ProductServiceIDQualifier2 = "PG",
			ProductServiceID2 = "b",
			FreightClassCode = "Rv",
			RateClassCode = "O",
			CommodityCodeQualifier = "g",
			CommodityCode = "2",
			PalletBlockAndTiers = 529921,
			WarehouseLotNumber = "v",
			ProductServiceConditionCode = "UM",
		};

		var actual = Map.MapObject<W01_LineItemDetailWarehouse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredQuantityOrdered(decimal quantityOrdered, bool isValidExpected)
	{
		var subject = new W01_LineItemDetailWarehouse();
		//Required fields
		subject.UnitOfMeasurementCode = "vW";
		//Test Parameters
		if (quantityOrdered > 0) 
			subject.QuantityOrdered = quantityOrdered;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vW", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new W01_LineItemDetailWarehouse();
		//Required fields
		subject.QuantityOrdered = 5;
		//Test Parameters
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
