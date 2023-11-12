using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class G51Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G51*1*DO*4*Ci*2ndQBjDRp9n3*xuGwi4LutYk5*rB*f";

		var expected = new G51_FreeGoods()
		{
			QuantityFree = 1,
			UnitOrBasisForMeasurementCode = "DO",
			QuantityMustPurchase = 4,
			UnitOrBasisForMeasurementCode2 = "Ci",
			UPCCaseCode = "2ndQBjDRp9n3",
			UPCEANConsumerPackageCode = "xuGwi4LutYk5",
			ProductServiceIDQualifier = "rB",
			ProductServiceID = "f",
		};

		var actual = Map.MapObject<G51_FreeGoods>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredQuantityFree(int quantityFree, bool isValidExpected)
	{
		var subject = new G51_FreeGoods();
		subject.UnitOrBasisForMeasurementCode = "DO";
		subject.QuantityMustPurchase = 4;
		subject.UnitOrBasisForMeasurementCode2 = "Ci";
		if (quantityFree > 0)
			subject.QuantityFree = quantityFree;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "rB";
			subject.ProductServiceID = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("DO", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G51_FreeGoods();
		subject.QuantityFree = 1;
		subject.QuantityMustPurchase = 4;
		subject.UnitOrBasisForMeasurementCode2 = "Ci";
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "rB";
			subject.ProductServiceID = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredQuantityMustPurchase(int quantityMustPurchase, bool isValidExpected)
	{
		var subject = new G51_FreeGoods();
		subject.QuantityFree = 1;
		subject.UnitOrBasisForMeasurementCode = "DO";
		subject.UnitOrBasisForMeasurementCode2 = "Ci";
		if (quantityMustPurchase > 0)
			subject.QuantityMustPurchase = quantityMustPurchase;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "rB";
			subject.ProductServiceID = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ci", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G51_FreeGoods();
		subject.QuantityFree = 1;
		subject.UnitOrBasisForMeasurementCode = "DO";
		subject.QuantityMustPurchase = 4;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "rB";
			subject.ProductServiceID = "f";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("rB", "f", true)]
	[InlineData("rB", "", false)]
	[InlineData("", "f", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G51_FreeGoods();
		subject.QuantityFree = 1;
		subject.UnitOrBasisForMeasurementCode = "DO";
		subject.QuantityMustPurchase = 4;
		subject.UnitOrBasisForMeasurementCode2 = "Ci";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
