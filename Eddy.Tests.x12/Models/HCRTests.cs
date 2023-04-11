using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class HCRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HCR*6*D*5*e";

		var expected = new HCR_HealthCareServicesReview()
		{
			ActionCode = "6",
			ReferenceIdentification = "D",
			IndustryCode = "5",
			YesNoConditionOrResponseCode = "e",
		};

		var actual = Map.MapObject<HCR_HealthCareServicesReview>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new HCR_HealthCareServicesReview();
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
