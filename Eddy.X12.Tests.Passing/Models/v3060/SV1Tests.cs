using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class SV1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV1**2*w6*8*b*c**4*S*c*d*k*O*S*C*r*B*ydn*8*p*z";

		var expected = new SV1_ProfessionalService()
		{
			CompositeMedicalProcedureIdentifier = null,
			MonetaryAmount = 2,
			UnitOrBasisForMeasurementCode = "w6",
			Quantity = 8,
			FacilityCodeValue = "b",
			ServiceTypeCode = "c",
			CompositeDiagnosisCodePointer = null,
			MonetaryAmount2 = 4,
			YesNoConditionOrResponseCode = "S",
			MultipleProcedureCode = "c",
			YesNoConditionOrResponseCode2 = "d",
			YesNoConditionOrResponseCode3 = "k",
			ReviewCode = "O",
			NationalOrLocalAssignedReviewValue = "S",
			CopayStatusCode = "C",
			HealthCareProfessionalShortageAreaCode = "r",
			ReferenceIdentification = "B",
			PostalCode = "ydn",
			MonetaryAmount3 = 8,
			LevelOfCareCode = "p",
			ProviderAgreementCode = "z",
		};

		var actual = Map.MapObject<SV1_ProfessionalService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredCompositeMedicalProcedureIdentifier(string compositeMedicalProcedureIdentifier, bool isValidExpected)
	{
		var subject = new SV1_ProfessionalService();
		//Required fields
		//Test Parameters
		if (compositeMedicalProcedureIdentifier != "") 
			subject.CompositeMedicalProcedureIdentifier = new C003_CompositeMedicalProcedureIdentifier();
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || !string.IsNullOrEmpty(subject.UnitOrBasisForMeasurementCode) || subject.Quantity > 0)
		{
			subject.UnitOrBasisForMeasurementCode = "w6";
			subject.Quantity = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("w6", 8, true)]
	[InlineData("w6", 0, false)]
	[InlineData("", 8, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new SV1_ProfessionalService();
		//Required fields
		subject.CompositeMedicalProcedureIdentifier = new C003_CompositeMedicalProcedureIdentifier();
		//Test Parameters
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0) 
			subject.Quantity = quantity;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
