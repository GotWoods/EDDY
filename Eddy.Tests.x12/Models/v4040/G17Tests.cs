using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class G17Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G17*5*Xf*5*xXeQSEil7Ipd*iT*G*l5*X*U*8*r8*G*k*8";

		var expected = new G17_ItemDetailInvoice()
		{
			QuantityInvoiced = 5,
			UnitOrBasisForMeasurementCode = "Xf",
			ItemListCost = 5,
			UPCCaseCode = "xXeQSEil7Ipd",
			ProductServiceIDQualifier = "iT",
			ProductServiceID = "G",
			ProductServiceIDQualifier2 = "l5",
			ProductServiceID2 = "X",
			PriceBracketIdentifier = "U",
			NumberOfUnitsShipped = 8,
			UnitOrBasisForMeasurementCode2 = "r8",
			PriceListNumber = "G",
			PriceListIssueNumber = "k",
			MonetaryAmount = 8,
		};

		var actual = Map.MapObject<G17_ItemDetailInvoice>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredQuantityInvoiced(decimal quantityInvoiced, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.UnitOrBasisForMeasurementCode = "Xf";
		if (quantityInvoiced > 0)
			subject.QuantityInvoiced = quantityInvoiced;
			subject.ItemListCost = 5;
			subject.UPCCaseCode = "xXeQSEil7Ipd";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "iT";
			subject.ProductServiceID = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "l5";
			subject.ProductServiceID2 = "X";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.NumberOfUnitsShipped = 8;
			subject.UnitOrBasisForMeasurementCode2 = "r8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Xf", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 5;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
			subject.ItemListCost = 5;
			subject.UPCCaseCode = "xXeQSEil7Ipd";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "iT";
			subject.ProductServiceID = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "l5";
			subject.ProductServiceID2 = "X";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.NumberOfUnitsShipped = 8;
			subject.UnitOrBasisForMeasurementCode2 = "r8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, 0, false)]
	[InlineData(5, 8, true)]
	[InlineData(5, 0, true)]
	[InlineData(0, 8, true)]
	public void Validation_AtLeastOneItemListCost(decimal itemListCost, decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 5;
		subject.UnitOrBasisForMeasurementCode = "Xf";
		if (itemListCost > 0)
			subject.ItemListCost = itemListCost;
		if (monetaryAmount > 0)
			subject.MonetaryAmount = monetaryAmount;
			subject.UPCCaseCode = "xXeQSEil7Ipd";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "iT";
			subject.ProductServiceID = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "l5";
			subject.ProductServiceID2 = "X";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.NumberOfUnitsShipped = 8;
			subject.UnitOrBasisForMeasurementCode2 = "r8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("xXeQSEil7Ipd", "iT", true)]
	[InlineData("xXeQSEil7Ipd", "", true)]
	[InlineData("", "iT", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 5;
		subject.UnitOrBasisForMeasurementCode = "Xf";
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
			subject.ItemListCost = 5;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "iT";
			subject.ProductServiceID = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "l5";
			subject.ProductServiceID2 = "X";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.NumberOfUnitsShipped = 8;
			subject.UnitOrBasisForMeasurementCode2 = "r8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("iT", "G", true)]
	[InlineData("iT", "", false)]
	[InlineData("", "G", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 5;
		subject.UnitOrBasisForMeasurementCode = "Xf";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.ItemListCost = 5;
			subject.UPCCaseCode = "xXeQSEil7Ipd";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "l5";
			subject.ProductServiceID2 = "X";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.NumberOfUnitsShipped = 8;
			subject.UnitOrBasisForMeasurementCode2 = "r8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("l5", "X", true)]
	[InlineData("l5", "", false)]
	[InlineData("", "X", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 5;
		subject.UnitOrBasisForMeasurementCode = "Xf";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
			subject.ItemListCost = 5;
			subject.UPCCaseCode = "xXeQSEil7Ipd";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "iT";
			subject.ProductServiceID = "G";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.NumberOfUnitsShipped = 8;
			subject.UnitOrBasisForMeasurementCode2 = "r8";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "r8", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "r8", false)]
	public void Validation_AllAreRequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 5;
		subject.UnitOrBasisForMeasurementCode = "Xf";
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
			subject.ItemListCost = 5;
			subject.UPCCaseCode = "xXeQSEil7Ipd";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "iT";
			subject.ProductServiceID = "G";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "l5";
			subject.ProductServiceID2 = "X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
