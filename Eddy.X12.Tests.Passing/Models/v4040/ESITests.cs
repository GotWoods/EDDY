using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class ESITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ESI*5*G*s*DGdh*1*Qz*5*yu*Sl4";

		var expected = new ESI_EmploymentStatusInformation()
		{
			YesNoConditionOrResponseCode = "5",
			YesNoConditionOrResponseCode2 = "G",
			YesNoConditionOrResponseCode3 = "s",
			Time = "DGdh",
			Quantity = 1,
			EmploymentStatusCode = "Qz",
			WorkIntensityCode = "5",
			ReasonStoppedWorkCode = "yu",
			StatusReasonCode = "Sl4",
		};

		var actual = Map.MapObject<ESI_EmploymentStatusInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new ESI_EmploymentStatusInformation();
		//Required fields
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Sl4", "Qz", true)]
	[InlineData("Sl4", "", false)]
	[InlineData("", "Qz", true)]
	public void Validation_ARequiresBStatusReasonCode(string statusReasonCode, string employmentStatusCode, bool isValidExpected)
	{
		var subject = new ESI_EmploymentStatusInformation();
		//Required fields
		subject.YesNoConditionOrResponseCode = "5";
		//Test Parameters
		subject.StatusReasonCode = statusReasonCode;
		subject.EmploymentStatusCode = employmentStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
