using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A.Composites;

public class C814Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "p:v";

		var expected = new C814_SafetySection()
		{
			SafetySectionNumber = "p",
			SafetySectionName = "v",
		};

		var actual = Map.MapComposite<C814_SafetySection>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("p", true)]
	public void Validation_RequiredSafetySectionNumber(string safetySectionNumber, bool isValidExpected)
	{
		var subject = new C814_SafetySection();
		//Required fields
		//Test Parameters
		subject.SafetySectionNumber = safetySectionNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
