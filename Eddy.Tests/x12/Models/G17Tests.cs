using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G17Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G17*6*6x*3*7*Tx*a*4t*f*Y*5*aZ*6*Z*8";

		var expected = new G17_ItemDetailInvoice()
		{
			QuantityInvoiced = 6,
			UnitOrBasisForMeasurementCode = "6x",
			ItemListCost = 3,
			Number = 7,
			ProductServiceIDQualifier = "Tx",
			ProductServiceID = "a",
			ProductServiceIDQualifier2 = "4t",
			ProductServiceID2 = "f",
			PriceBracketIdentifier = "Y",
			NumberOfUnitsShipped = 5,
			UnitOrBasisForMeasurementCode2 = "aZ",
			PriceListNumber = "6",
			PriceListIssueNumber = "Z",
			MonetaryAmount = 8,
		};

		var actual = Map.MapObject<G17_ItemDetailInvoice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredQuantityInvoiced(decimal quantityInvoiced, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.UnitOrBasisForMeasurementCode = "6x";
		subject.ProductServiceIDQualifier = "Tx";
		subject.ProductServiceID = "a";
		if (quantityInvoiced > 0)
		subject.QuantityInvoiced = quantityInvoiced;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6x", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 6;
		subject.ProductServiceIDQualifier = "Tx";
		subject.ProductServiceID = "a";
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,0, false)]
	[InlineData(3,8, true)]
	[InlineData(0, 8, true)]
	[InlineData(3, 0, true)]
	public void Validation_AtLeastOneItemListCost(decimal itemListCost, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 6;
		subject.UnitOrBasisForMeasurementCode = "6x";
		subject.ProductServiceIDQualifier = "Tx";
		subject.ProductServiceID = "a";
		if (itemListCost > 0)
		subject.ItemListCost = itemListCost;
		if (monetaryAmount > 0)
		subject.MonetaryAmount = monetaryAmount;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Tx", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 6;
		subject.UnitOrBasisForMeasurementCode = "6x";
		subject.ProductServiceID = "a";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 6;
		subject.UnitOrBasisForMeasurementCode = "6x";
		subject.ProductServiceIDQualifier = "Tx";
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("4t", "f", true)]
	[InlineData("", "f", false)]
	[InlineData("4t", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 6;
		subject.UnitOrBasisForMeasurementCode = "6x";
		subject.ProductServiceIDQualifier = "Tx";
		subject.ProductServiceID = "a";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(5, "aZ", true)]
	[InlineData(0, "aZ", false)]
	[InlineData(5, "", false)]
	public void Validation_AllAreRequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 6;
		subject.UnitOrBasisForMeasurementCode = "6x";
		subject.ProductServiceIDQualifier = "Tx";
		subject.ProductServiceID = "a";
		if (numberOfUnitsShipped > 0)
		subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
