using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class MLSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MLS*W*N*w*f";

		var expected = new MLS_Milestone()
		{
			MilestoneNumberIdentification = "W",
			Description = "N",
			WorkStatusCode = "w",
			ActionCode = "f",
		};

		var actual = Map.MapObject<MLS_Milestone>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("W", true)]
	public void Validation_RequiredMilestoneNumberIdentification(string milestoneNumberIdentification, bool isValidExpected)
	{
		var subject = new MLS_Milestone();
		subject.MilestoneNumberIdentification = milestoneNumberIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
