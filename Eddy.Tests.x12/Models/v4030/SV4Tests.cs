using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class SV4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV4*3**a*6*o*T*w*p*U*o*6*s*K*RP*j*G*V*N";

		var expected = new SV4_DrugService()
		{
			ReferenceIdentification = "3",
			CompositeMedicalProcedureIdentifier = null,
			ReferenceIdentification2 = "a",
			YesNoConditionOrResponseCode = "6",
			DispenseAsWrittenCode = "o",
			LevelOfServiceCode = "T",
			PrescriptionOriginCode = "w",
			Description = "p",
			YesNoConditionOrResponseCode2 = "U",
			YesNoConditionOrResponseCode3 = "o",
			UnitDoseCode = "6",
			BasisOfCostDeterminationCode = "s",
			BasisOfDaysSupplyDeterminationCode = "K",
			DosageFormCode = "RP",
			CopayStatusCode = "j",
			PatientLocationCode = "G",
			LevelOfCareCode = "V",
			PriorAuthorizationTypeCode = "N",
		};

		var actual = Map.MapObject<SV4_DrugService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("3", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new SV4_DrugService();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
