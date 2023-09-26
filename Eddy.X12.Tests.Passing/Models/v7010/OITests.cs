using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.Tests.Models.v7010;

public class OITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OI*e*SO*k*z*a*8*W";

		var expected = new OI_OtherHealthInsuranceInformation()
		{
			ClaimFilingIndicatorCode = "e",
			ClaimSubmissionReasonCode = "SO",
			YesNoConditionOrResponseCode = "k",
			PatientSignatureSourceCode = "z",
			ProviderAgreementCode = "a",
			ReleaseOfInformationCode = "8",
			ProviderAcceptAssignmentCode = "W",
		};

		var actual = Map.MapObject<OI_OtherHealthInsuranceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
