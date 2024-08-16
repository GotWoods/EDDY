using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D96A;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Tests.Models.D96A;

public class PTYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PTY+a+";

		var expected = new PTY_Priority()
		{
			PriorityQualifier = "a",
			PriorityDetails = null,
		};

		var actual = Map.MapObject<PTY_Priority>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredPriorityQualifier(string priorityQualifier, bool isValidExpected)
	{
		var subject = new PTY_Priority();
		//Required fields
		//Test Parameters
		subject.PriorityQualifier = priorityQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
