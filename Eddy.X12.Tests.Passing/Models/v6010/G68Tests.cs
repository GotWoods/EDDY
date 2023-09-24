using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class G68Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G68*6*iS*2*pGNJa0wKS7br*d2*v*Oq*6*x*S*Jk*a*j*E*1";

		var expected = new G68_LineItemDetailProduct()
		{
			Quantity = 6,
			UnitOrBasisForMeasurementCode = "iS",
			ItemListCost = 2,
			UPCCaseCode = "pGNJa0wKS7br",
			ProductServiceIDQualifier = "d2",
			ProductServiceID = "v",
			ProductServiceIDQualifier2 = "Oq",
			ProductServiceID2 = "6",
			PriceBracketIdentifier = "x",
			QuantityCost = "S",
			UnitOrBasisForMeasurementCode2 = "Jk",
			PriceListNumber = "a",
			PriceListIssueNumber = "j",
			PrePriceQuantityDesignator = "E",
			RetailPrePrice = 1,
		};

		var actual = Map.MapObject<G68_LineItemDetailProduct>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.UnitOrBasisForMeasurementCode = "iS";
		if (quantity > 0)
			subject.Quantity = quantity;
			subject.UPCCaseCode = "pGNJa0wKS7br";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "d2";
			subject.ProductServiceID = "v";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Oq";
			subject.ProductServiceID2 = "6";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.QuantityCost = "S";
			subject.UnitOrBasisForMeasurementCode2 = "Jk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("iS", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
			subject.UPCCaseCode = "pGNJa0wKS7br";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "d2";
			subject.ProductServiceID = "v";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Oq";
			subject.ProductServiceID2 = "6";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.QuantityCost = "S";
			subject.UnitOrBasisForMeasurementCode2 = "Jk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("pGNJa0wKS7br", "d2", true)]
	[InlineData("pGNJa0wKS7br", "", true)]
	[InlineData("", "d2", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "iS";
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "d2";
			subject.ProductServiceID = "v";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Oq";
			subject.ProductServiceID2 = "6";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.QuantityCost = "S";
			subject.UnitOrBasisForMeasurementCode2 = "Jk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("d2", "v", true)]
	[InlineData("d2", "", false)]
	[InlineData("", "v", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "iS";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UPCCaseCode = "pGNJa0wKS7br";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Oq";
			subject.ProductServiceID2 = "6";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.QuantityCost = "S";
			subject.UnitOrBasisForMeasurementCode2 = "Jk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Oq", "6", true)]
	[InlineData("Oq", "", false)]
	[InlineData("", "6", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "iS";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
			subject.UPCCaseCode = "pGNJa0wKS7br";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "d2";
			subject.ProductServiceID = "v";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.QuantityCost = "S";
			subject.UnitOrBasisForMeasurementCode2 = "Jk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("S", "Jk", true)]
	[InlineData("S", "", false)]
	[InlineData("", "Jk", false)]
	public void Validation_AllAreRequiredQuantityCost(string quantityCost, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.Quantity = 6;
		subject.UnitOrBasisForMeasurementCode = "iS";
		subject.QuantityCost = quantityCost;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
			subject.UPCCaseCode = "pGNJa0wKS7br";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "d2";
			subject.ProductServiceID = "v";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Oq";
			subject.ProductServiceID2 = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
