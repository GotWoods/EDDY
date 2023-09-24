using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class G17Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G17*6*Ca*9*IJjZU6JPe7Ll*kS*Q*Y8*b*y*3*Xg*U*r*3";

		var expected = new G17_ItemDetailInvoice()
		{
			QuantityInvoiced = 6,
			UnitOrBasisForMeasurementCode = "Ca",
			ItemListCost = 9,
			UPCCaseCode = "IJjZU6JPe7Ll",
			ProductServiceIDQualifier = "kS",
			ProductServiceID = "Q",
			ProductServiceIDQualifier2 = "Y8",
			ProductServiceID2 = "b",
			PriceBracketIdentifier = "y",
			NumberOfUnitsShipped = 3,
			UnitOrBasisForMeasurementCode2 = "Xg",
			PriceListNumber = "U",
			PriceListIssueNumber = "r",
			MonetaryAmount = 3,
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
		subject.UnitOrBasisForMeasurementCode = "Ca";
		if (quantityInvoiced > 0)
			subject.QuantityInvoiced = quantityInvoiced;
			subject.ItemListCost = 9;
			subject.UPCCaseCode = "IJjZU6JPe7Ll";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "kS";
			subject.ProductServiceID = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Y8";
			subject.ProductServiceID2 = "b";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.NumberOfUnitsShipped = 3;
			subject.UnitOrBasisForMeasurementCode2 = "Xg";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ca", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 6;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
			subject.ItemListCost = 9;
			subject.UPCCaseCode = "IJjZU6JPe7Ll";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "kS";
			subject.ProductServiceID = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Y8";
			subject.ProductServiceID2 = "b";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.NumberOfUnitsShipped = 3;
			subject.UnitOrBasisForMeasurementCode2 = "Xg";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, false)]
	[InlineData(9, 3, true)]
	[InlineData(9, 0, true)]
	[InlineData(0, 3, true)]
	public void Validation_AtLeastOneItemListCost(decimal itemListCost, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 6;
		subject.UnitOrBasisForMeasurementCode = "Ca";
		if (itemListCost > 0)
			subject.ItemListCost = itemListCost;
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
			subject.UPCCaseCode = "IJjZU6JPe7Ll";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "kS";
			subject.ProductServiceID = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Y8";
			subject.ProductServiceID2 = "b";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.NumberOfUnitsShipped = 3;
			subject.UnitOrBasisForMeasurementCode2 = "Xg";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("IJjZU6JPe7Ll", "kS", true)]
	[InlineData("IJjZU6JPe7Ll", "", true)]
	[InlineData("", "kS", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 6;
		subject.UnitOrBasisForMeasurementCode = "Ca";
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
			subject.ItemListCost = 9;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "kS";
			subject.ProductServiceID = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Y8";
			subject.ProductServiceID2 = "b";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.NumberOfUnitsShipped = 3;
			subject.UnitOrBasisForMeasurementCode2 = "Xg";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("kS", "Q", true)]
	[InlineData("kS", "", false)]
	[InlineData("", "Q", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 6;
		subject.UnitOrBasisForMeasurementCode = "Ca";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.ItemListCost = 9;
			subject.UPCCaseCode = "IJjZU6JPe7Ll";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Y8";
			subject.ProductServiceID2 = "b";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.NumberOfUnitsShipped = 3;
			subject.UnitOrBasisForMeasurementCode2 = "Xg";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Y8", "b", true)]
	[InlineData("Y8", "", false)]
	[InlineData("", "b", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 6;
		subject.UnitOrBasisForMeasurementCode = "Ca";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
			subject.ItemListCost = 9;
			subject.UPCCaseCode = "IJjZU6JPe7Ll";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "kS";
			subject.ProductServiceID = "Q";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.NumberOfUnitsShipped = 3;
			subject.UnitOrBasisForMeasurementCode2 = "Xg";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "Xg", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "Xg", false)]
	public void Validation_AllAreRequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 6;
		subject.UnitOrBasisForMeasurementCode = "Ca";
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
			subject.ItemListCost = 9;
			subject.UPCCaseCode = "IJjZU6JPe7Ll";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "kS";
			subject.ProductServiceID = "Q";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Y8";
			subject.ProductServiceID2 = "b";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
