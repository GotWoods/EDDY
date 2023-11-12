using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class CLMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CLM*p*6*H*8**U*e*1*q*A**ba*o*c*W*d*s*D*zi*v";

		var expected = new CLM_HealthClaim()
		{
			ClaimSubmittersIdentifier = "p",
			MonetaryAmount = 6,
			ClaimFilingIndicatorCode = "H",
			NonInstitutionalClaimTypeCode = "8",
			HealthCareServiceLocationInformation = null,
			YesNoConditionOrResponseCode = "U",
			ProviderAcceptAssignmentCode = "e",
			YesNoConditionOrResponseCode2 = "1",
			ReleaseOfInformationCode = "q",
			PatientSignatureSourceCode = "A",
			RelatedCausesInformation = null,
			SpecialProgramCode = "ba",
			YesNoConditionOrResponseCode3 = "o",
			LevelOfServiceCode = "c",
			YesNoConditionOrResponseCode4 = "W",
			ProviderAgreementCode = "d",
			ClaimStatusCode = "s",
			YesNoConditionOrResponseCode5 = "D",
			ClaimSubmissionReasonCode = "zi",
			DelayReasonCode = "v",
		};

		var actual = Map.MapObject<CLM_HealthClaim>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredClaimSubmittersIdentifier(string claimSubmittersIdentifier, bool isValidExpected)
	{
		var subject = new CLM_HealthClaim();
		//Required fields
		//Test Parameters
		subject.ClaimSubmittersIdentifier = claimSubmittersIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
