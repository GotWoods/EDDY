using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class STCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "STC**qQuZ0rX0*1*4*1*swLEMSnn*JhE*tlGJR9zB*W***E";

		var expected = new STC_StatusInformation()
		{
			HealthCareClaimStatus = null,
			Date = "qQuZ0rX0",
			ActionCode = "1",
			MonetaryAmount = 4,
			MonetaryAmount2 = 1,
			Date2 = "swLEMSnn",
			PaymentMethodCode = "JhE",
			Date3 = "tlGJR9zB",
			CheckNumber = "W",
			HealthCareClaimStatus2 = null,
			HealthCareClaimStatus3 = null,
			FreeFormMessageText = "E",
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
