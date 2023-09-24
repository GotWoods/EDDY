using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class STCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "STC**y4CZYr6N*5*5*9*Rr9CmUWX*Kpf*AKJWazlK*A***A*W9";

		var expected = new STC_StatusInformation()
		{
			HealthCareClaimStatus = null,
			Date = "y4CZYr6N",
			ActionCode = "5",
			MonetaryAmount = 5,
			MonetaryAmount2 = 9,
			Date2 = "Rr9CmUWX",
			PaymentMethodCode = "Kpf",
			Date3 = "AKJWazlK",
			CheckNumber = "A",
			HealthCareClaimStatus2 = null,
			HealthCareClaimStatus3 = null,
			FreeFormMessageText = "A",
			ClaimSubmissionReasonCode = "W9",
		};

		var actual = Map.MapObject<STC_StatusInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AA", true)]
	public void Validation_RequiredHealthCareClaimStatus(string healthCareClaimStatus, bool isValidExpected)
	{
		var subject = new STC_StatusInformation();
        if (healthCareClaimStatus != "")
            subject.HealthCareClaimStatus = new C043_HealthCareClaimStatus();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
