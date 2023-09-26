using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class MI1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MI1*Ep*x*7";

		var expected = new MI1_MileageSource()
		{
			MileageSourceCode = "Ep",
			YesNoConditionOrResponseCode = "x",
			Number = 7,
		};

		var actual = Map.MapObject<MI1_MileageSource>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ep", true)]
	public void Validation_RequiredMileageSourceCode(string mileageSourceCode, bool isValidExpected)
	{
		var subject = new MI1_MileageSource();
		//Required fields
		subject.YesNoConditionOrResponseCode = "x";
		//Test Parameters
		subject.MileageSourceCode = mileageSourceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("x", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new MI1_MileageSource();
		//Required fields
		subject.MileageSourceCode = "Ep";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
