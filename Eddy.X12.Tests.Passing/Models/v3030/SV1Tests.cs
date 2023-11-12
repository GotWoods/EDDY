using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SV1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV1*9H*o*5*tf*1*p*8*2*cB*7*br*zH*u*1*8*k*d*7*0*e*C*8*m*JUH*4*D*w";

		var expected = new SV1_ProfessionalService()
		{
			ProductServiceIDQualifier = "9H",
			ProductServiceID = "o",
			MonetaryAmount = 5,
			UnitOrBasisForMeasurementCode = "tf",
			Quantity = 1,
			FacilityCode = "p",
			ServiceTypeCode = "8",
			DiagnosisCodePointer = 2,
			ProcedureModifier = "cB",
			DiagnosisCodePointer2 = 7,
			ProcedureModifier2 = "br",
			ProcedureModifier3 = "zH",
			Description = "u",
			MonetaryAmount2 = 1,
			YesNoConditionOrResponseCode = "8",
			MultipleProcedureCode = "k",
			YesNoConditionOrResponseCode2 = "d",
			YesNoConditionOrResponseCode3 = "7",
			ReviewCode = "0",
			NationalOrLocalAssignedReviewValue = "e",
			CopayStatusCode = "C",
			HealthcareManpowerShortageAreaCode = "8",
			ReferenceNumber = "m",
			PostalCode = "JUH",
			MonetaryAmount3 = 4,
			LevelOfCareCode = "D",
			ProviderAgreementCode = "w",
		};

		var actual = Map.MapObject<SV1_ProfessionalService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9H", true)]
	public void Validation_RequiredProductServiceIDQualifier(string productServiceIDQualifier, bool isValidExpected)
	{
		var subject = new SV1_ProfessionalService();
		//Required fields
		subject.ProductServiceID = "o";
		//Test Parameters
		subject.ProductServiceIDQualifier = productServiceIDQualifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "tf";
			subject.Quantity = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredProductServiceID(string productServiceID, bool isValidExpected)
	{
		var subject = new SV1_ProfessionalService();
		//Required fields
		subject.ProductServiceIDQualifier = "9H";
		//Test Parameters
		subject.ProductServiceID = productServiceID;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "tf";
			subject.Quantity = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("tf", 1, true)]
	[InlineData("tf", 0, false)]
	[InlineData("", 1, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new SV1_ProfessionalService();
		//Required fields
		subject.ProductServiceIDQualifier = "9H";
		subject.ProductServiceID = "o";
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
