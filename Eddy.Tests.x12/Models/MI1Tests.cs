using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class MI1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MI1*9D*J*1";

		var expected = new MI1_MileageSource()
		{
			MileageSourceCode = "9D",
			YesNoConditionOrResponseCode = "J",
			Number = 1,
		};

		var actual = Map.MapObject<MI1_MileageSource>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9D", true)]
	public void Validation_RequiredMileageSourceCode(string mileageSourceCode, bool isValidExpected)
	{
		var subject = new MI1_MileageSource();
		subject.YesNoConditionOrResponseCode = "J";
		subject.MileageSourceCode = mileageSourceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new MI1_MileageSource();
		subject.MileageSourceCode = "9D";
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
