using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.Tests.Models.v8010;

public class SV4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV4*r**T*x*Q*K*x*2*6*p*q*4*G*0b*L*m*D*q*H*E*f*Os*2*3";

		var expected = new SV4_DrugService()
		{
			ReferenceIdentification = "r",
			CompositeMedicalProcedureIdentifier = null,
			ReferenceIdentification2 = "T",
			YesNoConditionOrResponseCode = "x",
			DispenseAsWrittenCode = "Q",
			LevelOfServiceCode = "K",
			PrescriptionOriginCode = "x",
			Description = "2",
			YesNoConditionOrResponseCode2 = "6",
			YesNoConditionOrResponseCode3 = "p",
			UnitDoseCode = "q",
			BasisOfCostDeterminationCode = "4",
			BasisOfDaysSupplyDeterminationCode = "G",
			DosageFormCode = "0b",
			CopayStatusCode = "L",
			PatientLocationCode = "m",
			LevelOfCareCode = "D",
			PriorAuthorizationTypeCode = "q",
			SubmissionClarificationCode = "H",
			AdditionalDrugCoverageCode = "E",
			CompoundRouteOfAdministrationCode = "f",
			SubmittedDrugTaxCode = "Os",
			PercentageAsDecimal = 2,
			MonetaryAmount = 3,
		};

		var actual = Map.MapObject<SV4_DrugService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("r", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new SV4_DrugService();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
