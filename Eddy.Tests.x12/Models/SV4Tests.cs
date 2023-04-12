using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SV4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV4*D**h*7*t*U*o*m*9*j*s*Y*L*rN*b*d*6*V*N*n*F*Ol*8*6";

		var expected = new SV4_DrugService()
		{
			ReferenceIdentification = "D",
			CompositeMedicalProcedureIdentifier = "",
			ReferenceIdentification2 = "h",
			YesNoConditionOrResponseCode = "7",
			DispenseAsWrittenCode = "t",
			LevelOfServiceCode = "U",
			PrescriptionOriginCode = "o",
			Description = "m",
			YesNoConditionOrResponseCode2 = "9",
			YesNoConditionOrResponseCode3 = "j",
			UnitDoseCode = "s",
			BasisOfCostDeterminationCode = "Y",
			BasisOfDaysSupplyDeterminationCode = "L",
			DosageFormCode = "rN",
			CopayStatusCode = "b",
			PatientLocationCode = "d",
			LevelOfCareCode = "6",
			PriorAuthorizationTypeCode = "V",
			SubmissionClarificationCode = "N",
			AdditionalDrugCoverageCode = "n",
			CompoundRouteOfAdministrationCode = "F",
			SubmittedDrugTaxCode = "Ol",
			PercentageAsDecimal = 8,
			MonetaryAmount = 6,
		};

		var actual = Map.MapObject<SV4_DrugService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("D", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new SV4_DrugService();
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
