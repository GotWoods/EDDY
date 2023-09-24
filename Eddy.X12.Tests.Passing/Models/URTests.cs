using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class URTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UR*d*1";

		var expected = new UR_PeerReviewOrganizationOrUtilizationReview()
		{
			ApprovalCode = "d",
			Quantity = 1,
		};

		var actual = Map.MapObject<UR_PeerReviewOrganizationOrUtilizationReview>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("d", true)]
	public void Validation_RequiredApprovalCode(string approvalCode, bool isValidExpected)
	{
		var subject = new UR_PeerReviewOrganizationOrUtilizationReview();
		subject.ApprovalCode = approvalCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
