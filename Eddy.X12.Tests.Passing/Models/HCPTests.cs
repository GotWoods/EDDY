using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class HCPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HCP*V9*8*8*q*1*g*2*L*Ac*Y*9l*4*qX*J*f";

		var expected = new HCP_HealthCarePricing()
		{
			PricingMethodologyCode = "V9",
			MonetaryAmount = 8,
			MonetaryAmount2 = 8,
			ReferenceIdentification = "q",
			Rate = 1,
			ReferenceIdentification2 = "g",
			MonetaryAmount3 = 2,
			ProductServiceID = "L",
			ProductServiceIDQualifier = "Ac",
			ProductServiceID2 = "Y",
			UnitOrBasisForMeasurementCode = "9l",
			Quantity = 4,
			RejectReasonCode = "qX",
			PolicyComplianceCode = "J",
			ExceptionCode = "f",
		};

		var actual = Map.MapObject<HCP_HealthCarePricing>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", false)]
	[InlineData("V9","qX", true)]
	[InlineData("", "qX", true)]
	[InlineData("V9", "", true)]
	public void Validation_AtLeastOnePricingMethodologyCode(string pricingMethodologyCode, string rejectReasonCode, bool isValidExpected)
	{
		var subject = new HCP_HealthCarePricing();
		subject.PricingMethodologyCode = pricingMethodologyCode;
		subject.RejectReasonCode = rejectReasonCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("Ac", "Y", true)]
	[InlineData("", "Y", false)]
	[InlineData("Ac", "", false)]
	public void Validation_AllAreRequiredProductServiceIDQualifier(string productServiceIDQualifier, string productServiceID2, bool isValidExpected)
	{
		var subject = new HCP_HealthCarePricing();
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		subject.ProductServiceID2 = productServiceID2;
		subject.PricingMethodologyCode = "AA";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("9l", 4, true)]
	[InlineData("", 4, false)]
	[InlineData("9l", 0, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new HCP_HealthCarePricing();
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0)
		subject.Quantity = quantity;
        subject.PricingMethodologyCode = "AA";
        TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
