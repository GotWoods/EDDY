using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class G17Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G17*7*a3*9*7*au*A*mr*v*G*7*5d*r*P*4";

		var expected = new G17_ItemDetailInvoice()
		{
			QuantityInvoiced = 7,
			UnitOrBasisForMeasurementCode = "a3",
			ItemListCost = 9,
			Number = 7,
			ProductServiceIDQualifier = "au",
			ProductServiceID = "A",
			ProductServiceIDQualifier2 = "mr",
			ProductServiceID2 = "v",
			PriceBracketIdentifier = "G",
			NumberOfUnitsShipped = 7,
			UnitOrBasisForMeasurementCode2 = "5d",
			PriceListNumber = "r",
			PriceListIssueNumber = "P",
			MonetaryAmount = 4,
		};

		var actual = Map.MapObject<G17_ItemDetailInvoice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredQuantityInvoiced(decimal quantityInvoiced, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.UnitOrBasisForMeasurementCode = "a3";
		subject.ProductServiceIDQualifier = "au";
		subject.ProductServiceID = "A";
		if (quantityInvoiced > 0)
			subject.QuantityInvoiced = quantityInvoiced;
			subject.ItemListCost = 9;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "mr";
			subject.ProductServiceID2 = "v";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.NumberOfUnitsShipped = 7;
			subject.UnitOrBasisForMeasurementCode2 = "5d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a3", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 7;
		subject.ProductServiceIDQualifier = "au";
		subject.ProductServiceID = "A";
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
			subject.ItemListCost = 9;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "mr";
			subject.ProductServiceID2 = "v";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.NumberOfUnitsShipped = 7;
			subject.UnitOrBasisForMeasurementCode2 = "5d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, false)]
	[InlineData(9, 4, true)]
	[InlineData(9, 0, true)]
	[InlineData(0, 4, true)]
	public void Validation_AtLeastOneItemListCost(decimal itemListCost, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 7;
		subject.UnitOrBasisForMeasurementCode = "a3";
		subject.ProductServiceIDQualifier = "au";
		subject.ProductServiceID = "A";
		if (itemListCost > 0)
			subject.ItemListCost = itemListCost;
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "mr";
			subject.ProductServiceID2 = "v";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.NumberOfUnitsShipped = 7;
			subject.UnitOrBasisForMeasurementCode2 = "5d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("au", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 7;
		subject.UnitOrBasisForMeasurementCode = "a3";
		subject.ProductServiceID = "A";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
			subject.ItemListCost = 9;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "mr";
			subject.ProductServiceID2 = "v";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.NumberOfUnitsShipped = 7;
			subject.UnitOrBasisForMeasurementCode2 = "5d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 7;
		subject.UnitOrBasisForMeasurementCode = "a3";
		subject.ProductServiceIDQualifier = "au";
		subject.ProductServiceID = productServiceID;
			subject.ItemListCost = 9;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "mr";
			subject.ProductServiceID2 = "v";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.NumberOfUnitsShipped = 7;
			subject.UnitOrBasisForMeasurementCode2 = "5d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("mr", "v", true)]
	[InlineData("mr", "", false)]
	[InlineData("", "v", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 7;
		subject.UnitOrBasisForMeasurementCode = "a3";
		subject.ProductServiceIDQualifier = "au";
		subject.ProductServiceID = "A";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
			subject.ItemListCost = 9;
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.NumberOfUnitsShipped = 7;
			subject.UnitOrBasisForMeasurementCode2 = "5d";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "5d", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "5d", false)]
	public void Validation_AllAreRequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 7;
		subject.UnitOrBasisForMeasurementCode = "a3";
		subject.ProductServiceIDQualifier = "au";
		subject.ProductServiceID = "A";
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
			subject.ItemListCost = 9;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "mr";
			subject.ProductServiceID2 = "v";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
