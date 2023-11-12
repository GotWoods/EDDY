using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class LH3Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "LH3*y*Q*ELV";

		var expected = new LH3_HazardousMaterialShippingName()
		{
			HazardousMaterialShippingName = "y",
			HazardousMaterialShippingNameQualifier = "Q",
			NOSIndicatorCode = "ELV",
		};

		var actual = Map.MapObject<LH3_HazardousMaterialShippingName>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("y", "Q", true)]
	[InlineData("y", "", false)]
	[InlineData("", "Q", false)]
	public void Validation_AllAreRequiredHazardousMaterialShippingName(string hazardousMaterialShippingName, string hazardousMaterialShippingNameQualifier, bool isValidExpected)
	{
		var subject = new LH3_HazardousMaterialShippingName();
		subject.HazardousMaterialShippingName = hazardousMaterialShippingName;
		subject.HazardousMaterialShippingNameQualifier = hazardousMaterialShippingNameQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
