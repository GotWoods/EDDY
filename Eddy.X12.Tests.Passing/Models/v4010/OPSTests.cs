using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class OPSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OPS*f*T6*Q*u**2";

		var expected = new OPS_ProgramSubjectAreaAndEligibility()
		{
			IdentificationCodeQualifier = "f",
			IdentificationCode = "T6",
			YesNoConditionOrResponseCode = "Q",
			InstructionalSettingCode = "u",
			CompositeUnitOfMeasure = null,
			Quantity = 2,
		};

		var actual = Map.MapObject<OPS_ProgramSubjectAreaAndEligibility>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("f", "T6", true)]
	[InlineData("f", "", false)]
	[InlineData("", "T6", false)]
	public void Validation_AllAreRequiredIdentificationCodeQualifier(string identificationCodeQualifier, string identificationCode, bool isValidExpected)
	{
		var subject = new OPS_ProgramSubjectAreaAndEligibility();
		//Required fields
		//Test Parameters
		subject.IdentificationCodeQualifier = identificationCodeQualifier;
		subject.IdentificationCode = identificationCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
