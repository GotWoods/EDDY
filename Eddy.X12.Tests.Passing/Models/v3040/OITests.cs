using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class OITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OI*e*LU*o*B*l*g";

		var expected = new OI_OtherHealthInsuranceInformation()
		{
			ClaimFilingIndicatorCode = "e",
			ClaimSubmissionReasonCode = "LU",
			YesNoConditionOrResponseCode = "o",
			PatientSignatureSourceCode = "B",
			ProviderAgreementCode = "l",
			ReleaseOfInformationCode = "g",
		};

		var actual = Map.MapObject<OI_OtherHealthInsuranceInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

}
