using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class TD4Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TD4*z5*S*Pa*g";

		var expected = new TD4_CarrierDetailsSpecialHandlingOrHazardousMaterialsOrBoth()
		{
			SpecialHandlingCode = "z5",
			HazardousMaterialCodeQualifier = "S",
			HazardousMaterialClassCode = "Pa",
			Description = "g",
		};

		var actual = Map.MapObject<TD4_CarrierDetailsSpecialHandlingOrHazardousMaterialsOrBoth>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("S", "Pa", true)]
	[InlineData("S", "", false)]
	[InlineData("", "Pa", true)]
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
