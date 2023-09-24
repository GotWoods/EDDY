using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class G51Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G51*7*L1*2*tR*gSArQ9vjloql*g8LQdeVVokns*zy*e";

		var expected = new G51_FreeGoods()
		{
			QuantityFree = 7,
			UnitOrBasisForMeasurementCode = "L1",
			QuantityMustPurchase = 2,
			UnitOrBasisForMeasurementCode2 = "tR",
			UPCCaseCode = "gSArQ9vjloql",
			UPCEANConsumerPackageCode = "g8LQdeVVokns",
			ProductServiceIDQualifier = "zy",
			ProductServiceID = "e",
		};

		var actual = Map.MapObject<G51_FreeGoods>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredQuantityFree(int quantityFree, bool isValidExpected)
	{
		var subject = new G51_FreeGoods();
		subject.UnitOrBasisForMeasurementCode = "L1";
		subject.QuantityMustPurchase = 2;
		subject.UnitOrBasisForMeasurementCode2 = "tR";
		if (quantityFree > 0)
			subject.QuantityFree = quantityFree;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "zy";
			subject.ProductServiceID = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L1", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G51_FreeGoods();
		subject.QuantityFree = 7;
		subject.QuantityMustPurchase = 2;
		subject.UnitOrBasisForMeasurementCode2 = "tR";
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "zy";
			subject.ProductServiceID = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredQuantityMustPurchase(int quantityMustPurchase, bool isValidExpected)
	{
		var subject = new G51_FreeGoods();
		subject.QuantityFree = 7;
		subject.UnitOrBasisForMeasurementCode = "L1";
		subject.UnitOrBasisForMeasurementCode2 = "tR";
		if (quantityMustPurchase > 0)
			subject.QuantityMustPurchase = quantityMustPurchase;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "zy";
			subject.ProductServiceID = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tR", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G51_FreeGoods();
		subject.QuantityFree = 7;
		subject.UnitOrBasisForMeasurementCode = "L1";
		subject.QuantityMustPurchase = 2;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "zy";
			subject.ProductServiceID = "e";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("zy", "e", true)]
	[InlineData("zy", "", false)]
	[InlineData("", "e", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G51_FreeGoods();
		subject.QuantityFree = 7;
		subject.UnitOrBasisForMeasurementCode = "L1";
		subject.QuantityMustPurchase = 2;
		subject.UnitOrBasisForMeasurementCode2 = "tR";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
