using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class G51Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G51*8*jB*4*5q*aCsOtZiGQIeX*hxBaty5gj3ru*Ee*Z";

		var expected = new G51_FreeGoods()
		{
			QuantityFree = 8,
			UnitOfMeasurementCode = "jB",
			QuantityMustPurchase = 4,
			UnitOfMeasurementCode2 = "5q",
			UPCCaseCode = "aCsOtZiGQIeX",
			UPCEANConsumerPackageCode = "hxBaty5gj3ru",
			ProductServiceIDQualifier = "Ee",
			ProductServiceID = "Z",
		};

		var actual = Map.MapObject<G51_FreeGoods>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredQuantityFree(int quantityFree, bool isValidExpected)
	{
		var subject = new G51_FreeGoods();
		subject.UnitOfMeasurementCode = "jB";
		subject.QuantityMustPurchase = 4;
		subject.UnitOfMeasurementCode2 = "5q";
		if (quantityFree > 0)
			subject.QuantityFree = quantityFree;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Ee";
			subject.ProductServiceID = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("jB", true)]
	public void Validation_RequiredUnitOfMeasurementCode(string unitOfMeasurementCode, bool isValidExpected)
	{
		var subject = new G51_FreeGoods();
		subject.QuantityFree = 8;
		subject.QuantityMustPurchase = 4;
		subject.UnitOfMeasurementCode2 = "5q";
		subject.UnitOfMeasurementCode = unitOfMeasurementCode;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Ee";
			subject.ProductServiceID = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredQuantityMustPurchase(int quantityMustPurchase, bool isValidExpected)
	{
		var subject = new G51_FreeGoods();
		subject.QuantityFree = 8;
		subject.UnitOfMeasurementCode = "jB";
		subject.UnitOfMeasurementCode2 = "5q";
		if (quantityMustPurchase > 0)
			subject.QuantityMustPurchase = quantityMustPurchase;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Ee";
			subject.ProductServiceID = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5q", true)]
	public void Validation_RequiredUnitOfMeasurementCode2(string unitOfMeasurementCode2, bool isValidExpected)
	{
		var subject = new G51_FreeGoods();
		subject.QuantityFree = 8;
		subject.UnitOfMeasurementCode = "jB";
		subject.QuantityMustPurchase = 4;
		subject.UnitOfMeasurementCode2 = unitOfMeasurementCode2;
		//If one is filled, all are required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID))
		{
			subject.ProductServiceIDQualifier = "Ee";
			subject.ProductServiceID = "Z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Ee", "Z", true)]
	[InlineData("Ee", "", false)]
	[InlineData("", "Z", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID, bool isValidExpected)
	{
		var subject = new G51_FreeGoods();
		subject.QuantityFree = 8;
		subject.UnitOfMeasurementCode = "jB";
		subject.QuantityMustPurchase = 4;
		subject.UnitOfMeasurementCode2 = "5q";
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID = productServiceID;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
