using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class SV1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV1**8*yt*8*j*t*7*3*h*v*L*5*b*2*8*f*b*meW*5*V*O";

		var expected = new SV1_ProfessionalService()
		{
			CompositeMedicalProcedureIdentifier = null,
			MonetaryAmount = 8,
			UnitOrBasisForMeasurementCode = "yt",
			Quantity = 8,
			FacilityCodeValue = "j",
			IndustryCode = "t",
			DiagnosisCodePointer = 7,
			MonetaryAmount2 = 3,
			YesNoConditionOrResponseCode = "h",
			MultipleProcedureCode = "v",
			YesNoConditionOrResponseCode2 = "L",
			YesNoConditionOrResponseCode3 = "5",
			ReviewCode = "b",
			NationalOrLocalAssignedReviewValue = "2",
			CopayStatusCode = "8",
			HealthCareProfessionalShortageAreaCode = "f",
			ReferenceIdentification = "b",
			PostalCode = "meW",
			MonetaryAmount3 = 5,
			LevelOfCareCode = "V",
			ProviderAgreementCode = "O",
		};

		var actual = Map.MapObject<SV1_ProfessionalService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("", true)]
	public void Validation_RequiredCompositeMedicalProcedureIdentifier(C003_CompositeMedicalProcedureIdentifier compositeMedicalProcedureIdentifier, bool isValidExpected)
	{
		var subject = new SV1_ProfessionalService();
		subject.CompositeMedicalProcedureIdentifier = compositeMedicalProcedureIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("",0, true)]
	[InlineData("yt", 8, true)]
	[InlineData("", 8, false)]
	[InlineData("yt", 0, false)]
	public void Validation_AllAreRequiredUnitOrBasisForMeasurementCode(string unitOrBasisForMeasurementCode, decimal quantity, bool isValidExpected)
	{
		var subject = new SV1_ProfessionalService();
		subject.CompositeMedicalProcedureIdentifier = "";
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;
		if (quantity > 0)
		subject.Quantity = quantity;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
