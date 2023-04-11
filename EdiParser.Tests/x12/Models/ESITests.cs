using EdiParser.Validation;
using EdiParser.x12.Mapping;
using EdiParser.x12.Models;

namespace EdiParser.Tests.x12.Models;

public class ESITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ESI*A*D*V*BKTl*8*BS*9*qT*Qef";

		var expected = new ESI_EmploymentStatusInformation()
		{
			YesNoConditionOrResponseCode = "A",
			YesNoConditionOrResponseCode2 = "D",
			YesNoConditionOrResponseCode3 = "V",
			Time = "BKTl",
			Quantity = 8,
			EmploymentStatusCode = "BS",
			WorkIntensityCode = "9",
			ReasonStoppedWorkCode = "qT",
			StatusReasonCode = "Qef",
		};

		var actual = Map.MapObject<ESI_EmploymentStatusInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validatation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new ESI_EmploymentStatusInformation();
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "BS", true)]
	[InlineData("Qef", "", false)]
	public void Validation_ARequiresBStatusReasonCode(string statusReasonCode, string employmentStatusCode, bool isValidExpected)
	{
		var subject = new ESI_EmploymentStatusInformation();
		subject.YesNoConditionOrResponseCode = "A";
		subject.StatusReasonCode = statusReasonCode;
		subject.EmploymentStatusCode = employmentStatusCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
