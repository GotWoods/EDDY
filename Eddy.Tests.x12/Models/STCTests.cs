using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class STCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "STC**y4CZYr6N*5*5*9*Rr9CmUWX*Kpf*AKJWazlK*A***A*W9";

		var expected = new STC_StatusInformation()
		{
			HealthCareClaimStatus = "",
			Date = "y4CZYr6N",
			ActionCode = "5",
			MonetaryAmount = 5,
			MonetaryAmount2 = 9,
			Date2 = "Rr9CmUWX",
			PaymentMethodCode = "Kpf",
			Date3 = "AKJWazlK",
			CheckNumber = "A",
			HealthCareClaimStatus2 = "",
			HealthCareClaimStatus3 = "",
			FreeFormMessageText = "A",
			ClaimSubmissionReasonCode = "W9",
		};

		var actual = Map.MapObject<STC_StatusInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("", true)]
	public void Validation_RequiredHealthCareClaimStatus(C043_HealthCareClaimStatus healthCareClaimStatus, bool isValidExpected)
	{
		var subject = new STC_StatusInformation();
		subject.HealthCareClaimStatus = healthCareClaimStatus;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
