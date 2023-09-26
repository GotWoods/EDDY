using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class STCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "STC*4*vHvEZK*A*4*8*NTPSx4*tXo*MK2W7k*b*I*4*v";

		var expected = new STC_StatusInformation()
		{
			IndustryCode = "4",
			Date = "vHvEZK",
			ActionCode = "A",
			MonetaryAmount = 4,
			MonetaryAmount2 = 8,
			Date2 = "NTPSx4",
			PaymentMethodCode = "tXo",
			Date3 = "MK2W7k",
			CheckNumber = "b",
			IndustryCode2 = "I",
			IndustryCode3 = "4",
			FreeFormMessageText = "v",
		};

		var actual = Map.MapObject<STC_StatusInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredIndustryCode(string industryCode, bool isValidExpected)
	{
		var subject = new STC_StatusInformation();
		//Required fields
		//Test Parameters
		subject.IndustryCode = industryCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
