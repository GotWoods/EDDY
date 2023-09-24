using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class W01Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W01*6*v3*O1jJxPdMn577*AC*S*CG*n*gQ*1*b*C*353251*q*83*aD*y";

		var expected = new W01_LineItemDetailWarehouse()
		{
			QuantityOrdered = 6,
			UnitOrBasisForMeasurementCode = "v3",
			UPCCaseCode = "O1jJxPdMn577",
			ProductServiceIDQualifier = "AC",
			ProductServiceID = "S",
			ProductServiceIDQualifier2 = "CG",
			ProductServiceID2 = "n",
			FreightClassCode = "gQ",
			RateClassCode = "1",
			CommodityCodeQualifier = "b",
			CommodityCode = "C",
			PalletBlockAndTiers = 353251,
			WarehouseLotNumber = "q",
			ProductServiceConditionCode = "83",
			ProductServiceIDQualifier3 = "aD",
			ProductServiceID3 = "y",
		};

		var actual = Map.MapObject<W01_LineItemDetailWarehouse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantityOrdered(decimal quantityOrdered, bool isValidExpected)
	{
		var subject = new W01_LineItemDetailWarehouse();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "v3";
		//Test Parameters
		if (quantityOrdered > 0) 
			subject.QuantityOrdered = quantityOrdered;
		//At Least one
		subject.UPCCaseCode = "O1jJxPdMn577";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "AC";
			subject.ProductServiceID = "S";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "CG";
			subject.ProductServiceID2 = "n";
		}
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCode))
		{
			subject.CommodityCodeQualifier = "b";
			subject.CommodityCode = "C";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "aD";
			subject.ProductServiceID3 = "y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v3", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new W01_LineItemDetailWarehouse();
		//Required fields
		subject.QuantityOrdered = 6;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//At Least one
		subject.UPCCaseCode = "O1jJxPdMn577";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "AC";
			subject.ProductServiceID = "S";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "CG";
			subject.ProductServiceID2 = "n";
		}
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCode))
		{
			subject.CommodityCodeQualifier = "b";
			subject.CommodityCode = "C";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "aD";
			subject.ProductServiceID3 = "y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("O1jJxPdMn577", "AC", true)]
	[InlineData("O1jJxPdMn577", "", true)]
	[InlineData("", "AC", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new W01_LineItemDetailWarehouse();
		//Required fields
		subject.QuantityOrdered = 6;
		subject.UnitOrBasisForMeasurementCode = "v3";
		//Test Parameters
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "AC";
			subject.ProductServiceID = "S";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "CG";
			subject.ProductServiceID2 = "n";
		}
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCode))
		{
			subject.CommodityCodeQualifier = "b";
			subject.CommodityCode = "C";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "aD";
			subject.ProductServiceID3 = "y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("AC", "S", true)]
	[InlineData("AC", "", false)]
	[InlineData("", "S", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new W01_LineItemDetailWarehouse();
		//Required fields
		subject.QuantityOrdered = 6;
		subject.UnitOrBasisForMeasurementCode = "v3";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//At Least one
		subject.UPCCaseCode = "O1jJxPdMn577";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "CG";
			subject.ProductServiceID2 = "n";
		}
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCode))
		{
			subject.CommodityCodeQualifier = "b";
			subject.CommodityCode = "C";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "aD";
			subject.ProductServiceID3 = "y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("CG", "n", true)]
	[InlineData("CG", "", false)]
	[InlineData("", "n", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new W01_LineItemDetailWarehouse();
		//Required fields
		subject.QuantityOrdered = 6;
		subject.UnitOrBasisForMeasurementCode = "v3";
		//Test Parameters
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//At Least one
		subject.UPCCaseCode = "O1jJxPdMn577";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "AC";
			subject.ProductServiceID = "S";
		}
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCode))
		{
			subject.CommodityCodeQualifier = "b";
			subject.CommodityCode = "C";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "aD";
			subject.ProductServiceID3 = "y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("b", "C", true)]
	[InlineData("b", "", false)]
	[InlineData("", "C", false)]
	public void Validation_AllAreRequiredCommodityCodeQualifier(string commodityCodeQualifier, string commodityCode, bool isValidExpected)
	{
		var subject = new W01_LineItemDetailWarehouse();
		//Required fields
		subject.QuantityOrdered = 6;
		subject.UnitOrBasisForMeasurementCode = "v3";
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.CommodityCode = commodityCode;
		//At Least one
		subject.UPCCaseCode = "O1jJxPdMn577";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "AC";
			subject.ProductServiceID = "S";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "CG";
			subject.ProductServiceID2 = "n";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "aD";
			subject.ProductServiceID3 = "y";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("aD", "y", true)]
	[InlineData("aD", "", false)]
	[InlineData("", "y", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new W01_LineItemDetailWarehouse();
		//Required fields
		subject.QuantityOrdered = 6;
		subject.UnitOrBasisForMeasurementCode = "v3";
		//Test Parameters
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		//At Least one
		subject.UPCCaseCode = "O1jJxPdMn577";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "AC";
			subject.ProductServiceID = "S";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "CG";
			subject.ProductServiceID2 = "n";
		}
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCode))
		{
			subject.CommodityCodeQualifier = "b";
			subject.CommodityCode = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
