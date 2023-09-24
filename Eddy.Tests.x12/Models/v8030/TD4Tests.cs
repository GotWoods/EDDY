using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8030;

namespace Eddy.x12.Tests.Models.v8030;

public class TD4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TD4*rW*M*v*7*Z*b*R*";

		var expected = new TD4_CarrierDetailsSpecialHandlingOrHazardousMaterialsOrBoth()
		{
			SpecialHandlingCode = "rW",
			HazardousMaterialCodeQualifier = "M",
			HazardousMaterialClassCode = "v",
			Description = "7",
			YesNoConditionOrResponseCode = "Z",
			HazardousMaterialShippingName = "b",
			DangerousGoodsPrimaryClassificationCode = "R",
			CompositeDangerousGoodsSubsidiaryClassificationCodes = null,
		};

		var actual = Map.MapObject<TD4_CarrierDetailsSpecialHandlingOrHazardousMaterialsOrBoth>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("M", "v", true)]
	[InlineData("M", "", false)]
	[InlineData("", "v", true)]
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
