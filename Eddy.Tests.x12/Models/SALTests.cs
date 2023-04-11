using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class SALTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SAL*N*i*LAd*3*Qb*P8NZQDRP*GEWM2BId";

		var expected = new SAL_SalaryInformation()
		{
			YesNoConditionOrResponseCode = "N",
			Amount = "i",
			LaborRate = "LAd",
			NumberOfPeriods = 3,
			UnitOfTimePeriodOrIntervalCode = "Qb",
			Date = "P8NZQDRP",
			Date2 = "GEWM2BId",
		};

		var actual = Map.MapObject<SAL_SalaryInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("N", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new SAL_SalaryInformation();
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("", "LAd", true)]
	[InlineData("i", "", false)]
	public void Validation_ARequiresBAmount(string amount, string laborRate, bool isValidExpected)
	{
		var subject = new SAL_SalaryInformation();
		subject.YesNoConditionOrResponseCode = "N";
		subject.Amount = amount;
		subject.LaborRate = laborRate;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
