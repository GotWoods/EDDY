using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G42Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G42*95*q";

		var expected = new G42_PromotionAnnouncementIdentification()
		{
			PromotionStatusCode = "95",
			AllowanceOrChargeNumber = "q",
		};

		var actual = Map.MapObject<G42_PromotionAnnouncementIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("95", true)]
	public void Validation_RequiredPromotionStatusCode(string promotionStatusCode, bool isValidExpected)
	{
		var subject = new G42_PromotionAnnouncementIdentification();
		subject.PromotionStatusCode = promotionStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
