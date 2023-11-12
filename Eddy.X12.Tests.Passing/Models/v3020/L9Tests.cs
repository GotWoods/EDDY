using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class L9Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "L9*XUj*4";

		var expected = new L9_ChargeDetail()
		{
			SpecialChargeOrAllowanceCode = "XUj",
			SpecialCharge = 4,
		};

		var actual = Map.MapObject<L9_ChargeDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("XUj", true)]
	public void Validation_RequiredSpecialChargeOrAllowanceCode(string specialChargeOrAllowanceCode, bool isValidExpected)
	{
		var subject = new L9_ChargeDetail();
		subject.SpecialCharge = 4;
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredSpecialCharge(decimal specialCharge, bool isValidExpected)
	{
		var subject = new L9_ChargeDetail();
		subject.SpecialChargeOrAllowanceCode = "XUj";
		if (specialCharge > 0)
			subject.SpecialCharge = specialCharge;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
