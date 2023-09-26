using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class HCRTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "HCR*4*q*XH*H";

		var expected = new HCR_HealthCareServicesReview()
		{
			ActionCode = "4",
			ReferenceIdentification = "q",
			RejectReasonCode = "XH",
			YesNoConditionOrResponseCode = "H",
		};

		var actual = Map.MapObject<HCR_HealthCareServicesReview>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredActionCode(string actionCode, bool isValidExpected)
	{
		var subject = new HCR_HealthCareServicesReview();
		//Required fields
		//Test Parameters
		subject.ActionCode = actionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
