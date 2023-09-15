using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class H2Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "H2*tq*q";

		var expected = new H2_AdditionalHazardousMaterialDescription()
		{
			HazardousMaterialDescription = "tq",
			HazardousMaterialClassification = "q",
		};

		var actual = Map.MapObject<H2_AdditionalHazardousMaterialDescription>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tq", true)]
	public void Validation_RequiredHazardousMaterialDescription(string hazardousMaterialDescription, bool isValidExpected)
	{
		var subject = new H2_AdditionalHazardousMaterialDescription();
		subject.HazardousMaterialDescription = hazardousMaterialDescription;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
