using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D01C;
using Eddy.Edifact.Models.D01C.Composites;

namespace Eddy.Edifact.Tests.Models.D01C;

public class CLTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CLT+e+4+N";

		var expected = new CLT_ClearTerminateInformation()
		{
			ActionRequestNotificationDescriptionCode = "e",
			MessageFunctionCode = "4",
			FreeText = "N",
		};

		var actual = Map.MapObject<CLT_ClearTerminateInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("e", true)]
	public void Validation_RequiredActionRequestNotificationDescriptionCode(string actionRequestNotificationDescriptionCode, bool isValidExpected)
	{
		var subject = new CLT_ClearTerminateInformation();
		//Required fields
		//Test Parameters
		subject.ActionRequestNotificationDescriptionCode = actionRequestNotificationDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
