using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A.Composites;

public class C555Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		var line = "f:h:A:9";

		var expected = new C555_StatusEvent()
		{
			StatusEventCoded = "f",
			CodeListQualifier = "h",
			CodeListResponsibleAgencyCoded = "A",
			StatusEvent = "9",
		};

		var actual = Map.MapComposite<C555_StatusEvent>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("f", true)]
	public void Validation_RequiredStatusEventCoded(string statusEventCoded, bool isValidExpected)
	{
		var subject = new C555_StatusEvent();
		//Required fields
		//Test Parameters
		subject.StatusEventCoded = statusEventCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
