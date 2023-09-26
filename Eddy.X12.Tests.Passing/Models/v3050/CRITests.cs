using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class CRITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRI*Xn4*1*TQ*l*A*f*NU*u";

		var expected = new CRI_ClaimReportInformation()
		{
			MaintenanceTypeCode = "Xn4",
			ClaimStatusCode = "1",
			MaintenanceReasonCode = "TQ",
			YesNoConditionOrResponseCode = "l",
			FrequencyCode = "A",
			ClaimFilingIndicatorCode = "f",
			DateTimePeriodFormatQualifier = "NU",
			DateTimePeriod = "u",
		};

		var actual = Map.MapObject<CRI_ClaimReportInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredClaimFilingIndicatorCode(string claimFilingIndicatorCode, bool isValidExpected)
	{
		var subject = new CRI_ClaimReportInformation();
		//Required fields
		//Test Parameters
		subject.ClaimFilingIndicatorCode = claimFilingIndicatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
