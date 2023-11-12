using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.v3060.Composites;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class SV3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SV3**9*L**0*3*Y*j*A*n*";

		var expected = new SV3_DentalService()
		{
			CompositeMedicalProcedureIdentifier = null,
			MonetaryAmount = 9,
			FacilityCodeValue = "L",
			OralCavityDesignation = null,
			ProsthesisCrownOrInlayCode = "0",
			Quantity = 3,
			Description = "Y",
			CopayStatusCode = "j",
			ProviderAgreementCode = "A",
			YesNoConditionOrResponseCode = "n",
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
