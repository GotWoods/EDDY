using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D99B;
using Eddy.Edifact.Models.D99B.Composites;

namespace Eddy.Edifact.Tests.Models.D99B;

public class FRMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "FRM+Z+c+l";

		var expected = new FRM_FollowUpAction()
		{
			ObjectIdentifier = "Z",
			StatusReasonDescriptionCode = "c",
			ActionRequestNotificationDescriptionCode = "l",
		};

		var actual = Map.MapObject<FRM_FollowUpAction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Z", true)]
	public void Validation_RequiredObjectIdentifier(string objectIdentifier, bool isValidExpected)
	{
		var subject = new FRM_FollowUpAction();
		//Required fields
		subject.StatusReasonDescriptionCode = "c";
		//Test Parameters
		subject.ObjectIdentifier = objectIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredStatusReasonDescriptionCode(string statusReasonDescriptionCode, bool isValidExpected)
	{
		var subject = new FRM_FollowUpAction();
		//Required fields
		subject.ObjectIdentifier = "Z";
		//Test Parameters
		subject.StatusReasonDescriptionCode = statusReasonDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
