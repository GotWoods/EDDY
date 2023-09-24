using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SHRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SHR*n*3M";

		var expected = new SHR_RailroadInterlineServiceSpecialHandlingRestrictions()
		{
			YesNoConditionOrResponseCode = "n",
			SpecialHandlingCode = "3M",
		};

		var actual = Map.MapObject<SHR_RailroadInterlineServiceSpecialHandlingRestrictions>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("n", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new SHR_RailroadInterlineServiceSpecialHandlingRestrictions();
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
