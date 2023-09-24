using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class G42Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G42*RC*9";

		var expected = new G42_PromotionAnnouncementIdentification()
		{
			PromotionStatusCode = "RC",
			AllowanceOrChargeNumber = "9",
		};

		var actual = Map.MapObject<G42_PromotionAnnouncementIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("RC", true)]
	public void Validation_RequiredPromotionStatusCode(string promotionStatusCode, bool isValidExpected)
	{
		var subject = new G42_PromotionAnnouncementIdentification();
		subject.AllowanceOrChargeNumber = "9";
		subject.PromotionStatusCode = promotionStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("9", true)]
	public void Validation_RequiredAllowanceOrChargeNumber(string allowanceOrChargeNumber, bool isValidExpected)
	{
		var subject = new G42_PromotionAnnouncementIdentification();
		subject.PromotionStatusCode = "RC";
		subject.AllowanceOrChargeNumber = allowanceOrChargeNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
