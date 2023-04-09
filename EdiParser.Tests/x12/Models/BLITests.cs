using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class BLITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "BLI*rL*x*5*cH*sNt*5*Hu*Ha*8*G3*2*lL*7*w*k*q*i*3";

		var expected = new BLI_BasicBaselineItemData()
		{
			ProductServiceIDQualifier = "rL",
			ProductServiceID = "x",
			Quantity = 5,
			UnitOrBasisForMeasurementCode = "cH",
			PriceIdentifierCode = "sNt",
			UnitPrice = 5,
			UnitOrBasisForMeasurementCode2 = "Hu",
			ProductServiceIDQualifier2 = "Ha",
			ProductServiceID2 = "8",
			ProductServiceIDQualifier3 = "G3",
			ProductServiceID3 = "2",
			ProductServiceIDQualifier4 = "lL",
			ProductServiceID4 = "7",
			ProductOptionCode = "w",
			ProductOptionCode2 = "k",
			ProductOptionCode3 = "q",
			ProductOptionCode4 = "i",
			FrequencyCode = "3",
		};

		var actual = Map.MapObject<BLI_BasicBaselineItemData>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rL", true)]
	public void Validatation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new BLI_BasicBaselineItemData();
		subject.ProductServiceID = "x";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validatation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new BLI_BasicBaselineItemData();
		subject.ProductServiceIDQualifier = "rL";
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 5, true)]
	[InlineData("cH", 0, false)]
	public void Validation_ARequiresBUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new BLI_BasicBaselineItemData();
		subject.ProductServiceIDQualifier = "rL";
		subject.ProductServiceID = "x";
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0)
		subject.Quantity = quantity;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("sNt", 5, true)]
	[InlineData("", 5, false)]
	[InlineData("sNt", 0, false)]
	public void Validation_AllAreRequiredPriceIdentifierCode(string priceIdentifierCode, decimal unitPrice, bool isValidExpected)
	{
		var subject = new BLI_BasicBaselineItemData();
		subject.ProductServiceIDQualifier = "rL";
		subject.ProductServiceID = "x";
		subject.PriceIdentifierCode = priceIdentifierCode;
		if (unitPrice > 0)
		subject.UnitPrice = unitPrice;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("", 5, true)]
	[InlineData("Hu", 0, false)]
	public void Validation_ARequiresBUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, decimal unitPrice, bool isValidExpected)
	{
		var subject = new BLI_BasicBaselineItemData();
		subject.ProductServiceIDQualifier = "rL";
		subject.ProductServiceID = "x";
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		if (unitPrice > 0)
		{
			subject.UnitPrice = unitPrice;
			subject.PriceIdentifierCode = "AAA";
		}

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Ha", "8", true)]
	[InlineData("", "8", false)]
	[InlineData("Ha", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier2(string productServiceIDQualifier2, string productServiceID2, bool isValidExpected)
	{
		var subject = new BLI_BasicBaselineItemData();
		subject.ProductServiceIDQualifier = "rL";
		subject.ProductServiceID = "x";
		subject.ProductServiceIDQualifier2 = productServiceIDQualifier2;
		subject.ProductServiceID2 = productServiceID2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("G3", "2", true)]
	[InlineData("", "2", false)]
	[InlineData("G3", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier3(string productServiceIDQualifier3, string productServiceID3, bool isValidExpected)
	{
		var subject = new BLI_BasicBaselineItemData();
		subject.ProductServiceIDQualifier = "rL";
		subject.ProductServiceID = "x";
		subject.ProductServiceIDQualifier3 = productServiceIDQualifier3;
		subject.ProductServiceID3 = productServiceID3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("lL", "7", true)]
	[InlineData("", "7", false)]
	[InlineData("lL", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier4(string productServiceIDQualifier4, string productServiceID4, bool isValidExpected)
	{
		var subject = new BLI_BasicBaselineItemData();
		subject.ProductServiceIDQualifier = "rL";
		subject.ProductServiceID = "x";
		subject.ProductServiceIDQualifier4 = productServiceIDQualifier4;
		subject.ProductServiceID4 = productServiceID4;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
