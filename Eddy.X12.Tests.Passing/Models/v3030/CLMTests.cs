using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class CLMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CLM*N*1*q*2*W*V*T*f*8*h*V*1*HE*un*KJ*8w*G2*3L*m*v*I*I*N*I*1r";

		var expected = new CLM_HealthClaim()
		{
			ClaimSubmittersIdentifier = "N",
			MonetaryAmount = 1,
			ClaimFilingIndicatorCode = "q",
			NonInstitutionalClaimTypeCode = "2",
			FacilityCodeQualifier = "W",
			FacilityCode = "V",
			ClaimFrequencyTypeCode = "T",
			YesNoConditionOrResponseCode = "f",
			ProviderAcceptAssignmentCode = "8",
			YesNoConditionOrResponseCode2 = "h",
			ReleaseOfInformationCode = "V",
			PatientSignatureSourceCode = "1",
			RelatedCausesCode = "HE",
			RelatedCausesCode2 = "un",
			RelatedCausesCode3 = "KJ",
			StateOrProvinceCode = "8w",
			CountryCode = "G2",
			SpecialProgramCode = "3L",
			YesNoConditionOrResponseCode3 = "m",
			LevelOfServiceCode = "v",
			YesNoConditionOrResponseCode4 = "I",
			ProviderAgreementCode = "I",
			ClaimStatusCode = "N",
			YesNoConditionOrResponseCode5 = "I",
			ClaimSubmissionReasonCode = "1r",
		};

		var actual = Map.MapObject<CLM_HealthClaim>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredClaimSubmittersIdentifier(string claimSubmittersIdentifier, bool isValidExpected)
	{
		var subject = new CLM_HealthClaim();
		//Required fields
		//Test Parameters
		subject.ClaimSubmittersIdentifier = claimSubmittersIdentifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FacilityCodeQualifier) || !string.IsNullOrEmpty(subject.FacilityCodeQualifier) || !string.IsNullOrEmpty(subject.FacilityCode))
		{
			subject.FacilityCodeQualifier = "W";
			subject.FacilityCode = "V";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("W", "V", true)]
	[InlineData("W", "", false)]
	[InlineData("", "V", false)]
	public void Validation_AllAreRequiredFacilityCodeQualifier(string facilityCodeQualifier, string facilityCode, bool isValidExpected)
	{
		var subject = new CLM_HealthClaim();
		//Required fields
		subject.ClaimSubmittersIdentifier = "N";
		//Test Parameters
		subject.FacilityCodeQualifier = facilityCodeQualifier;
		subject.FacilityCode = facilityCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
