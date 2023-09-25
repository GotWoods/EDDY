using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class SV4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV4*T**J*p*o*n*r*k*M*2*t*e*5*r5*X*G*d*3";

		var expected = new SV4_DrugService()
		{
			ReferenceIdentification = "T",
			CompositeMedicalProcedureIdentifier = null,
			ReferenceIdentification2 = "J",
			YesNoConditionOrResponseCode = "p",
			DispenseAsWrittenCode = "o",
			LevelOfServiceCode = "n",
			PrescriptionOriginCode = "r",
			Description = "k",
			YesNoConditionOrResponseCode2 = "M",
			YesNoConditionOrResponseCode3 = "2",
			UnitDoseCode = "t",
			BasisOfCostDeterminationCode = "e",
			BasisOfDaysSupplyDeterminationCode = "5",
			DosageFormCode = "r5",
			CopayStatusCode = "X",
			PatientLocationCode = "G",
			LevelOfCareCode = "d",
			PriorAuthorizationTypeCode = "3",
		};

		var actual = Map.MapObject<SV4_DrugService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new SV4_DrugService();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
