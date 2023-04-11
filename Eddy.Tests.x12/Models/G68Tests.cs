using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G68Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G68*8*h6*8*2VThSeryVNJl*9M*k*sM*x*t*d*dq*5*z*p*7";

		var expected = new G68_LineItemDetailProduct()
		{
			Quantity = 8,
			UnitOrBasisForMeasurementCode = "h6",
			ItemListCost = 8,
			UPCCaseCode = "2VThSeryVNJl",
			ProductServiceIDQualifier = "9M",
			ProductServiceID = "k",
			ProductServiceIDQualifier2 = "sM",
			ProductServiceID2 = "x",
			PriceBracketIdentifier = "t",
			QuantityCost = "d",
			UnitOrBasisForMeasurementCode2 = "dq",
			PriceListNumber = "5",
			PriceListIssueNumber = "z",
			PrePriceQuantityDesignator = "p",
			RetailPrePrice = 7,
		};

		var actual = Map.MapObject<G68_LineItemDetailProduct>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredQuantity(decimal quantity, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.UnitOrBasisForMeasurementCode = "h6";
		if (quantity > 0)
		subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("h6", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.Quantity = 8;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("2VThSeryVNJl","9M", true)]
	[InlineData("", "9M", true)]
	[InlineData("2VThSeryVNJl", "", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.Quantity = 8;
		subject.UnitOrBasisForMeasurementCode = "h6";
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("9M", "k", true)]
	[InlineData("", "k", false)]
	[InlineData("9M", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.Quantity = 8;
		subject.UnitOrBasisForMeasurementCode = "h6";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("sM", "x", true)]
	[InlineData("", "x", false)]
	[InlineData("sM", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.Quantity = 8;
		subject.UnitOrBasisForMeasurementCode = "h6";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("d", "dq", true)]
	[InlineData("", "dq", false)]
	[InlineData("d", "", false)]
	public void Validation_AllAreRequiredQuantityCost(string quantityCost, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.Quantity = 8;
		subject.UnitOrBasisForMeasurementCode = "h6";
		subject.QuantityCost = quantityCost;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
