using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class SALTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SAL*t*2*Fd0*1*xL*90wR17*Yh6i2y";

		var expected = new SAL_SalaryInformation()
		{
			YesNoConditionOrResponseCode = "t",
			Amount = "2",
			LaborRate = "Fd0",
			NumberOfPeriods = 1,
			UnitOfTimePeriodOrInterval = "xL",
			Date = "90wR17",
			Date2 = "Yh6i2y",
		};

		var actual = Map.MapObject<SAL_SalaryInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new SAL_SalaryInformation();
		//Required fields
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
