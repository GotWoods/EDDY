using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D97A;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Tests.Models.D97A;

public class CLTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CLT+2+y+v";

		var expected = new CLT_ClearTerminateInformation()
		{
			ActionRequestNotificationCoded = "2",
			MessageFunctionCoded = "y",
			FreeText = "v",
		};

		var actual = Map.MapObject<CLT_ClearTerminateInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("2", true)]
	public void Validation_RequiredActionRequestNotificationCoded(string actionRequestNotificationCoded, bool isValidExpected)
	{
		var subject = new CLT_ClearTerminateInformation();
		//Required fields
		//Test Parameters
		subject.ActionRequestNotificationCoded = actionRequestNotificationCoded;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
