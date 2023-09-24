using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.Tests.Models.v3020;

public class MCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MC*Yd9*vi*5*JO*9";

		var expected = new MC_MiscellaneousAndAccessorialCharges()
		{
			SpecialChargeOrAllowanceCode = "Yd9",
			RateValueQualifier = "vi",
			SpecialCharge = 5,
			SpecialChargeDescription = "JO",
			AssignedNumber = 9,
		};

		var actual = Map.MapObject<MC_MiscellaneousAndAccessorialCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Yd9", true)]
	public void Validation_RequiredSpecialChargeOrAllowanceCode(string specialChargeOrAllowanceCode, bool isValidExpected)
	{
		var subject = new MC_MiscellaneousAndAccessorialCharges();
		subject.RateValueQualifier = "vi";
		subject.SpecialCharge = 5;
		subject.SpecialChargeOrAllowanceCode = specialChargeOrAllowanceCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("vi", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new MC_MiscellaneousAndAccessorialCharges();
		subject.SpecialChargeOrAllowanceCode = "Yd9";
		subject.SpecialCharge = 5;
		subject.RateValueQualifier = rateValueQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredSpecialCharge(decimal specialCharge, bool isValidExpected)
	{
		var subject = new MC_MiscellaneousAndAccessorialCharges();
		subject.SpecialChargeOrAllowanceCode = "Yd9";
		subject.RateValueQualifier = "vi";
		if (specialCharge > 0)
			subject.SpecialCharge = specialCharge;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
