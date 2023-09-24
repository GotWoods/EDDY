using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class W01Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W01*6*Yy*c8y71HU6z1BD*u8*o*uF*C*rP*j*U*D*261728*G*PT*kf*j*sL";

		var expected = new W01_LineItemDetailWarehouse()
		{
			Quantity = 6,
			UnitOrBasisForMeasurementCode = "Yy",
			UPCCaseCode = "c8y71HU6z1BD",
			ProductServiceIDQualifier = "u8",
			ProductServiceID = "o",
			ProductServiceIDQualifier2 = "uF",
			ProductServiceID2 = "C",
			FreightClassCode = "rP",
			RateClassCode = "j",
			CommodityCodeQualifier = "U",
			CommodityCode = "D",
			PalletBlockAndTiers = 261728,
			WarehouseLotNumber = "G",
			ProductServiceConditionCode = "PT",
			ProductServiceIDQualifier3 = "kf",
			ProductServiceID3 = "j",
			SpecialServicesCode = "sL",
		};

		var actual = Map.MapObject<W01_LineItemDetailWarehouse>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new W01_LineItemDetailWarehouse();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "Yy";
		//Test Parameters
		if (quantity > 0) 
			subject.Quantity = quantity;
		//At Least one
		subject.UPCCaseCode = "c8y71HU6z1BD";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "u8";
			subject.ProductServiceID = "o";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "uF";
			subject.ProductServiceID2 = "C";
		}
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCode))
		{
			subject.CommodityCodeQualifier = "U";
			subject.CommodityCode = "D";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "kf";
			subject.ProductServiceID3 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Yy", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new W01_LineItemDetailWarehouse();
		//Required fields
		subject.Quantity = 6;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//At Least one
		subject.UPCCaseCode = "c8y71HU6z1BD";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "u8";
			subject.ProductServiceID = "o";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "uF";
			subject.ProductServiceID2 = "C";
		}
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCode))
		{
			subject.CommodityCodeQualifier = "U";
			subject.CommodityCode = "D";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "kf";
			subject.ProductServiceID3 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("c8y71HU6z1BD", "u8", true)]
	[InlineData("c8y71HU6z1BD", "", true)]
	[InlineData("", "u8", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new W01_LineItemDetailWarehouse();
		//Required fields
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "Yy";
		//Test Parameters
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "u8";
			subject.ProductServiceID = "o";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "uF";
			subject.ProductServiceID2 = "C";
		}
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCode))
		{
			subject.CommodityCodeQualifier = "U";
			subject.CommodityCode = "D";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "kf";
			subject.ProductServiceID3 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("u8", "o", true)]
	[InlineData("u8", "", false)]
	[InlineData("", "o", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new W01_LineItemDetailWarehouse();
		//Required fields
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "Yy";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//At Least one
		subject.UPCCaseCode = "c8y71HU6z1BD";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "uF";
			subject.ProductServiceID2 = "C";
		}
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCode))
		{
			subject.CommodityCodeQualifier = "U";
			subject.CommodityCode = "D";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "kf";
			subject.ProductServiceID3 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("uF", "C", true)]
	[InlineData("uF", "", false)]
	[InlineData("", "C", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new W01_LineItemDetailWarehouse();
		//Required fields
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "Yy";
		//Test Parameters
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//At Least one
		subject.UPCCaseCode = "c8y71HU6z1BD";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "u8";
			subject.ProductServiceID = "o";
		}
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCode))
		{
			subject.CommodityCodeQualifier = "U";
			subject.CommodityCode = "D";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "kf";
			subject.ProductServiceID3 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("U", "D", true)]
	[InlineData("U", "", false)]
	[InlineData("", "D", false)]
	public void Validation_AllAreRequiredCommodityCodeQualifier(string commodityCodeQualifier, string commodityCode, bool isValidExpected)
	{
		var subject = new W01_LineItemDetailWarehouse();
		//Required fields
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "Yy";
		//Test Parameters
		subject.CommodityCodeQualifier = commodityCodeQualifier;
		subject.CommodityCode = commodityCode;
		//At Least one
		subject.UPCCaseCode = "c8y71HU6z1BD";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "u8";
			subject.ProductServiceID = "o";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "uF";
			subject.ProductServiceID2 = "C";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "kf";
			subject.ProductServiceID3 = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("kf", "j", true)]
	[InlineData("kf", "", false)]
	[InlineData("", "j", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new W01_LineItemDetailWarehouse();
		//Required fields
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "Yy";
		//Test Parameters
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		//At Least one
		subject.UPCCaseCode = "c8y71HU6z1BD";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "u8";
			subject.ProductServiceID = "o";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "uF";
			subject.ProductServiceID2 = "C";
		}
		if(!string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCodeQualifier) || !string.IsNullOrEmpty(subject.CommodityCode))
		{
			subject.CommodityCodeQualifier = "U";
			subject.CommodityCode = "D";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
