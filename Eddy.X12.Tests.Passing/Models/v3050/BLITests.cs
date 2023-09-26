using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class BLITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BLI*3w*O*4*uc*MDZ*3*h7*Ju*Q*ql*7*r0*q";

		var expected = new BLI_BaselineItemData()
		{
			ProductServiceIDQualifier = "3w",
			ProductServiceID = "O",
			Quantity = 4,
			UnitOrBasisForMeasurementCode = "uc",
			PriceIdentifierCode = "MDZ",
			UnitPrice = 3,
			UnitOrBasisForMeasurementCode2 = "h7",
			ProductServiceIDQualifier2 = "Ju",
			ProductServiceID2 = "Q",
			ProductServiceIDQualifier3 = "ql",
			ProductServiceID3 = "7",
			ProductServiceIDQualifier4 = "r0",
			ProductServiceID4 = "q",
		};

		var actual = Map.MapObject<BLI_BaselineItemData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3w", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new BLI_BaselineItemData();
		//Required fields
		subject.ProductServiceID = "O";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "MDZ";
			subject.UnitPrice = 3;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ju";
			subject.ProductServiceID2 = "Q";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "ql";
			subject.ProductServiceID3 = "7";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "r0";
			subject.ProductServiceID4 = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("O", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new BLI_BaselineItemData();
		//Required fields
		subject.ProductServiceIDQualifier = "3w";
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "MDZ";
			subject.UnitPrice = 3;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ju";
			subject.ProductServiceID2 = "Q";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "ql";
			subject.ProductServiceID3 = "7";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "r0";
			subject.ProductServiceID4 = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("MDZ", 3, true)]
	[InlineData("MDZ", 0, false)]
	[InlineData("", 3, false)]
	public void Validation_AllAreRequiredPriceIdentifierCode(string priceIdentifierCode, decimal unitPrice, bool isValidExpected)
	{
		var subject = new BLI_BaselineItemData();
		//Required fields
		subject.ProductServiceIDQualifier = "3w";
		subject.ProductServiceID = "O";
		//Test Parameters
		subject.PriceIdentifierCode = priceIdentifierCode;
		if (unitPrice > 0) 
			subject.UnitPrice = unitPrice;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ju";
			subject.ProductServiceID2 = "Q";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "ql";
			subject.ProductServiceID3 = "7";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "r0";
			subject.ProductServiceID4 = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("h7", 3, true)]
	[InlineData("h7", 0, false)]
	[InlineData("", 3, true)]
	public void Validation_ARequiresBUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal unitPrice, bool isValidExpected)
	{
		var subject = new BLI_BaselineItemData();
		//Required fields
		subject.ProductServiceIDQualifier = "3w";
		subject.ProductServiceID = "O";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (unitPrice > 0) 
			subject.UnitPrice = unitPrice;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "MDZ";
			subject.UnitPrice = 3;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ju";
			subject.ProductServiceID2 = "Q";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "ql";
			subject.ProductServiceID3 = "7";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "r0";
			subject.ProductServiceID4 = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ju", "Q", true)]
	[InlineData("Ju", "", false)]
	[InlineData("", "Q", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new BLI_BaselineItemData();
		//Required fields
		subject.ProductServiceIDQualifier = "3w";
		subject.ProductServiceID = "O";
		//Test Parameters
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "MDZ";
			subject.UnitPrice = 3;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "ql";
			subject.ProductServiceID3 = "7";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "r0";
			subject.ProductServiceID4 = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("ql", "7", true)]
	[InlineData("ql", "", false)]
	[InlineData("", "7", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new BLI_BaselineItemData();
		//Required fields
		subject.ProductServiceIDQualifier = "3w";
		subject.ProductServiceID = "O";
		//Test Parameters
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "MDZ";
			subject.UnitPrice = 3;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ju";
			subject.ProductServiceID2 = "Q";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "r0";
			subject.ProductServiceID4 = "q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("r0", "q", true)]
	[InlineData("r0", "", false)]
	[InlineData("", "q", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier4(string productServiceIDQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new BLI_BaselineItemData();
		//Required fields
		subject.ProductServiceIDQualifier = "3w";
		subject.ProductServiceID = "O";
		//Test Parameters
		subject.ProductServiceIDQualifier4 = productServiceIDQualifier4;
		subject.ProductServiceID4 = productServiceID4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "MDZ";
			subject.UnitPrice = 3;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "Ju";
			subject.ProductServiceID2 = "Q";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "ql";
			subject.ProductServiceID3 = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
