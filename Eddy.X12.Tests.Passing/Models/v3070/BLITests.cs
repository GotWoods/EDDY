using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class BLITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BLI*ZC*k*5*rU*EGt*7*hG*q4*P*2q*f*I2*t*p*t*K*8*7";

		var expected = new BLI_BaselineItemData()
		{
			ProductServiceIDQualifier = "ZC",
			ProductServiceID = "k",
			Quantity = 5,
			UnitOrBasisForMeasurementCode = "rU",
			PriceIdentifierCode = "EGt",
			UnitPrice = 7,
			UnitOrBasisForMeasurementCode2 = "hG",
			ProductServiceIDQualifier2 = "q4",
			ProductServiceID2 = "P",
			ProductServiceIDQualifier3 = "2q",
			ProductServiceID3 = "f",
			ProductServiceIDQualifier4 = "I2",
			ProductServiceID4 = "t",
			ProductOptionCode = "p",
			ProductOptionCode2 = "t",
			ProductOptionCode3 = "K",
			ProductOptionCode4 = "8",
			FrequencyCode = "7",
		};

		var actual = Map.MapObject<BLI_BaselineItemData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ZC", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new BLI_BaselineItemData();
		//Required fields
		subject.ProductServiceID = "k";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "EGt";
			subject.UnitPrice = 7;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "q4";
			subject.ProductServiceID2 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "2q";
			subject.ProductServiceID3 = "f";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "I2";
			subject.ProductServiceID4 = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("k", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new BLI_BaselineItemData();
		//Required fields
		subject.ProductServiceIDQualifier = "ZC";
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "EGt";
			subject.UnitPrice = 7;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "q4";
			subject.ProductServiceID2 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "2q";
			subject.ProductServiceID3 = "f";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "I2";
			subject.ProductServiceID4 = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("EGt", 7, true)]
	[InlineData("EGt", 0, false)]
	[InlineData("", 7, false)]
	public void Validation_AllAreRequiredPriceIdentifierCode(string priceIdentifierCode, decimal unitPrice, bool isValidExpected)
	{
		var subject = new BLI_BaselineItemData();
		//Required fields
		subject.ProductServiceIDQualifier = "ZC";
		subject.ProductServiceID = "k";
		//Test Parameters
		subject.PriceIdentifierCode = priceIdentifierCode;
		if (unitPrice > 0) 
			subject.UnitPrice = unitPrice;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "q4";
			subject.ProductServiceID2 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "2q";
			subject.ProductServiceID3 = "f";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "I2";
			subject.ProductServiceID4 = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("hG", 7, true)]
	[InlineData("hG", 0, false)]
	[InlineData("", 7, true)]
	public void Validation_ARequiresBUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal unitPrice, bool isValidExpected)
	{
		var subject = new BLI_BaselineItemData();
		//Required fields
		subject.ProductServiceIDQualifier = "ZC";
		subject.ProductServiceID = "k";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (unitPrice > 0) 
			subject.UnitPrice = unitPrice;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "EGt";
			subject.UnitPrice = 7;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "q4";
			subject.ProductServiceID2 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "2q";
			subject.ProductServiceID3 = "f";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "I2";
			subject.ProductServiceID4 = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("q4", "P", true)]
	[InlineData("q4", "", false)]
	[InlineData("", "P", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new BLI_BaselineItemData();
		//Required fields
		subject.ProductServiceIDQualifier = "ZC";
		subject.ProductServiceID = "k";
		//Test Parameters
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "EGt";
			subject.UnitPrice = 7;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "2q";
			subject.ProductServiceID3 = "f";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "I2";
			subject.ProductServiceID4 = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("2q", "f", true)]
	[InlineData("2q", "", false)]
	[InlineData("", "f", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new BLI_BaselineItemData();
		//Required fields
		subject.ProductServiceIDQualifier = "ZC";
		subject.ProductServiceID = "k";
		//Test Parameters
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "EGt";
			subject.UnitPrice = 7;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "q4";
			subject.ProductServiceID2 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier4) || !string.IsNullOrEmpty(subject.ProductServiceID4))
		{
			subject.ProductServiceIDQualifier4 = "I2";
			subject.ProductServiceID4 = "t";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("I2", "t", true)]
	[InlineData("I2", "", false)]
	[InlineData("", "t", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier4(string productServiceIDQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new BLI_BaselineItemData();
		//Required fields
		subject.ProductServiceIDQualifier = "ZC";
		subject.ProductServiceID = "k";
		//Test Parameters
		subject.ProductServiceIDQualifier4 = productServiceIDQualifier4;
		subject.ProductServiceID4 = productServiceID4;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.PriceIdentifierCode) || !string.IsNullOrEmpty(subject.PriceIdentifierCode) || subject.UnitPrice > 0)
		{
			subject.PriceIdentifierCode = "EGt";
			subject.UnitPrice = 7;
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier2) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier2 = "q4";
			subject.ProductServiceID2 = "P";
		}
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier3) || !string.IsNullOrEmpty(subject.ProductServiceID3))
		{
			subject.ProductServiceIDQualifier3 = "2q";
			subject.ProductServiceID3 = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
