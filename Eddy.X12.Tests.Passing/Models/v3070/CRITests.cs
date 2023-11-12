using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class CRITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "CRI*q0Y*d*9N*q*B*C*cn*P*U*iH";

		var expected = new CRI_ClaimReportInformation()
		{
			MaintenanceTypeCode = "q0Y",
			ClaimStatusCode = "d",
			MaintenanceReasonCode = "9N",
			YesNoConditionOrResponseCode = "q",
			FrequencyCode = "B",
			ClaimFilingIndicatorCode = "C",
			DateTimePeriodFormatQualifier = "cn",
			DateTimePeriod = "P",
			AdjustmentReasonCodeCharacteristic = "U",
			LateReasonCode = "iH",
		};

		var actual = Map.MapObject<CRI_ClaimReportInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
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
	[InlineData("U", "q0Y", true)]
	[InlineData("U", "", false)]
	[InlineData("", "q0Y", true)]
	public void Validation_ARequiresBAdjustmentReasonCodeCharacteristic(string adjustmentReasonCodeCharacteristic, string maintenanceTypeCode, bool isValidExpected)
	{
		var subject = new CRI_ClaimReportInformation();
		//Required fields
		subject.ClaimFilingIndicatorCode = "C";
		//Test Parameters
		subject.AdjustmentReasonCodeCharacteristic = adjustmentReasonCodeCharacteristic;
		subject.MaintenanceTypeCode = maintenanceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("iH", "q0Y", true)]
	[InlineData("iH", "", false)]
	[InlineData("", "q0Y", true)]
	public void Validation_ARequiresBLateReasonCode(string lateReasonCode, string maintenanceTypeCode, bool isValidExpected)
	{
		var subject = new CRI_ClaimReportInformation();
		//Required fields
		subject.ClaimFilingIndicatorCode = "C";
		//Test Parameters
		subject.LateReasonCode = lateReasonCode;
		subject.MaintenanceTypeCode = maintenanceTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
