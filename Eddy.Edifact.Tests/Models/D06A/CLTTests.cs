using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A;

public class CLTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "CLT+L+k+5";

		var expected = new CLT_ClearTerminateInformation()
		{
			ActionCode = "L",
			MessageFunctionCode = "k",
			FreeText = "5",
		};

		var actual = Map.MapObject<CLT_ClearTerminateInformation>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("L", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new CLT_ClearTerminateInformation();
		//Required fields
		//Test Parameters
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
