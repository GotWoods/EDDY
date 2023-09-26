using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class SV3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV3**3*9**g*8*R*G*S*G*";

		var expected = new SV3_DentalService()
		{
			CompositeMedicalProcedureIdentifier = null,
			MonetaryAmount = 3,
			FacilityCodeValue = "9",
			OralCavityDesignation = null,
			ProsthesisCrownOrInlayCode = "g",
			Quantity = 8,
			Description = "R",
			CopayStatusCode = "G",
			ProviderAgreementCode = "S",
			YesNoConditionOrResponseCode = "G",
			CompositeDiagnosisCodePointer = null,
		};

		var actual = Map.MapObject<SV3_DentalService>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredCompositeMedicalProcedureIdentifier(string compositeMedicalProcedureIdentifier, bool isValidExpected)
	{
		var subject = new SV3_DentalService();
		//Required fields
		//Test Parameters
		if (compositeMedicalProcedureIdentifier != "") 
			subject.CompositeMedicalProcedureIdentifier = new C003_CompositeMedicalProcedureIdentifier();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
