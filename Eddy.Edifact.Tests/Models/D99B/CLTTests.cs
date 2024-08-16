using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class CLTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CLT+s+q+U";

		var expected = new CLT_ClearTerminateInformation()
		{
			ActionRequestNotificationDescriptionCode = "s",
			MessageFunctionCode = "q",
			FreeTextValue = "U",
		};

		var actual = Map.MapObject<CLT_ClearTerminateInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("s", true)]
	public void Validation_RequiredActionRequestNotificationDescriptionCode(string actionRequestNotificationDescriptionCode, bool isValidExpected)
	{
		var subject = new CLT_ClearTerminateInformation();
		//Required fields
		//Test Parameters
		subject.ActionRequestNotificationDescriptionCode = actionRequestNotificationDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
