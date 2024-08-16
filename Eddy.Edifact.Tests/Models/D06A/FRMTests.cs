using Eddy.Core.Validation;
using Eddy.Edifact.Mapping;
using Eddy.Edifact.Models.D06A;
using Eddy.Edifact.Models.D06A.Composites;

namespace Eddy.Edifact.Tests.Models.D06A;

public class FRMTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string line = "FRM+q+u+w";

		var expected = new FRM_FollowUpAction()
		{
			ObjectIdentifier = "q",
			StatusReasonDescriptionCode = "u",
			ActionCode = "w",
		};

		var actual = Map.MapObject<FRM_FollowUpAction>(line, MapOptionsForTesting.EdifactDefaultEndsWithSingleQuote);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredObjectIdentifier(string objectIdentifier, bool isValidExpected)
	{
		var subject = new FRM_FollowUpAction();
		//Required fields
		subject.StatusReasonDescriptionCode = "u";
		//Test Parameters
		subject.ObjectIdentifier = objectIdentifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("u", true)]
	public void Validation_RequiredStatusReasonDescriptionCode(string statusReasonDescriptionCode, bool isValidExpected)
	{
		var subject = new FRM_FollowUpAction();
		//Required fields
		subject.ObjectIdentifier = "q";
		//Test Parameters
		subject.StatusReasonDescriptionCode = statusReasonDescriptionCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
