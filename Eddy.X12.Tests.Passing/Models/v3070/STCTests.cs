using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class STCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "STC**EKob2a*3*5*9*LK3dsi*Rvv*0Ip22l*M***Q";

		var expected = new STC_StatusInformation()
		{
			HealthCareClaimStatus = null,
			Date = "EKob2a",
			ActionCode = "3",
			MonetaryAmount = 5,
			MonetaryAmount2 = 9,
			Date2 = "LK3dsi",
			PaymentMethodCode = "Rvv",
			Date3 = "0Ip22l",
			CheckNumber = "M",
			HealthCareClaimStatus2 = null,
			HealthCareClaimStatus3 = null,
			FreeFormMessageText = "Q",
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
