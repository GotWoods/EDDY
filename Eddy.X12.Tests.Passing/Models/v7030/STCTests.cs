using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v7030;

namespace Eddy.x12.Tests.Models.v7030;

public class STCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "STC**vOqD6xjp*A*4*3*jRR1jrKA*WG4*vMigtv8t*q***B*GM";

		var expected = new STC_StatusInformation()
		{
			HealthCareClaimStatus = null,
			Date = "vOqD6xjp",
			ActionCode = "A",
			MonetaryAmount = 4,
			MonetaryAmount2 = 3,
			Date2 = "jRR1jrKA",
			PaymentMethodCode = "WG4",
			Date3 = "vMigtv8t",
			CheckNumber = "q",
			HealthCareClaimStatus2 = null,
			HealthCareClaimStatus3 = null,
			FreeFormMessageText = "B",
			ClaimSubmissionReasonCode = "GM",
		};

		var actual = Map.MapObject<STC_StatusInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredHealthCareClaimStatus(string healthCareClaimStatus, bool isValidExpected)
	{
		var subject = new STC_StatusInformation();
		//Required fields
		//Test Parameters
		if (healthCareClaimStatus != "") 
			subject.HealthCareClaimStatus = new C043_HealthCareClaimStatus();
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
