using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.Tests.Models.v7010;

public class CLMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CLM*T*8*n*n**i*5*U*2*g**JM*Y*5*h*Z*H*8*GE*m*h";

		var expected = new CLM_HealthClaim()
		{
			ClaimSubmittersIdentifier = "T",
			MonetaryAmount = 8,
			ClaimFilingIndicatorCode = "n",
			NonInstitutionalClaimTypeCode = "n",
			HealthCareServiceLocationInformation = null,
			YesNoConditionOrResponseCode = "i",
			ProviderAcceptAssignmentCode = "5",
			YesNoConditionOrResponseCode2 = "U",
			ReleaseOfInformationCode = "2",
			PatientSignatureSourceCode = "g",
			RelatedCausesInformation = null,
			SpecialProgramCode = "JM",
			YesNoConditionOrResponseCode3 = "Y",
			LevelOfServiceCode = "5",
			YesNoConditionOrResponseCode4 = "h",
			ProviderAgreementCode = "Z",
			ClaimStatusCode = "H",
			YesNoConditionOrResponseCode5 = "8",
			ClaimSubmissionReasonCode = "GE",
			DelayReasonCode = "m",
			ClaimAuthorizationExceptionCode = "h",
		};

		var actual = Map.MapObject<CLM_HealthClaim>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("T", true)]
	public void Validation_RequiredClaimSubmittersIdentifier(string claimSubmittersIdentifier, bool isValidExpected)
	{
		var subject = new CLM_HealthClaim();
		//Required fields
		//Test Parameters
		subject.ClaimSubmittersIdentifier = claimSubmittersIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
