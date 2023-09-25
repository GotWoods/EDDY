using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6010;

namespace Eddy.x12.Tests.Models.v6010;

public class SV1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV1**9*Aa*4*p*x*7*3*M*9*K*o*q*C*7*9*p*9zA*1*t*w";

		var expected = new SV1_ProfessionalService()
		{
			CompositeMedicalProcedureIdentifier = null,
			MonetaryAmount = 9,
			UnitOrBasisForMeasurementCode = "Aa",
			Quantity = 4,
			FacilityCodeValue = "p",
			IndustryCode = "x",
			DiagnosisCodePointer = 7,
			MonetaryAmount2 = 3,
			YesNoConditionOrResponseCode = "M",
			MultipleProcedureCode = "9",
			YesNoConditionOrResponseCode2 = "K",
			YesNoConditionOrResponseCode3 = "o",
			ReviewCode = "q",
			NationalOrLocalAssignedReviewValue = "C",
			CopayStatusCode = "7",
			HealthCareProfessionalShortageAreaCode = "9",
			ReferenceIdentification = "p",
			PostalCode = "9zA",
			MonetaryAmount3 = 1,
			LevelOfCareCode = "t",
			ProviderAgreementCode = "w",
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
			subject.UnitOrBasisForMeasurementCode = "Aa";
			subject.Quantity = 4;
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, true)]
	[InlineData("Aa", 4, true)]
	[InlineData("Aa", 0, false)]
	[InlineData("", 4, false)]
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
