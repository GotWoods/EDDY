using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class HCPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HCP*Yc*5*8*r*3*R*2*k*wp*X*UE*2*2F*Q*e";

		var expected = new HCP_HealthCarePricing()
		{
			PricingMethodology = "Yc",
			MonetaryAmount = 5,
			MonetaryAmount2 = 8,
			ReferenceIdentification = "r",
			Rate = 3,
			ReferenceIdentification2 = "R",
			MonetaryAmount3 = 2,
			ProductServiceID = "k",
			ProductServiceIDQualifier = "wp",
			ProductServiceID2 = "X",
			UnitOrBasisForMeasurementCode = "UE",
			Quantity = 2,
			RejectReasonCode = "2F",
			PolicyComplianceCode = "Q",
			ExceptionCode = "e",
		};

		var actual = Map.MapObject<HCP_HealthCarePricing>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Yc", true)]
	public void Validation_RequiredPricingMethodology(string pricingMethodology, bool isValidExpected)
	{
		var subject = new HCP_HealthCarePricing();
		//Required fields
		subject.MonetaryAmount = 5;
		//Test Parameters
		subject.PricingMethodology = pricingMethodology;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier = "wp";
			subject.ProductServiceID2 = "X";
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "UE";
			subject.Quantity = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredMonetaryAmount(decimal monetaryAmount, bool isValidExpected)
	{
		var subject = new HCP_HealthCarePricing();
		//Required fields
		subject.PricingMethodology = "Yc";
		//Test Parameters
		if (monetaryAmount > 0) 
			subject.MonetaryAmount = monetaryAmount;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier = "wp";
			subject.ProductServiceID2 = "X";
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "UE";
			subject.Quantity = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("wp", "X", true)]
	[InlineData("wp", "", false)]
	[InlineData("", "X", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID2, bool isValidExpected)
	{
		var subject = new HCP_HealthCarePricing();
		//Required fields
		subject.PricingMethodology = "Yc";
		subject.MonetaryAmount = 5;
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID2 = productServiceID2;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "UE";
			subject.Quantity = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("UE", 2, true)]
	[InlineData("UE", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new HCP_HealthCarePricing();
		//Required fields
		subject.PricingMethodology = "Yc";
		subject.MonetaryAmount = 5;
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier = "wp";
			subject.ProductServiceID2 = "X";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
