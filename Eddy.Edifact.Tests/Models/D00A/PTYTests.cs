using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D00A;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Tests.Models.D00A;

public class PTYTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "PTY+s+";

		var expected = new PTY_Priority()
		{
			PriorityTypeCodeQualifier = "s",
			PriorityDetails = null,
		};

		var actual = Map.MapObject<PTY_Priority>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredPriorityTypeCodeQualifier(string priorityTypeCodeQualifier, bool isValidExpected)
	{
		var subject = new PTY_Priority();
		//Required fields
		//Test Parameters
		subject.PriorityTypeCodeQualifier = priorityTypeCodeQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
