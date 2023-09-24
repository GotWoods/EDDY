using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class G42Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G42*OS*4*Ko";

		var expected = new G42_PromotionAnnouncementIdentification()
		{
			PromotionStatusCode = "OS",
			AllowanceOrChargeNumber = "4",
			TransactionTypeCode = "Ko",
		};

		var actual = Map.MapObject<G42_PromotionAnnouncementIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("OS", true)]
	public void Validation_RequiredPromotionStatusCode(string promotionStatusCode, bool isValidExpected)
	{
		var subject = new G42_PromotionAnnouncementIdentification();
		subject.AllowanceOrChargeNumber = "4";
		subject.PromotionStatusCode = promotionStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("4", true)]
	public void Validation_RequiredAllowanceOrChargeNumber(string allowanceOrChargeNumber, bool isValidExpected)
	{
		var subject = new G42_PromotionAnnouncementIdentification();
		subject.PromotionStatusCode = "OS";
		subject.AllowanceOrChargeNumber = allowanceOrChargeNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
