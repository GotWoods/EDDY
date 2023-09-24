using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.Tests.Models.v8010;

public class TD4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TD4*Jn*p*z*5*H*j*0*x";

		var expected = new TD4_CarrierDetailsSpecialHandlingOrHazardousMaterialsOrBoth()
		{
			SpecialHandlingCode = "Jn",
			HazardousMaterialCodeQualifier = "p",
			HazardousMaterialClassCode = "z",
			Description = "5",
			YesNoConditionOrResponseCode = "H",
			HazardousMaterialShippingName = "j",
			DangerousGoodsPrimaryClassificationCode = "0",
			PrimaryClassificationCode = "x",
		};

		var actual = Map.MapObject<TD4_CarrierDetailsSpecialHandlingOrHazardousMaterialsOrBoth>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("p", "z", true)]
	[InlineData("p", "", false)]
	[InlineData("", "z", true)]
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
