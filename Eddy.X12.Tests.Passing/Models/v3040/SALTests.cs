using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3040;

namespace Eddy.x12.Tests.Models.v3040;

public class SALTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "SAL*y*V*zwE*5*Yg*1UUdeT*VZHQcO";

		var expected = new SAL_SalaryInformation()
		{
			YesNoConditionOrResponseCode = "y",
			Amount = "V",
			LaborRate = "zwE",
			NumberOfPeriods = 5,
			UnitOfTimePeriodOrInterval = "Yg",
			Date = "1UUdeT",
			Date2 = "VZHQcO",
		};

		var actual = Map.MapObject<SAL_SalaryInformation>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new SAL_SalaryInformation();
		//Required fields
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
