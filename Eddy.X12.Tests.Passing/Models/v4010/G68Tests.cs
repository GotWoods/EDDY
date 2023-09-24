using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class G68Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G68*6*i2*5*WGlnvSaB7dWz*vF*r*BN*R*W*y*7h*I*Z*T*8";

		var expected = new G68_LineItemDetailProduct()
		{
			QuantityOrdered = 6,
			UnitOrBasisForMeasurementCode = "i2",
			ItemListCost = 5,
			UPCCaseCode = "WGlnvSaB7dWz",
			ProductServiceIDQualifier = "vF",
			ProductServiceID = "r",
			ProductServiceIDQualifier2 = "BN",
			ProductServiceID2 = "R",
			PriceBracketIdentifier = "W",
			QuantityCost = "y",
			UnitOrBasisForMeasurementCode2 = "7h",
			PriceListNumber = "I",
			PriceListIssueNumber = "Z",
			PrePriceQuantityDesignator = "T",
			RetailPrePrice = 8,
		};

		var actual = Map.MapObject<G68_LineItemDetailProduct>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantityOrdered(decimal quantityOrdered, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.UnitOrBasisForMeasurementCode = "i2";
		if (quantityOrdered > 0)
			subject.QuantityOrdered = quantityOrdered;
			subject.UPCCaseCode = "WGlnvSaB7dWz";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "vF";
			subject.ProductServiceID = "r";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "BN";
			subject.ProductServiceID2 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.QuantityCost = "y";
			subject.UnitOrBasisForMeasurementCode2 = "7h";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("i2", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.QuantityOrdered = 6;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
			subject.UPCCaseCode = "WGlnvSaB7dWz";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "vF";
			subject.ProductServiceID = "r";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "BN";
			subject.ProductServiceID2 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.QuantityCost = "y";
			subject.UnitOrBasisForMeasurementCode2 = "7h";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("WGlnvSaB7dWz", "vF", true)]
	[InlineData("WGlnvSaB7dWz", "", true)]
	[InlineData("", "vF", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.QuantityOrdered = 6;
		subject.UnitOrBasisForMeasurementCode = "i2";
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "vF";
			subject.ProductServiceID = "r";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "BN";
			subject.ProductServiceID2 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.QuantityCost = "y";
			subject.UnitOrBasisForMeasurementCode2 = "7h";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("vF", "r", true)]
	[InlineData("vF", "", false)]
	[InlineData("", "r", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.QuantityOrdered = 6;
		subject.UnitOrBasisForMeasurementCode = "i2";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UPCCaseCode = "WGlnvSaB7dWz";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "BN";
			subject.ProductServiceID2 = "R";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.QuantityCost = "y";
			subject.UnitOrBasisForMeasurementCode2 = "7h";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("BN", "R", true)]
	[InlineData("BN", "", false)]
	[InlineData("", "R", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.QuantityOrdered = 6;
		subject.UnitOrBasisForMeasurementCode = "i2";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
			subject.UPCCaseCode = "WGlnvSaB7dWz";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "vF";
			subject.ProductServiceID = "r";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.QuantityCost = "y";
			subject.UnitOrBasisForMeasurementCode2 = "7h";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("y", "7h", true)]
	[InlineData("y", "", false)]
	[InlineData("", "7h", false)]
	public void Validation_AllAreRequiredQuantityCost(string quantityCost, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.QuantityOrdered = 6;
		subject.UnitOrBasisForMeasurementCode = "i2";
		subject.QuantityCost = quantityCost;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
			subject.UPCCaseCode = "WGlnvSaB7dWz";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "vF";
			subject.ProductServiceID = "r";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "BN";
			subject.ProductServiceID2 = "R";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
