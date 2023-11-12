using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.Tests.Models.v7020;

public class OITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OI*C*yN*O*P*k*0*f*T*s*J*Z";

		var expected = new OI_OtherHealthInsuranceInformation()
		{
			ClaimFilingIndicatorCode = "C",
			ClaimSubmissionReasonCode = "yN",
			YesNoConditionOrResponseCode = "O",
			PatientSignatureSourceCode = "P",
			ProviderAgreementCode = "k",
			ReleaseOfInformationCode = "0",
			ProviderAcceptAssignmentCode = "f",
			YesNoConditionOrResponseCode2 = "T",
			YesNoConditionOrResponseCode3 = "s",
			YesNoConditionOrResponseCode4 = "J",
			YesNoConditionOrResponseCode5 = "Z",
		};

		var actual = Map.MapObject<OI_OtherHealthInsuranceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
