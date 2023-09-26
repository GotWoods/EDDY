using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.Tests.Models.v5050;

public class SV4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV4*9**b*1*V*C*h*e*g*x*q*0*y*FC*x*p*u*i*0*f*3*GV*1*2";

		var expected = new SV4_DrugService()
		{
			ReferenceIdentification = "9",
			CompositeMedicalProcedureIdentifier = null,
			ReferenceIdentification2 = "b",
			YesNoConditionOrResponseCode = "1",
			DispenseAsWrittenCode = "V",
			LevelOfServiceCode = "C",
			PrescriptionOriginCode = "h",
			Description = "e",
			YesNoConditionOrResponseCode2 = "g",
			YesNoConditionOrResponseCode3 = "x",
			UnitDoseCode = "q",
			BasisOfCostDeterminationCode = "0",
			BasisOfDaysSupplyDeterminationCode = "y",
			DosageFormCode = "FC",
			CopayStatusCode = "x",
			PatientLocationCode = "p",
			LevelOfCareCode = "u",
			PriorAuthorizationTypeCode = "i",
			SubmissionClarificationCode = "0",
			AdditionalDrugCoverageCode = "f",
			CompoundRouteOfAdministrationCode = "3",
			SubmittedDrugSalesTaxCode = "GV",
			PercentageAsDecimal = 1,
			MonetaryAmount = 2,
		};

		var actual = Map.MapObject<SV4_DrugService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new SV4_DrugService();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
