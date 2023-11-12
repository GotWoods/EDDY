using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class OPSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OPS*d*Sz*5*I*G";

		var expected = new OPS_OtherProgramSubjectAreaAndEligibility()
		{
			IdentificationCodeQualifier = "d",
			IdentificationCode = "Sz",
			PlacementCriteriaCode = "5",
			YesNoConditionOrResponseCode = "I",
			InstructionalSettingCode = "G",
		};

		var actual = Map.MapObject<OPS_OtherProgramSubjectAreaAndEligibility>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("d", "Sz", true)]
	[InlineData("d", "", false)]
	[InlineData("", "Sz", false)]
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
