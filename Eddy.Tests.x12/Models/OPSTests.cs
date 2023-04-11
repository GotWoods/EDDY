using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class OPSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OPS*O*or*h*2**6";

		var expected = new OPS_ProgramSubjectAreaAndEligibility()
		{
			IdentificationCodeQualifier = "O",
			IdentificationCode = "or",
			YesNoConditionOrResponseCode = "h",
			InstructionalSettingCode = "2",
			CompositeUnitOfMeasure = null,
			Quantity = 6,
		};

		var actual = Map.MapObject<OPS_ProgramSubjectAreaAndEligibility>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("","", true)]
	[InlineData("O", "or", true)]
	[InlineData("", "or", false)]
	[InlineData("O", "", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new OPS_ProgramSubjectAreaAndEligibility();
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
