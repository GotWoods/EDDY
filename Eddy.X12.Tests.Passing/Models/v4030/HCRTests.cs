using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class HCRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HCR*t*A*iv*y";

		var expected = new HCR_HealthCareServicesReview()
		{
			ActionCode = "t",
			ReferenceIdentification = "A",
			RejectReasonCode = "iv",
			YesNoConditionOrResponseCode = "y",
		};

		var actual = Map.MapObject<HCR_HealthCareServicesReview>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new HCR_HealthCareServicesReview();
		//Required fields
		//Test Parameters
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
