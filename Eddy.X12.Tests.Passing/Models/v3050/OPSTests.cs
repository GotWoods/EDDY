using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class OPSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OPS*h*f4*O*j*y";

		var expected = new OPS_OtherProgramSubjectAreaAndEligibility()
		{
			IdentificationCodeQualifier = "h",
			IdentificationCode = "f4",
			PlacementCriteriaCode = "O",
			YesNoConditionOrResponseCode = "j",
			InstructionalSettingCode = "y",
		};

		var actual = Map.MapObject<OPS_OtherProgramSubjectAreaAndEligibility>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("h", "f4", true)]
	[InlineData("h", "", false)]
	[InlineData("", "f4", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new OPS_OtherProgramSubjectAreaAndEligibility();
		//Required fields
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
