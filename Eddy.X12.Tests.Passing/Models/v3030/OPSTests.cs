using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class OPSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "OPS*4*72*k*K";

		var expected = new OPS_OtherProgramSubjectAreaAndEligibility()
		{
			IdentificationCodeQualifier = "4",
			IdentificationCode = "72",
			PlacementCriteriaCode = "k",
			YesNoConditionOrResponseCode = "K",
		};

		var actual = Map.MapObject<OPS_OtherProgramSubjectAreaAndEligibility>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("4", "72", true)]
	[InlineData("4", "", false)]
	[InlineData("", "72", false)]
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
