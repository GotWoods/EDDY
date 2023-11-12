using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class SV4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV4*Z**9*I*9*r*Y*B*f*x*g*5*u*jE*w*p*x*V";

		var expected = new SV4_DrugService()
		{
			ReferenceIdentification = "Z",
			CompositeMedicalProcedureIdentifier = null,
			ReferenceIdentification2 = "9",
			YesNoConditionOrResponseCode = "I",
			DispenseAsWrittenCode = "9",
			LevelOfServiceCode = "r",
			PrescriptionOriginCode = "Y",
			Description = "B",
			YesNoConditionOrResponseCode2 = "f",
			YesNoConditionOrResponseCode3 = "x",
			UnitDoseCode = "g",
			BasisOfCostDeterminationCode = "5",
			BasisOfDaysSupplyDeterminationCode = "u",
			DosageFormCode = "jE",
			CopayStatusCode = "w",
			PatientLocationCode = "p",
			LevelOfCareCode = "x",
			PriorAuthorizationTypeCode = "V",
		};

		var actual = Map.MapObject<SV4_DrugService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new SV4_DrugService();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
