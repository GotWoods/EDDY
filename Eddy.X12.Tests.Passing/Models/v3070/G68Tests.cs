using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class G68Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G68*2*8Z*5*FEG2MKORzcEa*B6*D*g3*a*5*t*dT*H*j*2*5";

		var expected = new G68_LineItemDetailProduct()
		{
			QuantityOrdered = 2,
			UnitOrBasisForMeasurementCode = "8Z",
			ItemListCost = 5,
			UPCCaseCode = "FEG2MKORzcEa",
			ProductServiceIDQualifier = "B6",
			ProductServiceID = "D",
			ProductServiceIDQualifier2 = "g3",
			ProductServiceID2 = "a",
			PriceBracketIdentifier = "5",
			QuantityCost = "t",
			UnitOrBasisForMeasurementCode2 = "dT",
			PriceListNumber = "H",
			PriceListIssueNumber = "j",
			PrePriceQuantityDesignator = "2",
			RetailPrePrice = 5,
		};

		var actual = Map.MapObject<G68_LineItemDetailProduct>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredQuantityOrdered(decimal quantityOrdered, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.UnitOrBasisForMeasurementCode = "8Z";
		if (quantityOrdered > 0)
			subject.QuantityOrdered = quantityOrdered;
			subject.UPCCaseCode = "FEG2MKORzcEa";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "B6";
			subject.ProductServiceID = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "g3";
			subject.ProductServiceID2 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.QuantityCost = "t";
			subject.UnitOrBasisForMeasurementCode2 = "dT";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8Z", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.QuantityOrdered = 2;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
			subject.UPCCaseCode = "FEG2MKORzcEa";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "B6";
			subject.ProductServiceID = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "g3";
			subject.ProductServiceID2 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.QuantityCost = "t";
			subject.UnitOrBasisForMeasurementCode2 = "dT";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("FEG2MKORzcEa", "B6", true)]
	[InlineData("FEG2MKORzcEa", "", true)]
	[InlineData("", "B6", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.QuantityOrdered = 2;
		subject.UnitOrBasisForMeasurementCode = "8Z";
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "B6";
			subject.ProductServiceID = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "g3";
			subject.ProductServiceID2 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.QuantityCost = "t";
			subject.UnitOrBasisForMeasurementCode2 = "dT";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B6", "D", true)]
	[InlineData("B6", "", false)]
	[InlineData("", "D", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.QuantityOrdered = 2;
		subject.UnitOrBasisForMeasurementCode = "8Z";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UPCCaseCode = "FEG2MKORzcEa";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "g3";
			subject.ProductServiceID2 = "a";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.QuantityCost = "t";
			subject.UnitOrBasisForMeasurementCode2 = "dT";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("g3", "a", true)]
	[InlineData("g3", "", false)]
	[InlineData("", "a", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.QuantityOrdered = 2;
		subject.UnitOrBasisForMeasurementCode = "8Z";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
			subject.UPCCaseCode = "FEG2MKORzcEa";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "B6";
			subject.ProductServiceID = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.QuantityCost = "t";
			subject.UnitOrBasisForMeasurementCode2 = "dT";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("t", "dT", true)]
	[InlineData("t", "", false)]
	[InlineData("", "dT", false)]
	public void Validation_AllAreRequiredQuantityCost(string quantityCost, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.QuantityOrdered = 2;
		subject.UnitOrBasisForMeasurementCode = "8Z";
		subject.QuantityCost = quantityCost;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
			subject.UPCCaseCode = "FEG2MKORzcEa";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "B6";
			subject.ProductServiceID = "D";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "g3";
			subject.ProductServiceID2 = "a";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
