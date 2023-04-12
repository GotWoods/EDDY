using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class W01Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W01*9*W8*4eOlmHFTEUER*ZQ*r*Py*I*Lt*9*w*p*178772*y*ly*Ry*u*cm";

		var expected = new W01_LineItemDetailWarehouse()
		{
			Quantity = 9,
			UnitOrBasisForMeasurementCode = "W8",
			UPCCaseCode = "4eOlmHFTEUER",
			ProductServiceIDQualifier = "ZQ",
			ProductServiceID = "r",
			ProductServiceIDQualifier2 = "Py",
			ProductServiceID2 = "I",
			FreightClassCode = "Lt",
			RateClassCode = "9",
			CommodityCodeQualifier = "w",
			CommodityCode = "p",
			PalletBlockAndTiers = 178772,
			WarehouseLotNumber = "y",
			ProductServiceConditionCode = "ly",
			ProductServiceIDQualifier3 = "Ry",
			ProductServiceID3 = "u",
			SpecialServicesCode = "cm",
		};

		var actual = Map.MapObject<W01_LineItemDetailWarehouse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new W01_LineItemDetailWarehouse();
		subject.UnitOrBasisForMeasurementCode = "W8";
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W8", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new W01_LineItemDetailWarehouse();
		subject.Quantity = 9;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("4eOlmHFTEUER","ZQ", true)]
	[InlineData("", "ZQ", true)]
	[InlineData("4eOlmHFTEUER", "", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new W01_LineItemDetailWarehouse();
		subject.Quantity = 9;
		subject.UnitOrBasisForMeasurementCode = "W8";
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("ZQ", "r", true)]
	[InlineData("", "r", false)]
	[InlineData("ZQ", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new W01_LineItemDetailWarehouse();
		subject.Quantity = 9;
		subject.UnitOrBasisForMeasurementCode = "W8";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Py", "I", true)]
	[InlineData("", "I", false)]
	[InlineData("Py", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new W01_LineItemDetailWarehouse();
		subject.Quantity = 9;
		subject.UnitOrBasisForMeasurementCode = "W8";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("w", "p", true)]
	[InlineData("", "p", false)]
	[InlineData("w", "", false)]
	public void Validation_AllAreRequiredCommodityCodeQualifier(string commodityCodeQualifier, string commodityCode, bool isValidExpected)
	{
		var subject = new W01_LineItemDetailWarehouse();
		subject.Quantity = 9;
		subject.UnitOrBasisForMeasurementCode = "W8";
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.CommodityCode = commodityCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Ry", "u", true)]
	[InlineData("", "u", false)]
	[InlineData("Ry", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new W01_LineItemDetailWarehouse();
		subject.Quantity = 9;
		subject.UnitOrBasisForMeasurementCode = "W8";
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
