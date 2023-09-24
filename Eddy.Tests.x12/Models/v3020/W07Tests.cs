using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class W07Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W07*2*cv*o57BJ12NbEVm*TE*e*WM*3*Y*6";

		var expected = new W07_ItemDetailForStockReceipt()
		{
			QuantityReceived = 2,
			UnitOfMeasurementCode = "cv",
			UPCCaseCode = "o57BJ12NbEVm",
			ProductServiceIDQualifier = "TE",
			ProductServiceID = "e",
			ProductServiceIDQualifier2 = "WM",
			ProductServiceID2 = "3",
			WarehouseLotNumber = "Y",
			WarehouseDetailAdjustmentIdentifier = "6",
		};

		var actual = Map.MapObject<W07_ItemDetailForStockReceipt>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredQuantityReceived(decimal quantityReceived, bool isValidExpected)
	{
		var subject = new W07_ItemDetailForStockReceipt();
		//Required fields
		subject.UnitOfMeasurementCode = "cv";
		//Test Parameters
		if (quantityReceived > 0) 
			subject.QuantityReceived = quantityReceived;
		//At Least one
		subject.UPCCaseCode = "o57BJ12NbEVm";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "TE";
			subject.ProductServiceID = "e";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "WM";
			subject.ProductServiceID2 = "3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("cv", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new W07_ItemDetailForStockReceipt();
		//Required fields
		subject.QuantityReceived = 2;
		//Test Parameters
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//At Least one
		subject.UPCCaseCode = "o57BJ12NbEVm";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "TE";
			subject.ProductServiceID = "e";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "WM";
			subject.ProductServiceID2 = "3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("o57BJ12NbEVm", "TE", true)]
	[InlineData("o57BJ12NbEVm", "", true)]
	[InlineData("", "TE", true)]
	public void Validation_AtLeastOneUPCCaseCode(string uPCCaseCode, string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new W07_ItemDetailForStockReceipt();
		//Required fields
		subject.QuantityReceived = 2;
		subject.UnitOfMeasurementCode = "cv";
		//Test Parameters
		subject.UPCCaseCode = uPCCaseCode;
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "TE";
			subject.ProductServiceID = "e";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "WM";
			subject.ProductServiceID2 = "3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("TE", "e", true)]
	[InlineData("TE", "", false)]
	[InlineData("", "e", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new W07_ItemDetailForStockReceipt();
		//Required fields
		subject.QuantityReceived = 2;
		subject.UnitOfMeasurementCode = "cv";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//At Least one
		subject.UPCCaseCode = "o57BJ12NbEVm";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "WM";
			subject.ProductServiceID2 = "3";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("WM", "3", true)]
	[InlineData("WM", "", false)]
	[InlineData("", "3", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new W07_ItemDetailForStockReceipt();
		//Required fields
		subject.QuantityReceived = 2;
		subject.UnitOfMeasurementCode = "cv";
		//Test Parameters
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//At Least one
		subject.UPCCaseCode = "o57BJ12NbEVm";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "TE";
			subject.ProductServiceID = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
