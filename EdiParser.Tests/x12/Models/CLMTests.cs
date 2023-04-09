using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;
using EdiParser.x12.Models.Elements;

namespace EdiParser.Tests.x12.Models;

public class CLMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CLM*U*7*4*g**s*7*M*y*c**bj*d*f*K*W*P*U*4Z*f*H";

		var expected = new CLM_HealthClaim()
		{
			ClaimSubmittersIdentifier = "U",
			MonetaryAmount = 7,
			ClaimFilingIndicatorCode = "4",
			NonInstitutionalClaimTypeCode = "g",
			HealthCareServiceLocationInformation = new C023_HealthCareServiceLocationInformation() {},
			YesNoConditionOrResponseCode = "s",
			ProviderAcceptAssignmentCode = "7",
			YesNoConditionOrResponseCode2 = "M",
			ReleaseOfInformationCode = "y",
			PatientSignatureSourceCode = "c",
			RelatedCausesInformation = new C024_RelatedCausesInformation() {},
			SpecialProgramCode = "bj",
			YesNoConditionOrResponseCode3 = "d",
			LevelOfServiceCode = "f",
			YesNoConditionOrResponseCode4 = "K",
			ProviderAgreementCode = "W",
			ClaimStatusCode = "P",
			YesNoConditionOrResponseCode5 = "U",
			ClaimSubmissionReasonCode = "4Z",
			DelayReasonCode = "f",
			ClaimAuthorizationExceptionCode = "H",
		};

		var actual = Map.MapObject<CLM_HealthClaim>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		try
		{
			Assert.Equivalent(expected, actual);
		}
		catch
		{
			Assert.Fail(actual.ValidationResult.ToString());
		}
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("U", true)]
	public void Validatation_RequiredClaimSubmittersIdentifier(string claimSubmittersIdentifier, bool isValidExpected)
	{
		var subject = new CLM_HealthClaim();
		subject.ClaimSubmittersIdentifier = claimSubmittersIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
