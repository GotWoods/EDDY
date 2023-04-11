using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G42Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G42*6x*c*Yv";

		var expected = new G42_PromotionAnnouncementIdentification()
		{
			PromotionStatusCode = "6x",
			AllowanceOrChargeNumber = "c",
			TransactionTypeCode = "Yv",
		};

		var actual = Map.MapObject<G42_PromotionAnnouncementIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6x", true)]
	public void Validation_RequiredPromotionStatusCode(string promotionStatusCode, bool isValidExpected)
	{
		var subject = new G42_PromotionAnnouncementIdentification();
		subject.AllowanceOrChargeNumber = "c";
		subject.PromotionStatusCode = promotionStatusCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("c", true)]
	public void Validation_RequiredAllowanceOrChargeNumber(string allowanceOrChargeNumber, bool isValidExpected)
	{
		var subject = new G42_PromotionAnnouncementIdentification();
		subject.PromotionStatusCode = "6x";
		subject.AllowanceOrChargeNumber = allowanceOrChargeNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
