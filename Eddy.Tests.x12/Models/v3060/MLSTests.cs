using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class MLSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MLS*V*l*W*p";

		var expected = new MLS_Milestone()
		{
			MilestoneNumberIdentification = "V",
			Description = "l",
			WorkStatusCode = "W",
			ActionCode = "p",
		};

		var actual = Map.MapObject<MLS_Milestone>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("V", true)]
	public void Validation_RequiredMilestoneNumberIdentification(string milestoneNumberIdentification, bool isValidExpected)
	{
		var subject = new MLS_Milestone();
		//Required fields
		//Test Parameters
		subject.MilestoneNumberIdentification = milestoneNumberIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
