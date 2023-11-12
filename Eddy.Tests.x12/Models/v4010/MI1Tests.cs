using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class MI1Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MI1*KH*w*7";

		var expected = new MI1_MileageSource()
		{
			SourceCode = "KH",
			YesNoConditionOrResponseCode = "w",
			Number = 7,
		};

		var actual = Map.MapObject<MI1_MileageSource>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("KH", true)]
	public void Validation_RequiredSourceCode(string sourceCode, bool isValidExpected)
	{
		var subject = new MI1_MileageSource();
		//Required fields
		subject.YesNoConditionOrResponseCode = "w";
		//Test Parameters
		subject.SourceCode = sourceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("w", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new MI1_MileageSource();
		//Required fields
		subject.SourceCode = "KH";
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
