using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.Tests.Models.v4020;

public class SALTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SAL*N*G*1b4*4*Yi*yW80Cndr*xXCvXaz3";

		var expected = new SAL_SalaryInformation()
		{
			YesNoConditionOrResponseCode = "N",
			Amount = "G",
			LaborRate = "1b4",
			NumberOfPeriods = 4,
			UnitOfTimePeriodOrInterval = "Yi",
			Date = "yW80Cndr",
			Date2 = "xXCvXaz3",
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
		//Required fields
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", "", true)]
	[InlineData("G", "1b4", true)]
	[InlineData("G", "", false)]
	[InlineData("", "1b4", true)]
	public void Validation_ARequiresBAmount(string amount, string laborRate, bool isValidExpected)
	{
		var subject = new SAL_SalaryInformation();
		//Required fields
		subject.YesNoConditionOrResponseCode = "N";
		//Test Parameters
		subject.Amount = amount;
		subject.LaborRate = laborRate;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.ARequiresB);
	}

}
