using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class CRITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRI*Tl0*m*yR*G*a*e*ys*J*B*bM*3r";

		var expected = new CRI_ClaimReportInformation()
		{
			MaintenanceTypeCode = "Tl0",
			ClaimStatusCode = "m",
			MaintenanceReasonCode = "yR",
			YesNoConditionOrResponseCode = "G",
			FrequencyCode = "a",
			ClaimFilingIndicatorCode = "e",
			DateTimePeriodFormatQualifier = "ys",
			DateTimePeriod = "J",
			AdjustmentReasonCodeCharacteristic = "B",
			LateReasonCode = "bM",
			ConditionIndicatorCode = "3r",
		};

		var actual = Map.MapObject<CRI_ClaimReportInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredClaimFilingIndicatorCode(string claimFilingIndicatorCode, bool isValidExpected)
	{
		var subject = new CRI_ClaimReportInformation();
		subject.ClaimFilingIndicatorCode = claimFilingIndicatorCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "Tl0", true)]
	[InlineData("B", "", false)]
	public void Validation_ARequiresBAdjustmentReasonCodeCharacteristic(string adjustmentReasonCodeCharacteristic, string maintenanceTypeCode, bool isValidExpected)
	{
		var subject = new CRI_ClaimReportInformation();
		subject.ClaimFilingIndicatorCode = "e";
		subject.AdjustmentReasonCodeCharacteristic = adjustmentReasonCodeCharacteristic;
		subject.MaintenanceTypeCode = maintenanceTypeCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "Tl0", true)]
	[InlineData("bM", "", false)]
	public void Validation_ARequiresBLateReasonCode(string lateReasonCode, string maintenanceTypeCode, bool isValidExpected)
	{
		var subject = new CRI_ClaimReportInformation();
		subject.ClaimFilingIndicatorCode = "e";
		subject.LateReasonCode = lateReasonCode;
		subject.MaintenanceTypeCode = maintenanceTypeCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
