using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C701Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "u:S:u";

		var expected = new C701_ErrorPointDetails()
		{
			MessageSectionCoded = "u",
			MessageItemNumber = "S",
			MessageSubItemNumber = "u",
		};

		var actual = Map.MapComposite<C701_ErrorPointDetails>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredMessageSectionCoded(string messageSectionCoded, bool isValidExpected)
	{
		var subject = new C701_ErrorPointDetails();
		//Required fields
		//Test Parameters
		subject.MessageSectionCoded = messageSectionCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
