using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class UQSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UQS*o*O*z*n";

		var expected = new UQS_UnderwritingQuestion()
		{
			ReferenceIdentification = "o",
			ReferenceIdentification2 = "O",
			FreeFormMessageText = "z",
			YesNoConditionOrResponseCode = "n",
		};

		var actual = Map.MapObject<UQS_UnderwritingQuestion>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("o", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new UQS_UnderwritingQuestion();
		//Required fields
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
