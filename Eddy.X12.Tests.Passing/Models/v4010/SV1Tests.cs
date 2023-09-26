using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class SV1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV1**5*z9*8*Y*W**7*Q*C*G*G*2*K*l*h*l*m1F*5*X*f";

		var expected = new SV1_ProfessionalService()
		{
			CompositeMedicalProcedureIdentifier = null,
			MonetaryAmount = 5,
			UnitOrBasisForMeasurementCode = "z9",
			Quantity = 8,
			FacilityCodeValue = "Y",
			ServiceTypeCode = "W",
			CompositeDiagnosisCodePointer = null,
			MonetaryAmount2 = 7,
			YesNoConditionOrResponseCode = "Q",
			MultipleProcedureCode = "C",
			YesNoConditionOrResponseCode2 = "G",
			YesNoConditionOrResponseCode3 = "G",
			ReviewCode = "2",
			NationalOrLocalAssignedReviewValue = "K",
			CopayStatusCode = "l",
			HealthCareProfessionalShortageAreaCode = "h",
			ReferenceIdentification = "l",
			PostalCode = "m1F",
			MonetaryAmount3 = 5,
			LevelOfCareCode = "X",
			ProviderAgreementCode = "f",
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
			subject.UnitOrBasisForMeasurementCode = "z9";
			subject.Quantity = 8;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("z9", 8, true)]
	[InlineData("z9", 0, false)]
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
