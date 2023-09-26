using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class URTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "UR*K*3";

		var expected = new UR_PeerReviewOrganizationOrUtilizationReview()
		{
			ApprovalCode = "K",
			Quantity = 3,
		};

		var actual = Map.MapObject<UR_PeerReviewOrganizationOrUtilizationReview>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("K", true)]
	public void Validation_RequiredApprovalCode(string approvalCode, bool isValidExpected)
	{
		var subject = new UR_PeerReviewOrganizationOrUtilizationReview();
		//Required fields
		//Test Parameters
		subject.ApprovalCode = approvalCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
