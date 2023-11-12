using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class ESITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ESI*q*C*l*vOzI*9*xy*x*rW";

		var expected = new ESI_EmploymentStatusInformation()
		{
			YesNoConditionOrResponseCode = "q",
			YesNoConditionOrResponseCode2 = "C",
			YesNoConditionOrResponseCode3 = "l",
			Time = "vOzI",
			Quantity = 9,
			EmploymentStatusCode = "xy",
			WorkIntensityCode = "x",
			ReasonStoppedWorkCode = "rW",
		};

		var actual = Map.MapObject<ESI_EmploymentStatusInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new ESI_EmploymentStatusInformation();
		//Required fields
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
