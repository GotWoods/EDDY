using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class TD4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TD4*2c*V*W*4*z";

		var expected = new TD4_CarrierDetailsSpecialHandlingOrHazardousMaterialsOrBoth()
		{
			SpecialHandlingCode = "2c",
			HazardousMaterialCodeQualifier = "V",
			HazardousMaterialClassCode = "W",
			Description = "4",
			YesNoConditionOrResponseCode = "z",
		};

		var actual = Map.MapObject<TD4_CarrierDetailsSpecialHandlingOrHazardousMaterialsOrBoth>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("V", "W", true)]
	[InlineData("V", "", false)]
	[InlineData("", "W", true)]
	public void Validation_ARequiresBHazardousMaterialCodeQualifier(string hazardousMaterialCodeQualifier, string hazardousMaterialClassCode, bool isValidExpected)
	{
		var subject = new TD4_CarrierDetailsSpecialHandlingOrHazardousMaterialsOrBoth();
		//Required fields
		//Test Parameters
		subject.HazardousMaterialCodeQualifier = hazardousMaterialCodeQualifier;
		subject.HazardousMaterialClassCode = hazardousMaterialClassCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
