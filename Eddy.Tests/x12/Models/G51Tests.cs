using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G51Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G51*3*r1*3*VC*vFeqSe0CY9rg*R30D5M06cX2T*aa*y";

		var expected = new G51_FreeGoodsProductCondition()
		{
			QuantityFree = 3,
			UnitOrBasisForMeasurementCode = "r1",
			QuantityMustPurchase = 3,
			UnitOrBasisForMeasurementCode2 = "VC",
			UPCCaseCode = "vFeqSe0CY9rg",
			UPCEANConsumerPackageCode = "R30D5M06cX2T",
			ProductServiceIDQualifier = "aa",
			ProductServiceID = "y",
		};

		var actual = Map.MapObject<G51_FreeGoodsProductCondition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(3, "r1", true)]
	[InlineData(0, "r1", false)]
	[InlineData(3, "", false)]
	public void Validation_AllAreRequiredQuantityFree(int quantityFree, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G51_FreeGoodsProductCondition();
		subject.QuantityMustPurchase = 3;
		subject.UnitOrBasisForMeasurementCode2 = "VC";
		if (quantityFree > 0)
		subject.QuantityFree = quantityFree;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(3, true)]
	public void Validation_RequiredQuantityMustPurchase(int quantityMustPurchase, bool isValidExpected)
	{
		var subject = new G51_FreeGoodsProductCondition();
		subject.UnitOrBasisForMeasurementCode2 = "VC";
		if (quantityMustPurchase > 0)
		subject.QuantityMustPurchase = quantityMustPurchase;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("VC", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G51_FreeGoodsProductCondition();
		subject.QuantityMustPurchase = 3;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("aa", "y", true)]
	[InlineData("", "y", false)]
	[InlineData("aa", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G51_FreeGoodsProductCondition();
		subject.QuantityMustPurchase = 3;
		subject.UnitOrBasisForMeasurementCode2 = "VC";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
