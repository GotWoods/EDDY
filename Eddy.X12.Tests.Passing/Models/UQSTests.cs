using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class UQSTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UQS*Z*d*K*T";

		var expected = new UQS_UnderwritingQuestion()
		{
			ReferenceIdentification = "Z",
			ReferenceIdentification2 = "d",
			FreeFormMessageText = "K",
			YesNoConditionOrResponseCode = "T",
		};

		var actual = Map.MapObject<UQS_UnderwritingQuestion>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new UQS_UnderwritingQuestion();
		subject.ReferenceIdentification = referenceIdentification;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
