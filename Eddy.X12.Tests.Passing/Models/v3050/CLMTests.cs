using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class CLMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CLM*G*3*p*G**D*s*n*h*A**Ht*e*S*B*M*u*c*Gf*4";

		var expected = new CLM_HealthClaim()
		{
			ClaimSubmittersIdentifier = "G",
			MonetaryAmount = 3,
			ClaimFilingIndicatorCode = "p",
			NonInstitutionalClaimTypeCode = "G",
			HealthCareServiceLocationInformation = null,
			YesNoConditionOrResponseCode = "D",
			ProviderAcceptAssignmentCode = "s",
			YesNoConditionOrResponseCode2 = "n",
			ReleaseOfInformationCode = "h",
			PatientSignatureSourceCode = "A",
			RelatedCausesInformation = null,
			SpecialProgramCode = "Ht",
			YesNoConditionOrResponseCode3 = "e",
			LevelOfServiceCode = "S",
			YesNoConditionOrResponseCode4 = "B",
			ProviderAgreementCode = "M",
			ClaimStatusCode = "u",
			YesNoConditionOrResponseCode5 = "c",
			ClaimSubmissionReasonCode = "Gf",
			DelayReasonCode = "4",
		};

		var actual = Map.MapObject<CLM_HealthClaim>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("G", true)]
	public void Validation_RequiredClaimSubmittersIdentifier(string claimSubmittersIdentifier, bool isValidExpected)
	{
		var subject = new CLM_HealthClaim();
		//Required fields
		//Test Parameters
		subject.ClaimSubmittersIdentifier = claimSubmittersIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
