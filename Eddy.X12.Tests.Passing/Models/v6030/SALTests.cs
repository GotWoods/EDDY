using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class SALTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SAL*a*8*4zJ*3*rN*uCAn4VTZ*MJR9UHn4";

		var expected = new SAL_SalaryInformation()
		{
			YesNoConditionOrResponseCode = "a",
			Amount = "8",
			LaborRate = "4zJ",
			NumberOfPeriods = 3,
			UnitOfTimePeriodOrIntervalCode = "rN",
			Date = "uCAn4VTZ",
			Date2 = "MJR9UHn4",
		};

		var actual = Map.MapObject<SAL_SalaryInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new SAL_SalaryInformation();
		//Required fields
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("8", "4zJ", true)]
	[InlineData("8", "", false)]
	[InlineData("", "4zJ", true)]
	public void Validation_ARequiresBAmount(string amount, string laborRate, bool isValidExpected)
	{
		var subject = new SAL_SalaryInformation();
		//Required fields
		subject.YesNoConditionOrResponseCode = "a";
		//Test Parameters
		subject.Amount = amount;
		subject.LaborRate = laborRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
