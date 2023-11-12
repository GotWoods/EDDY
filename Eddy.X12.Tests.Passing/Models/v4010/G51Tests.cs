using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class G51Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G51*3*ZF*1*z7*iya22rhScJ16*jRgCKzWcDO6D*Zd*L";

		var expected = new G51_FreeGoodsProductCondition()
		{
			QuantityFree = 3,
			UnitOrBasisForMeasurementCode = "ZF",
			QuantityMustPurchase = 1,
			UnitOrBasisForMeasurementCode2 = "z7",
			UPCCaseCode = "iya22rhScJ16",
			UPCEANConsumerPackageCode = "jRgCKzWcDO6D",
			ProductServiceIDQualifier = "Zd",
			ProductServiceID = "L",
		};

		var actual = Map.MapObject<G51_FreeGoodsProductCondition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "ZF", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "ZF", false)]
	public void Validation_AllAreRequiredQuantityFree(int quantityFree, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G51_FreeGoodsProductCondition();
		subject.QuantityMustPurchase = 1;
		subject.UnitOrBasisForMeasurementCode2 = "z7";
		if (quantityFree > 0)
			subject.QuantityFree = quantityFree;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Zd";
			subject.ProductServiceID = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredQuantityMustPurchase(int quantityMustPurchase, bool isValidExpected)
	{
		var subject = new G51_FreeGoodsProductCondition();
		subject.UnitOrBasisForMeasurementCode2 = "z7";
		if (quantityMustPurchase > 0)
			subject.QuantityMustPurchase = quantityMustPurchase;
		//If one is filled, all are required
		if(subject.QuantityFree > 0 || subject.QuantityFree > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.QuantityFree = 3;
			subject.UnitOrBasisForMeasurementCode = "ZF";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Zd";
			subject.ProductServiceID = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z7", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G51_FreeGoodsProductCondition();
		subject.QuantityMustPurchase = 1;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one is filled, all are required
		if(subject.QuantityFree > 0 || subject.QuantityFree > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.QuantityFree = 3;
			subject.UnitOrBasisForMeasurementCode = "ZF";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Zd";
			subject.ProductServiceID = "L";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Zd", "L", true)]
	[InlineData("Zd", "", false)]
	[InlineData("", "L", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G51_FreeGoodsProductCondition();
		subject.QuantityMustPurchase = 1;
		subject.UnitOrBasisForMeasurementCode2 = "z7";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//If one is filled, all are required
		if(subject.QuantityFree > 0 || subject.QuantityFree > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.QuantityFree = 3;
			subject.UnitOrBasisForMeasurementCode = "ZF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
