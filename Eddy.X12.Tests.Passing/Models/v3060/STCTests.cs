using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class STCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "STC*j*DJeXEJ*W*6*9*8SwRXz*Ni1*WHqyAh*E*H*P*a";

		var expected = new STC_StatusInformation()
		{
			IndustryCode = "j",
			Date = "DJeXEJ",
			ActionCode = "W",
			MonetaryAmount = 6,
			MonetaryAmount2 = 9,
			Date2 = "8SwRXz",
			PaymentMethodCode = "Ni1",
			Date3 = "WHqyAh",
			CheckNumber = "E",
			IndustryCode2 = "H",
			IndustryCode3 = "P",
			FreeFormMessageText = "a",
		};

		var actual = Map.MapObject<STC_StatusInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("j", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new STC_StatusInformation();
		//Required fields
		//Test Parameters
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
