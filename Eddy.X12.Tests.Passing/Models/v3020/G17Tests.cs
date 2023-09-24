using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G17Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G17*6*Yf*1*lZdGbcjPPf6D*8h*9*LH*w*Q*1*LO*X*v";

		var expected = new G17_ItemDetailInvoice()
		{
			QuantityInvoiced = 6,
			UnitOfMeasurementCode = "Yf",
			ItemListCost = 1,
			UPCCaseCode = "lZdGbcjPPf6D",
			ProductServiceIDQualifier = "8h",
			ProductServiceID = "9",
			ProductServiceIDQualifier2 = "LH",
			ProductServiceID2 = "w",
			PriceBracketIdentifier = "Q",
			NumberOfUnitsShipped = 1,
			UnitOfMeasurementCode2 = "LO",
			PriceListNumber = "X",
			PriceListIssueNumber = "v",
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
		subject.UnitOfMeasurementCode = "Yf";
		subject.ItemListCost = 1;
		if (quantityInvoiced > 0)
			subject.QuantityInvoiced = quantityInvoiced;
			subject.UPCCaseCode = "lZdGbcjPPf6D";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "8h";
			subject.ProductServiceID = "9";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "LH";
			subject.ProductServiceID2 = "w";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.NumberOfUnitsShipped = 1;
			subject.UnitOfMeasurementCode2 = "LO";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Yf", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 6;
		subject.ItemListCost = 1;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
			subject.UPCCaseCode = "lZdGbcjPPf6D";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "8h";
			subject.ProductServiceID = "9";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "LH";
			subject.ProductServiceID2 = "w";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.NumberOfUnitsShipped = 1;
			subject.UnitOfMeasurementCode2 = "LO";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredItemListCost(decimal itemListCost, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 6;
		subject.UnitOfMeasurementCode = "Yf";
		if (itemListCost > 0)
			subject.ItemListCost = itemListCost;
			subject.UPCCaseCode = "lZdGbcjPPf6D";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "8h";
			subject.ProductServiceID = "9";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "LH";
			subject.ProductServiceID2 = "w";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.NumberOfUnitsShipped = 1;
			subject.UnitOfMeasurementCode2 = "LO";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("lZdGbcjPPf6D", "8h", true)]
	[InlineData("lZdGbcjPPf6D", "", true)]
	[InlineData("", "8h", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 6;
		subject.UnitOfMeasurementCode = "Yf";
		subject.ItemListCost = 1;
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "8h";
			subject.ProductServiceID = "9";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "LH";
			subject.ProductServiceID2 = "w";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.NumberOfUnitsShipped = 1;
			subject.UnitOfMeasurementCode2 = "LO";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8h", "9", true)]
	[InlineData("8h", "", false)]
	[InlineData("", "9", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 6;
		subject.UnitOfMeasurementCode = "Yf";
		subject.ItemListCost = 1;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UPCCaseCode = "lZdGbcjPPf6D";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "LH";
			subject.ProductServiceID2 = "w";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.NumberOfUnitsShipped = 1;
			subject.UnitOfMeasurementCode2 = "LO";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("LH", "w", true)]
	[InlineData("LH", "", false)]
	[InlineData("", "w", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 6;
		subject.UnitOfMeasurementCode = "Yf";
		subject.ItemListCost = 1;
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
			subject.UPCCaseCode = "lZdGbcjPPf6D";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "8h";
			subject.ProductServiceID = "9";
		}
		//If one is filled, all are required
		if(subject.NumberOfUnitsShipped > 0 || subject.NumberOfUnitsShipped > 0 || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.NumberOfUnitsShipped = 1;
			subject.UnitOfMeasurementCode2 = "LO";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "LO", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "LO", false)]
	public void Validation_AllAreRequiredNumberOfUnitsShipped(decimal numberOfUnitsShipped, string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new G17_ItemDetailInvoice();
		subject.QuantityInvoiced = 6;
		subject.UnitOfMeasurementCode = "Yf";
		subject.ItemListCost = 1;
		if (numberOfUnitsShipped > 0)
			subject.NumberOfUnitsShipped = numberOfUnitsShipped;
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
			subject.UPCCaseCode = "lZdGbcjPPf6D";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "8h";
			subject.ProductServiceID = "9";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "LH";
			subject.ProductServiceID2 = "w";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
