using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class OITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OI*s*wi*d*s*E*W*j*i*f*y*p";

		var expected = new OI_OtherHealthInsuranceInformation()
		{
			ClaimFilingIndicatorCode = "s",
			ClaimSubmissionReasonCode = "wi",
			YesNoConditionOrResponseCode = "d",
			PatientSignatureSourceCode = "s",
			ProviderAgreementCode = "E",
			ReleaseOfInformationCode = "W",
			ProviderAcceptAssignmentCode = "j",
			YesNoConditionOrResponseCode2 = "i",
			YesNoConditionOrResponseCode3 = "f",
			YesNoConditionOrResponseCode4 = "y",
			YesNoConditionOrResponseCode5 = "p",
		};

		var actual = Map.MapObject<OI_OtherHealthInsuranceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
