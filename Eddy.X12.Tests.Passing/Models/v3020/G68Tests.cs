using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G68Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G68*9*Ge*6*yLZPI7QFjUeV*xu*K*6T*h*A*K*fi*9*x*i*8";

		var expected = new G68_LineItemDetailProduct()
		{
			QuantityOrdered = 9,
			UnitOfMeasurementCode = "Ge",
			ItemListCost = 6,
			UPCCaseCode = "yLZPI7QFjUeV",
			ProductServiceIDQualifier = "xu",
			ProductServiceID = "K",
			ProductServiceIDQualifier2 = "6T",
			ProductServiceID2 = "h",
			PriceBracketIdentifier = "A",
			QuantityCost = "K",
			UnitOfMeasurementCode2 = "fi",
			PriceListNumber = "9",
			PriceListIssueNumber = "x",
			PrePriceQuantityDesignator = "i",
			RetailPrePrice = 8,
		};

		var actual = Map.MapObject<G68_LineItemDetailProduct>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(9, true)]
	public void Validation_RequiredQuantityOrdered(decimal quantityOrdered, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.UnitOfMeasurementCode = "Ge";
		if (quantityOrdered > 0)
			subject.QuantityOrdered = quantityOrdered;
			subject.UPCCaseCode = "yLZPI7QFjUeV";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "xu";
			subject.ProductServiceID = "K";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "6T";
			subject.ProductServiceID2 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.QuantityCost = "K";
			subject.UnitOfMeasurementCode2 = "fi";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ge", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.QuantityOrdered = 9;
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
			subject.UPCCaseCode = "yLZPI7QFjUeV";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "xu";
			subject.ProductServiceID = "K";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "6T";
			subject.ProductServiceID2 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.QuantityCost = "K";
			subject.UnitOfMeasurementCode2 = "fi";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("yLZPI7QFjUeV", "xu", true)]
	[InlineData("yLZPI7QFjUeV", "", true)]
	[InlineData("", "xu", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.QuantityOrdered = 9;
		subject.UnitOfMeasurementCode = "Ge";
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "xu";
			subject.ProductServiceID = "K";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "6T";
			subject.ProductServiceID2 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.QuantityCost = "K";
			subject.UnitOfMeasurementCode2 = "fi";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("xu", "K", true)]
	[InlineData("xu", "", false)]
	[InlineData("", "K", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.QuantityOrdered = 9;
		subject.UnitOfMeasurementCode = "Ge";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
			subject.UPCCaseCode = "yLZPI7QFjUeV";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "6T";
			subject.ProductServiceID2 = "h";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.QuantityCost = "K";
			subject.UnitOfMeasurementCode2 = "fi";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("6T", "h", true)]
	[InlineData("6T", "", false)]
	[InlineData("", "h", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.QuantityOrdered = 9;
		subject.UnitOfMeasurementCode = "Ge";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
			subject.UPCCaseCode = "yLZPI7QFjUeV";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "xu";
			subject.ProductServiceID = "K";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.QuantityCost) || !string.IsNullOrEmpty(subject.UnitOfMeasurementCode2))
		{
			subject.QuantityCost = "K";
			subject.UnitOfMeasurementCode2 = "fi";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("K", "fi", true)]
	[InlineData("K", "", false)]
	[InlineData("", "fi", false)]
	public void Validation_AllAreRequiredQuantityCost(string quantityCost, string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new G68_LineItemDetailProduct();
		subject.QuantityOrdered = 9;
		subject.UnitOfMeasurementCode = "Ge";
		subject.QuantityCost = quantityCost;
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
			subject.UPCCaseCode = "yLZPI7QFjUeV";
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "xu";
			subject.ProductServiceID = "K";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "6T";
			subject.ProductServiceID2 = "h";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
