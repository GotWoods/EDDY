using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class HCPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HCP*h1*7*3*p*6*3*5*t*XQ*G*DT*9*8z*s*v";

		var expected = new HCP_HealthCarePricing()
		{
			PricingMethodology = "h1",
			MonetaryAmount = 7,
			MonetaryAmount2 = 3,
			ReferenceIdentification = "p",
			Rate = 6,
			ReferenceIdentification2 = "3",
			MonetaryAmount3 = 5,
			ProductServiceID = "t",
			ProductServiceIDQualifier = "XQ",
			ProductServiceID2 = "G",
			UnitOrBasisForMeasurementCode = "DT",
			Quantity = 9,
			RejectReasonCode = "8z",
			PolicyComplianceCode = "s",
			ExceptionCode = "v",
		};

		var actual = Map.MapObject<HCP_HealthCarePricing>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("h1", "8z", true)]
	[InlineData("h1", "", true)]
	[InlineData("", "8z", true)]
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
			subject.ProductServiceIDQualifier = "XQ";
			subject.ProductServiceID2 = "G";
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "DT";
			subject.Quantity = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("XQ", "G", true)]
	[InlineData("XQ", "", false)]
	[InlineData("", "G", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID2, bool isValidExpected)
	{
		var subject = new HCP_HealthCarePricing();
		//Required fields
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID2 = productServiceID2;
		//At Least one
		subject.PricingMethodology = "h1";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "DT";
			subject.Quantity = 9;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("DT", 9, true)]
	[InlineData("DT", 0, false)]
	[InlineData("", 9, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new HCP_HealthCarePricing();
		//Required fields
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		//At Least one
		subject.PricingMethodology = "h1";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier = "XQ";
			subject.ProductServiceID2 = "G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
