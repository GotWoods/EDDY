using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.Tests.Models.v5050;

public class SV1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV1**3*2l*1*0*n*7*9*n*V*s*R*Z*1*9*G*Q*too*4*h*x";

		var expected = new SV1_ProfessionalService()
		{
			CompositeMedicalProcedureIdentifier = null,
			MonetaryAmount = 3,
			UnitOrBasisForMeasurementCode = "2l",
			Quantity = 1,
			FacilityCodeValue = "0",
			ServiceTypeCode = "n",
			DiagnosisCodePointer = 7,
			MonetaryAmount2 = 9,
			YesNoConditionOrResponseCode = "n",
			MultipleProcedureCode = "V",
			YesNoConditionOrResponseCode2 = "s",
			YesNoConditionOrResponseCode3 = "R",
			ReviewCode = "Z",
			NationalOrLocalAssignedReviewValue = "1",
			CopayStatusCode = "9",
			HealthCareProfessionalShortageAreaCode = "G",
			ReferenceIdentification = "Q",
			PostalCode = "too",
			MonetaryAmount3 = 4,
			LevelOfCareCode = "h",
			ProviderAgreementCode = "x",
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
			subject.UnitOrBasisForMeasurementCode = "2l";
			subject.Quantity = 1;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("2l", 1, true)]
	[InlineData("2l", 0, false)]
	[InlineData("", 1, false)]
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
