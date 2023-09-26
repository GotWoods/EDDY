using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class CLMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CLM*V*3*t*r*N*j*L*5*Y*F*p*E*gr*fQ*UC*fi*jz*TI*r*h*m*F*T*3*Yv";

		var expected = new CLM_HealthClaim()
		{
			ClaimSubmittersIdentifier = "V",
			MonetaryAmount = 3,
			ClaimFilingIndicatorCode = "t",
			NonInstitutionalClaimTypeCode = "r",
			FacilityCodeQualifier = "N",
			FacilityCodeValue = "j",
			ClaimFrequencyTypeCode = "L",
			YesNoConditionOrResponseCode = "5",
			ProviderAcceptAssignmentCode = "Y",
			YesNoConditionOrResponseCode2 = "F",
			ReleaseOfInformationCode = "p",
			PatientSignatureSourceCode = "E",
			RelatedCausesCode = "gr",
			RelatedCausesCode2 = "fQ",
			RelatedCausesCode3 = "UC",
			StateOrProvinceCode = "fi",
			CountryCode = "jz",
			SpecialProgramCode = "TI",
			YesNoConditionOrResponseCode3 = "r",
			LevelOfServiceCode = "h",
			YesNoConditionOrResponseCode4 = "m",
			ProviderAgreementCode = "F",
			ClaimStatusCode = "T",
			YesNoConditionOrResponseCode5 = "3",
			ClaimSubmissionReasonCode = "Yv",
		};

		var actual = Map.MapObject<CLM_HealthClaim>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredClaimSubmittersIdentifier(string claimSubmittersIdentifier, bool isValidExpected)
	{
		var subject = new CLM_HealthClaim();
		//Required fields
		//Test Parameters
		subject.ClaimSubmittersIdentifier = claimSubmittersIdentifier;
		//If one filled, all required
		if(!string.IsNullOrEmpty(subject.FacilityCodeQualifier) || !string.IsNullOrEmpty(subject.FacilityCodeQualifier) || !string.IsNullOrEmpty(subject.FacilityCodeValue))
		{
			subject.FacilityCodeQualifier = "N";
			subject.FacilityCodeValue = "j";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("N", "j", true)]
	[InlineData("N", "", false)]
	[InlineData("", "j", false)]
	public void Validation_AllAreRequiredFacilityCodeQualifier(string facilityCodeQualifier, string facilityCodeValue, bool isValidExpected)
	{
		var subject = new CLM_HealthClaim();
		//Required fields
		subject.ClaimSubmittersIdentifier = "V";
		//Test Parameters
		subject.FacilityCodeQualifier = facilityCodeQualifier;
		subject.FacilityCodeValue = facilityCodeValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
