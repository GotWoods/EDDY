using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class SV4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV4*e**P*X*u*0*c*B*5*I*U*H*2*Rx*1*L*9*C";

		var expected = new SV4_DrugService()
		{
			ReferenceNumber = "e",
			CompositeMedicalProcedureIdentifier = null,
			ReferenceNumber2 = "P",
			YesNoConditionOrResponseCode = "X",
			DispenseAsWrittenCode = "u",
			LevelOfServiceCode = "0",
			PrescriptionOriginCode = "c",
			Description = "B",
			YesNoConditionOrResponseCode2 = "5",
			YesNoConditionOrResponseCode3 = "I",
			UnitDoseCode = "U",
			BasisOfCostDeterminationCode = "H",
			BasisOfDaysSupplyDeterminationCode = "2",
			DosageFormCode = "Rx",
			CopayStatusCode = "1",
			PatientLocationCode = "L",
			LevelOfCareCode = "9",
			PriorAuthorizationTypeCode = "C",
		};

		var actual = Map.MapObject<SV4_DrugService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredReferenceNumber(string referenceNumber, bool isValidExpected)
	{
		var subject = new SV4_DrugService();
		//Required fields
		//Test Parameters
		subject.ReferenceNumber = referenceNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
