using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class OPSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OPS*Y*vR*k*O**4";

		var expected = new OPS_ProgramSubjectAreaAndEligibility()
		{
			IdentificationCodeQualifier = "Y",
			IdentificationCode = "vR",
			YesNoConditionOrResponseCode = "k",
			InstructionalSettingCode = "O",
			CompositeUnitOfMeasure = null,
			Quantity = 4,
		};

		var actual = Map.MapObject<OPS_ProgramSubjectAreaAndEligibility>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("Y", "vR", true)]
	[InlineData("Y", "", false)]
	[InlineData("", "vR", false)]
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
