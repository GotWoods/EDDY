using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class OPXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OPX*m*k*Afy*l*z";

		var expected = new OPX_PlacementCriteria()
		{
			YesNoConditionOrResponseCode = "m",
			PlacementCriteriaCode = "k",
			StatusReasonCode = "Afy",
			EducationalTestOrRequirementCode = "l",
			YesNoConditionOrResponseCode2 = "z",
		};

		var actual = Map.MapObject<OPX_PlacementCriteria>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new OPX_PlacementCriteria();
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
