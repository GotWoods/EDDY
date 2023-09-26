using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class HCPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HCP*1J*5*4*f*3*T*9*1*kV*7*KG*2*Wz*K*G";

		var expected = new HCP_HealthCarePricing()
		{
			PricingMethodologyCode = "1J",
			MonetaryAmount = 5,
			MonetaryAmount2 = 4,
			ReferenceIdentification = "f",
			Rate = 3,
			ReferenceIdentification2 = "T",
			MonetaryAmount3 = 9,
			ProductServiceID = "1",
			ProductServiceIDQualifier = "kV",
			ProductServiceID2 = "7",
			UnitOrBasisForMeasurementCode = "KG",
			Quantity = 2,
			RejectReasonCode = "Wz",
			PolicyComplianceCode = "K",
			ExceptionCode = "G",
		};

		var actual = Map.MapObject<HCP_HealthCarePricing>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", false)]
	[InlineData("1J", "Wz", true)]
	[InlineData("1J", "", true)]
	[InlineData("", "Wz", true)]
	public void Validation_AtLeastOnePricingMethodologyCode(string pricingMethodologyCode, string rejectReasonCode, bool isValidExpected)
	{
		var subject = new HCP_HealthCarePricing();
		//Required fields
		//Test Parameters
		subject.PricingMethodologyCode = pricingMethodologyCode;
		subject.RejectReasonCode = rejectReasonCode;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier = "kV";
			subject.ProductServiceID2 = "7";
		}
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "KG";
			subject.Quantity = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("kV", "7", true)]
	[InlineData("kV", "", false)]
	[InlineData("", "7", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID2, bool isValidExpected)
	{
		var subject = new HCP_HealthCarePricing();
		//Required fields
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID2 = productServiceID2;
		//At Least one
		subject.PricingMethodologyCode = "1J";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "KG";
			subject.Quantity = 2;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("KG", 2, true)]
	[InlineData("KG", 0, false)]
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
		subject.PricingMethodologyCode = "1J";
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceIDQualifier) || !string.IsNullOrEmpty(subject.ProductServiceID2))
		{
			subject.ProductServiceIDQualifier = "kV";
			subject.ProductServiceID2 = "7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
