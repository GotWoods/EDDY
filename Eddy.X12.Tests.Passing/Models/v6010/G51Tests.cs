using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class G51Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G51*7*uE*3*Az*CAK5DQauaO2A*TIRhEy7BN1K1*sP*r";

		var expected = new G51_FreeGoodsProductCondition()
		{
			QuantityFree = 7,
			UnitOrBasisForMeasurementCode = "uE",
			QuantityMustPurchase = 3,
			UnitOrBasisForMeasurementCode2 = "Az",
			UPCCaseCode = "CAK5DQauaO2A",
			UPCEANConsumerPackageCode = "TIRhEy7BN1K1",
			ProductServiceIDQualifier = "sP",
			ProductServiceID = "r",
		};

		var actual = Map.MapObject<G51_FreeGoodsProductCondition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "uE", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "uE", false)]
	public void Validation_AllAreRequiredQuantityFree(int quantityFree, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G51_FreeGoodsProductCondition();
		subject.QuantityMustPurchase = 3;
		subject.UnitOrBasisForMeasurementCode2 = "Az";
		if (quantityFree > 0)
			subject.QuantityFree = quantityFree;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "sP";
			subject.ProductServiceID = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredQuantityMustPurchase(int quantityMustPurchase, bool isValidExpected)
	{
		var subject = new G51_FreeGoodsProductCondition();
		subject.UnitOrBasisForMeasurementCode2 = "Az";
		if (quantityMustPurchase > 0)
			subject.QuantityMustPurchase = quantityMustPurchase;
		//If one is filled, all are required
		if(subject.QuantityFree > 0 || subject.QuantityFree > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.QuantityFree = 7;
			subject.UnitOrBasisForMeasurementCode = "uE";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "sP";
			subject.ProductServiceID = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Az", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G51_FreeGoodsProductCondition();
		subject.QuantityMustPurchase = 3;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one is filled, all are required
		if(subject.QuantityFree > 0 || subject.QuantityFree > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.QuantityFree = 7;
			subject.UnitOrBasisForMeasurementCode = "uE";
		}
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "sP";
			subject.ProductServiceID = "r";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("sP", "r", true)]
	[InlineData("sP", "", false)]
	[InlineData("", "r", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G51_FreeGoodsProductCondition();
		subject.QuantityMustPurchase = 3;
		subject.UnitOrBasisForMeasurementCode2 = "Az";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		//If one is filled, all are required
		if(subject.QuantityFree > 0 || subject.QuantityFree > 0 || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode))
		{
			subject.QuantityFree = 7;
			subject.UnitOrBasisForMeasurementCode = "uE";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
