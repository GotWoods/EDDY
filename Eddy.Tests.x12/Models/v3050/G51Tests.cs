using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class G51Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G51*1*GB*4*oO*NAXacsEBtiul*DuantkGEs3PJ*VB*G";

		var expected = new G51_FreeGoods()
		{
			QuantityFree = 1,
			UnitOrBasisForMeasurementCode = "GB",
			QuantityMustPurchase = 4,
			UnitOrBasisForMeasurementCode2 = "oO",
			UPCCaseCode = "NAXacsEBtiul",
			UPCEANConsumerPackageCode = "DuantkGEs3PJ",
			ProductServiceIDQualifier = "VB",
			ProductServiceID = "G",
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
		subject.UnitOrBasisForMeasurementCode = "GB";
		subject.QuantityMustPurchase = 4;
		subject.UnitOrBasisForMeasurementCode2 = "oO";
		if (quantityFree > 0)
			subject.QuantityFree = quantityFree;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "VB";
			subject.ProductServiceID = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GB", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G51_FreeGoods();
		subject.QuantityFree = 1;
		subject.QuantityMustPurchase = 4;
		subject.UnitOrBasisForMeasurementCode2 = "oO";
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "VB";
			subject.ProductServiceID = "G";
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
		subject.UnitOrBasisForMeasurementCode = "GB";
		subject.UnitOrBasisForMeasurementCode2 = "oO";
		if (quantityMustPurchase > 0)
			subject.QuantityMustPurchase = quantityMustPurchase;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "VB";
			subject.ProductServiceID = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("oO", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode2(string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G51_FreeGoods();
		subject.QuantityFree = 1;
		subject.UnitOrBasisForMeasurementCode = "GB";
		subject.QuantityMustPurchase = 4;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "VB";
			subject.ProductServiceID = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("VB", "G", true)]
	[InlineData("VB", "", false)]
	[InlineData("", "G", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G51_FreeGoods();
		subject.QuantityFree = 1;
		subject.UnitOrBasisForMeasurementCode = "GB";
		subject.QuantityMustPurchase = 4;
		subject.UnitOrBasisForMeasurementCode2 = "oO";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
