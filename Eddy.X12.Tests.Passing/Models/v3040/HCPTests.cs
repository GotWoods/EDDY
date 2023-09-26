using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class HCPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HCP*hp*4*9*x*8*E*5*2*x8*2*7m*4*e8";

		var expected = new HCP_HealthCarePricing()
		{
			PricingMethodology = "hp",
			MonetaryAmount = 4,
			MonetaryAmount2 = 9,
			ReferenceNumber = "x",
			Rate = 8,
			ReferenceNumber2 = "E",
			MonetaryAmount3 = 5,
			ProductServiceID = "2",
			ProductServiceIDQualifier = "x8",
			ProductServiceID2 = "2",
			UnitOrBasisForMeasurementCode = "7m",
			Quantity = 4,
			RejectReasonCode = "e8",
		};

		var actual = Map.MapObject<HCP_HealthCarePricing>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("hp", true)]
	public void Validation_RequiredPricingMethodology(string pricingMethodology, bool isValidExpected)
	{
		var subject = new HCP_HealthCarePricing();
		//Required fields
		subject.MonetaryAmount = 4;
		//Test Parameters
		subject.PricingMethodology = pricingMethodology;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier = "x8";
			subject.ProductServiceID2 = "2";
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "7m";
			subject.Quantity = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new HCP_HealthCarePricing();
		//Required fields
		subject.PricingMethodology = "hp";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier = "x8";
			subject.ProductServiceID2 = "2";
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "7m";
			subject.Quantity = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("x8", "2", true)]
	[InlineData("x8", "", false)]
	[InlineData("", "2", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID2, bool isValidExpected)
	{
		var subject = new HCP_HealthCarePricing();
		//Required fields
		subject.PricingMethodology = "hp";
		subject.MonetaryAmount = 4;
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID2 = productServiceID2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "7m";
			subject.Quantity = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("7m", 4, true)]
	[InlineData("7m", 0, false)]
	[InlineData("", 4, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new HCP_HealthCarePricing();
		//Required fields
		subject.PricingMethodology = "hp";
		subject.MonetaryAmount = 4;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier = "x8";
			subject.ProductServiceID2 = "2";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
