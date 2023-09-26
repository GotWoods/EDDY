using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class ASTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AST*g*n*YkMBc9*1*0t*5Ic77o*6*aP*GQwKcP*1*bu";

		var expected = new AST_AnimalReproductiveStatus()
		{
			YesNoConditionOrResponseCode = "g",
			ReferenceIdentification = "n",
			Date = "YkMBc9",
			TestPeriodOrIntervalValue = 1,
			UnitOfTimePeriodOrInterval = "0t",
			Date2 = "5Ic77o",
			TestPeriodOrIntervalValue2 = 6,
			UnitOfTimePeriodOrInterval2 = "aP",
			Date3 = "GQwKcP",
			TestPeriodOrIntervalValue3 = 1,
			UnitOfTimePeriodOrInterval3 = "bu",
		};

		var actual = Map.MapObject<AST_AnimalReproductiveStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("g", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new AST_AnimalReproductiveStatus();
		//Required fields
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 1;
			subject.UnitOfTimePeriodOrInterval = "0t";
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 6;
			subject.UnitOfTimePeriodOrInterval2 = "aP";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 1;
			subject.UnitOfTimePeriodOrInterval3 = "bu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "0t", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "0t", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue(int testPeriodOrIntervalValue, string unitOfTimePeriodOrInterval, bool isValidExpected)
	{
		var subject = new AST_AnimalReproductiveStatus();
		//Required fields
		subject.YesNoConditionOrResponseCode = "g";
		//Test Parameters
		if (testPeriodOrIntervalValue > 0) 
			subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 6;
			subject.UnitOfTimePeriodOrInterval2 = "aP";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 1;
			subject.UnitOfTimePeriodOrInterval3 = "bu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "aP", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "aP", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue2(int testPeriodOrIntervalValue2, string unitOfTimePeriodOrInterval2, bool isValidExpected)
	{
		var subject = new AST_AnimalReproductiveStatus();
		//Required fields
		subject.YesNoConditionOrResponseCode = "g";
		//Test Parameters
		if (testPeriodOrIntervalValue2 > 0) 
			subject.TestPeriodOrIntervalValue2 = testPeriodOrIntervalValue2;
		subject.UnitOfTimePeriodOrInterval2 = unitOfTimePeriodOrInterval2;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 1;
			subject.UnitOfTimePeriodOrInterval = "0t";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 1;
			subject.UnitOfTimePeriodOrInterval3 = "bu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "bu", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "bu", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue3(int testPeriodOrIntervalValue3, string unitOfTimePeriodOrInterval3, bool isValidExpected)
	{
		var subject = new AST_AnimalReproductiveStatus();
		//Required fields
		subject.YesNoConditionOrResponseCode = "g";
		//Test Parameters
		if (testPeriodOrIntervalValue3 > 0) 
			subject.TestPeriodOrIntervalValue3 = testPeriodOrIntervalValue3;
		subject.UnitOfTimePeriodOrInterval3 = unitOfTimePeriodOrInterval3;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 1;
			subject.UnitOfTimePeriodOrInterval = "0t";
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 6;
			subject.UnitOfTimePeriodOrInterval2 = "aP";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
