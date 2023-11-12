using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class MCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "MC*toc*ct*1*m8*8";

		var expected = new MC_MiscellaneousAndAccessorialCharges()
		{
			SpecialChargeCode = "toc",
			RateValueQualifier = "ct",
			SpecialCharge = 1,
			SpecialChargeDescription = "m8",
			AssignedNumber = 8,
		};

		var actual = Map.MapObject<MC_MiscellaneousAndAccessorialCharges>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("toc", true)]
	public void Validation_RequiredSpecialChargeCode(string specialChargeCode, bool isValidExpected)
	{
		var subject = new MC_MiscellaneousAndAccessorialCharges();
		subject.RateValueQualifier = "ct";
		subject.SpecialCharge = 1;
		subject.SpecialChargeCode = specialChargeCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("ct", true)]
	public void Validation_RequiredRateValueQualifier(string rateValueQualifier, bool isValidExpected)
	{
		var subject = new MC_MiscellaneousAndAccessorialCharges();
		subject.SpecialChargeCode = "toc";
		subject.SpecialCharge = 1;
		subject.RateValueQualifier = rateValueQualifier;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredSpecialCharge(decimal specialCharge, bool isValidExpected)
	{
		var subject = new MC_MiscellaneousAndAccessorialCharges();
		subject.SpecialChargeCode = "toc";
		subject.RateValueQualifier = "ct";
		if (specialCharge > 0)
			subject.SpecialCharge = specialCharge;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
