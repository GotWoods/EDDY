using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v7060;
using Eddy.x12.Models.v7060.Composites;

namespace Eddy.x12.Tests.Models.v7060.Composites;

public class C066Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var x12Line = "m*OZ*8*zF*I*zt";

		var expected = new C066_SellingOrOrderingProductBasisCode()
		{
			ProductProcurementBasisCode = "m",
			UnitOrBasisForMeasurementCode = "OZ",
			ProductProcurementBasisCode2 = "8",
			UnitOrBasisForMeasurementCode2 = "zF",
			ProductProcurementBasisCode3 = "I",
			UnitOrBasisForMeasurementCode3 = "zt",
		};

		var actual = Map.MapObject<C066_SellingOrOrderingProductBasisCode>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredProductProcurementBasisCode(string productProcurementBasisCode, bool isValidExpected)
	{
		var subject = new C066_SellingOrOrderingProductBasisCode();
		//Required fields
		subject.UnitOrBasisForMeasurementCode = "OZ";
		//Test Parameters
		subject.ProductProcurementBasisCode = productProcurementBasisCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductProcurementBasisCode2) || !string.IsNullOrEmpty(subject.ProductProcurementBasisCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.ProductProcurementBasisCode2 = "8";
			subject.UnitOrBasisForMeasurementCode2 = "zF";
		}
		if(!string.IsNullOrEmpty(subject.ProductProcurementBasisCode3) || !string.IsNullOrEmpty(subject.ProductProcurementBasisCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.ProductProcurementBasisCode3 = "I";
			subject.UnitOrBasisForMeasurementCode3 = "zt";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("OZ", true)]
	public void Validation_RequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new C066_SellingOrOrderingProductBasisCode();
		//Required fields
		subject.ProductProcurementBasisCode = "m";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductProcurementBasisCode2) || !string.IsNullOrEmpty(subject.ProductProcurementBasisCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.ProductProcurementBasisCode2 = "8";
			subject.UnitOrBasisForMeasurementCode2 = "zF";
		}
		if(!string.IsNullOrEmpty(subject.ProductProcurementBasisCode3) || !string.IsNullOrEmpty(subject.ProductProcurementBasisCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.ProductProcurementBasisCode3 = "I";
			subject.UnitOrBasisForMeasurementCode3 = "zt";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8", "zF", true)]
	[InlineData("8", "", false)]
	[InlineData("", "zF", false)]
	public void Validation_AllAreRequiredProductProcurementBasisCode2(string productProcurementBasisCode2, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new C066_SellingOrOrderingProductBasisCode();
		//Required fields
		subject.ProductProcurementBasisCode = "m";
		subject.UnitOrBasisForMeasurementCode = "OZ";
		//Test Parameters
		subject.ProductProcurementBasisCode2 = productProcurementBasisCode2;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductProcurementBasisCode3) || !string.IsNullOrEmpty(subject.ProductProcurementBasisCode3) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode3))
		{
			subject.ProductProcurementBasisCode3 = "I";
			subject.UnitOrBasisForMeasurementCode3 = "zt";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("I", "zt", true)]
	[InlineData("I", "", false)]
	[InlineData("", "zt", false)]
	public void Validation_AllAreRequiredProductProcurementBasisCode3(string productProcurementBasisCode3, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new C066_SellingOrOrderingProductBasisCode();
		//Required fields
		subject.ProductProcurementBasisCode = "m";
		subject.UnitOrBasisForMeasurementCode = "OZ";
		//Test Parameters
		subject.ProductProcurementBasisCode3 = productProcurementBasisCode3;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductProcurementBasisCode2) || !string.IsNullOrEmpty(subject.ProductProcurementBasisCode2) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode2))
		{
			subject.ProductProcurementBasisCode2 = "8";
			subject.UnitOrBasisForMeasurementCode2 = "zF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
