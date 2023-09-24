using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class G90Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G90*v*C";

		var expected = new G90_PromotionAnnouncementChangeID()
		{
			ChangeTypeCode = "v",
			AllowanceOrChargeNumber = "C",
		};

		var actual = Map.MapObject<G90_PromotionAnnouncementChangeID>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("v", true)]
	public void Validation_RequiredChangeTypeCode(string changeTypeCode, bool isValidExpected)
	{
		var subject = new G90_PromotionAnnouncementChangeID();
		subject.AllowanceOrChargeNumber = "C";
		subject.ChangeTypeCode = changeTypeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredAllowanceOrChargeNumber(string allowanceOrChargeNumber, bool isValidExpected)
	{
		var subject = new G90_PromotionAnnouncementChangeID();
		subject.ChangeTypeCode = "v";
		subject.AllowanceOrChargeNumber = allowanceOrChargeNumber;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
