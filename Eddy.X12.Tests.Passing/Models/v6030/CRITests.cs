using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class CRITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRI*PL7*B*A5*T*u*N*ew*C*A*Hu*j7";

		var expected = new CRI_ClaimReportInformation()
		{
			MaintenanceTypeCode = "PL7",
			ClaimStatusCode = "B",
			MaintenanceReasonCode = "A5",
			YesNoConditionOrResponseCode = "T",
			FrequencyCode = "u",
			ClaimFilingIndicatorCode = "N",
			DateTimePeriodFormatQualifier = "ew",
			DateTimePeriod = "C",
			AdjustmentReasonCodeCharacteristic = "A",
			LateReasonCode = "Hu",
			ConditionIndicatorCode = "j7",
		};

		var actual = Map.MapObject<CRI_ClaimReportInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
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
	[InlineData("A", "PL7", true)]
	[InlineData("A", "", false)]
	[InlineData("", "PL7", true)]
	public void Validation_ARequiresBAdjustmentReasonCodeCharacteristic(string adjustmentReasonCodeCharacteristic, string maintenanceTypeCode, bool isValidExpected)
	{
		var subject = new CRI_ClaimReportInformation();
		//Required fields
		subject.ClaimFilingIndicatorCode = "N";
		//Test Parameters
		subject.AdjustmentReasonCodeCharacteristic = adjustmentReasonCodeCharacteristic;
		subject.MaintenanceTypeCode = maintenanceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Hu", "PL7", true)]
	[InlineData("Hu", "", false)]
	[InlineData("", "PL7", true)]
	public void Validation_ARequiresBLateReasonCode(string lateReasonCode, string maintenanceTypeCode, bool isValidExpected)
	{
		var subject = new CRI_ClaimReportInformation();
		//Required fields
		subject.ClaimFilingIndicatorCode = "N";
		//Test Parameters
		subject.LateReasonCode = lateReasonCode;
		subject.MaintenanceTypeCode = maintenanceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
