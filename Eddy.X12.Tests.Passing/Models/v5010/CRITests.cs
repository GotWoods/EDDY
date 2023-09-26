using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.Tests.Models.v5010;

public class CRITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRI*ijM*T*8D*B*C*a*HZ*n*B*33*df";

		var expected = new CRI_ClaimReportInformation()
		{
			MaintenanceTypeCode = "ijM",
			ClaimStatusCode = "T",
			MaintenanceReasonCode = "8D",
			YesNoConditionOrResponseCode = "B",
			FrequencyCode = "C",
			ClaimFilingIndicatorCode = "a",
			DateTimePeriodFormatQualifier = "HZ",
			DateTimePeriod = "n",
			AdjustmentReasonCodeCharacteristic = "B",
			LateReasonCode = "33",
			ConditionIndicator = "df",
		};

		var actual = Map.MapObject<CRI_ClaimReportInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredClaimFilingIndicatorCode(string claimFilingIndicatorCode, bool isValidExpected)
	{
		var subject = new CRI_ClaimReportInformation();
		//Required fields
		//Test Parameters
		subject.ClaimFilingIndicatorCode = claimFilingIndicatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("B", "ijM", true)]
	[InlineData("B", "", false)]
	[InlineData("", "ijM", true)]
	public void Validation_ARequiresBAdjustmentReasonCodeCharacteristic(string adjustmentReasonCodeCharacteristic, string maintenanceTypeCode, bool isValidExpected)
	{
		var subject = new CRI_ClaimReportInformation();
		//Required fields
		subject.ClaimFilingIndicatorCode = "a";
		//Test Parameters
		subject.AdjustmentReasonCodeCharacteristic = adjustmentReasonCodeCharacteristic;
		subject.MaintenanceTypeCode = maintenanceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("33", "ijM", true)]
	[InlineData("33", "", false)]
	[InlineData("", "ijM", true)]
	public void Validation_ARequiresBLateReasonCode(string lateReasonCode, string maintenanceTypeCode, bool isValidExpected)
	{
		var subject = new CRI_ClaimReportInformation();
		//Required fields
		subject.ClaimFilingIndicatorCode = "a";
		//Test Parameters
		subject.LateReasonCode = lateReasonCode;
		subject.MaintenanceTypeCode = maintenanceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
