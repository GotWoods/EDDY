using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class HCPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HCP*9R*6*1*S*9*p*4*o*SG*J*1M*2*yb*O*x";

		var expected = new HCP_HealthCarePricing()
		{
			PricingMethodology = "9R",
			MonetaryAmount = 6,
			MonetaryAmount2 = 1,
			ReferenceIdentification = "S",
			Rate = 9,
			ReferenceIdentification2 = "p",
			MonetaryAmount3 = 4,
			ProductServiceID = "o",
			ProductServiceIDQualifier = "SG",
			ProductServiceID2 = "J",
			UnitOrBasisForMeasurementCode = "1M",
			Quantity = 2,
			RejectReasonCode = "yb",
			PolicyComplianceCode = "O",
			ExceptionCode = "x",
		};

		var actual = Map.MapObject<HCP_HealthCarePricing>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("9R", "yb", true)]
	[InlineData("9R", "", true)]
	[InlineData("", "yb", true)]
	public void Validation_AtLeastOnePricingMethodology(string pricingMethodology, string rejectReasonCode, bool isValidExpected)
	{
		var subject = new HCP_HealthCarePricing();
		//Required fields
		//Test Parameters
		subject.PricingMethodology = pricingMethodology;
		subject.RejectReasonCode = rejectReasonCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier = "SG";
			subject.ProductServiceID2 = "J";
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "1M";
			subject.Quantity = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("SG", "J", true)]
	[InlineData("SG", "", false)]
	[InlineData("", "J", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID2, bool isValidExpected)
	{
		var subject = new HCP_HealthCarePricing();
		//Required fields
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID2 = productServiceID2;
		//At Least one
		subject.PricingMethodology = "9R";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "1M";
			subject.Quantity = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("1M", 2, true)]
	[InlineData("1M", 0, false)]
	[InlineData("", 2, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new HCP_HealthCarePricing();
		//Required fields
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//At Least one
		subject.PricingMethodology = "9R";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier = "SG";
			subject.ProductServiceID2 = "J";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
