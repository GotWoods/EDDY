using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C814Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "Y:C";

		var expected = new C814_SafetySection()
		{
			SafetySection = "Y",
			SafetySectionName = "C",
		};

		var actual = Map.MapComposite<C814_SafetySection>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Y", true)]
	public void Validation_RequiredSafetySection(string safetySection, bool isValidExpected)
	{
		var subject = new C814_SafetySection();
		//Required fields
		//Test Parameters
		subject.SafetySection = safetySection;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
