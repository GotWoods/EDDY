using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class G17Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G17*1*6k*1*CvntlfPjt5tH*AC*d*6w*6*Q*9*Wr*G*q";

		var expected = new G17_ItemDetailInvoice()
		{
			QuantityInvoiced = 1,
			UnitOrBasisForMeasurementCode = "6k",
			ItemListCost = 1,
			UPCCaseCode = "CvntlfPjt5tH",
			ProductServiceIDQualifier = "AC",
			ProductServiceID = "d",
			ProductServiceIDQualifier2 = "6w",
			ProductServiceID2 = "6",
			PriceBracketIdentifier = "Q",
			NumberOfUnitsShipped = 9,
			UnitOrBasisForMeasurementCode2 = "Wr",
			PriceListNumber = "G",
			PriceListIssueNumber = "q",
		};

		var actual = Map.MapObject<G17_ItemDetailInvoice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredQuantityInvoiced(decimal quantityInvoiced, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.UnitOrBasisForMeasurementCode = "6k";
		subject.ItemListCost = 1;
		if (quantityInvoiced > 0)
			subject.QuantityInvoiced = quantityInvoiced;
			subject.UPCCaseCode = "CvntlfPjt5tH";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "AC";
			subject.ProductServiceID = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "6w";
			subject.ProductServiceID2 = "6";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.NumberOfUnitsShipped = 9;
			subject.UnitOrBasisForMeasurementCode2 = "Wr";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6k", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 1;
		subject.ItemListCost = 1;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
			subject.UPCCaseCode = "CvntlfPjt5tH";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "AC";
			subject.ProductServiceID = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "6w";
			subject.ProductServiceID2 = "6";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.NumberOfUnitsShipped = 9;
			subject.UnitOrBasisForMeasurementCode2 = "Wr";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredItemListCost(decimal itemListCost, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 1;
		subject.UnitOrBasisForMeasurementCode = "6k";
		if (itemListCost > 0)
			subject.ItemListCost = itemListCost;
			subject.UPCCaseCode = "CvntlfPjt5tH";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "AC";
			subject.ProductServiceID = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "6w";
			subject.ProductServiceID2 = "6";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.NumberOfUnitsShipped = 9;
			subject.UnitOrBasisForMeasurementCode2 = "Wr";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("CvntlfPjt5tH", "AC", true)]
	[InlineData("CvntlfPjt5tH", "", true)]
	[InlineData("", "AC", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 1;
		subject.UnitOrBasisForMeasurementCode = "6k";
		subject.ItemListCost = 1;
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "AC";
			subject.ProductServiceID = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "6w";
			subject.ProductServiceID2 = "6";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.NumberOfUnitsShipped = 9;
			subject.UnitOrBasisForMeasurementCode2 = "Wr";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("AC", "d", true)]
	[InlineData("AC", "", false)]
	[InlineData("", "d", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 1;
		subject.UnitOrBasisForMeasurementCode = "6k";
		subject.ItemListCost = 1;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UPCCaseCode = "CvntlfPjt5tH";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "6w";
			subject.ProductServiceID2 = "6";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.NumberOfUnitsShipped = 9;
			subject.UnitOrBasisForMeasurementCode2 = "Wr";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6w", "6", true)]
	[InlineData("6w", "", false)]
	[InlineData("", "6", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 1;
		subject.UnitOrBasisForMeasurementCode = "6k";
		subject.ItemListCost = 1;
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
			subject.UPCCaseCode = "CvntlfPjt5tH";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "AC";
			subject.ProductServiceID = "d";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.NumberOfUnitsShipped = 9;
			subject.UnitOrBasisForMeasurementCode2 = "Wr";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "Wr", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "Wr", false)]
	public void Validation_AllAreRequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 1;
		subject.UnitOrBasisForMeasurementCode = "6k";
		subject.ItemListCost = 1;
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
			subject.UPCCaseCode = "CvntlfPjt5tH";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "AC";
			subject.ProductServiceID = "d";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "6w";
			subject.ProductServiceID2 = "6";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
