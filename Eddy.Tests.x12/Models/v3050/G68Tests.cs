using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class G68Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G68*5*xM*9*ndBTDFIVHIeW*Ze*I*Hn*C*r*q*YB*g*P*c*2";

		var expected = new G68_LineItemDetailProduct()
		{
			QuantityOrdered = 5,
			UnitOrBasisForMeasurementCode = "xM",
			ItemListCost = 9,
			UPCCaseCode = "ndBTDFIVHIeW",
			ProductServiceIDQualifier = "Ze",
			ProductServiceID = "I",
			ProductServiceIDQualifier2 = "Hn",
			ProductServiceID2 = "C",
			PriceBracketIdentifier = "r",
			QuantityCost = "q",
			UnitOrBasisForMeasurementCode2 = "YB",
			PriceListNumber = "g",
			PriceListIssueNumber = "P",
			PrePriceQuantityDesignator = "c",
			RetailPrePrice = 2,
		};

		var actual = Map.MapObject<G68_LineItemDetailProduct>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredQuantityOrdered(decimal quantityOrdered, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.UnitOrBasisForMeasurementCode = "xM";
		if (quantityOrdered > 0)
			subject.QuantityOrdered = quantityOrdered;
			subject.UPCCaseCode = "ndBTDFIVHIeW";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Ze";
			subject.ProductServiceID = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Hn";
			subject.ProductServiceID2 = "C";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.QuantityCost = "q";
			subject.UnitOrBasisForMeasurementCode2 = "YB";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xM", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.QuantityOrdered = 5;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
			subject.UPCCaseCode = "ndBTDFIVHIeW";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Ze";
			subject.ProductServiceID = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Hn";
			subject.ProductServiceID2 = "C";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.QuantityCost = "q";
			subject.UnitOrBasisForMeasurementCode2 = "YB";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("ndBTDFIVHIeW", "Ze", true)]
	[InlineData("ndBTDFIVHIeW", "", true)]
	[InlineData("", "Ze", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.QuantityOrdered = 5;
		subject.UnitOrBasisForMeasurementCode = "xM";
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Ze";
			subject.ProductServiceID = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Hn";
			subject.ProductServiceID2 = "C";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.QuantityCost = "q";
			subject.UnitOrBasisForMeasurementCode2 = "YB";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ze", "I", true)]
	[InlineData("Ze", "", false)]
	[InlineData("", "I", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.QuantityOrdered = 5;
		subject.UnitOrBasisForMeasurementCode = "xM";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UPCCaseCode = "ndBTDFIVHIeW";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Hn";
			subject.ProductServiceID2 = "C";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.QuantityCost = "q";
			subject.UnitOrBasisForMeasurementCode2 = "YB";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Hn", "C", true)]
	[InlineData("Hn", "", false)]
	[InlineData("", "C", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.QuantityOrdered = 5;
		subject.UnitOrBasisForMeasurementCode = "xM";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
			subject.UPCCaseCode = "ndBTDFIVHIeW";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Ze";
			subject.ProductServiceID = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.QuantityCost = "q";
			subject.UnitOrBasisForMeasurementCode2 = "YB";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("q", "YB", true)]
	[InlineData("q", "", false)]
	[InlineData("", "YB", false)]
	public void Validation_AllAreRequiredQuantityCost(string quantityCost, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.QuantityOrdered = 5;
		subject.UnitOrBasisForMeasurementCode = "xM";
		subject.QuantityCost = quantityCost;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
			subject.UPCCaseCode = "ndBTDFIVHIeW";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Ze";
			subject.ProductServiceID = "I";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Hn";
			subject.ProductServiceID2 = "C";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
