using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.Tests.Models.v4040;

public class OPXTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OPX*c*H*Qaq*0*F";

		var expected = new OPX_PlacementCriteria()
		{
			YesNoConditionOrResponseCode = "c",
			PlacementCriteriaCode = "H",
			StatusReasonCode = "Qaq",
			EducationalTestOrRequirementCode = "0",
			YesNoConditionOrResponseCode2 = "F",
		};

		var actual = Map.MapObject<OPX_PlacementCriteria>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new OPX_PlacementCriteria();
		//Required fields
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
