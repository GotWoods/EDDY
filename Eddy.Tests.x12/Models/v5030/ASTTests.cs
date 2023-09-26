using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class ASTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AST*t*N*qfgYEh5g*3*cB*CWG79dII*2*8n*IcZlYySC*6*8I";

		var expected = new AST_AnimalReproductiveStatus()
		{
			YesNoConditionOrResponseCode = "t",
			ReferenceIdentification = "N",
			Date = "qfgYEh5g",
			TestPeriodOrIntervalValue = 3,
			UnitOfTimePeriodOrInterval = "cB",
			Date2 = "CWG79dII",
			TestPeriodOrIntervalValue2 = 2,
			UnitOfTimePeriodOrInterval2 = "8n",
			Date3 = "IcZlYySC",
			TestPeriodOrIntervalValue3 = 6,
			UnitOfTimePeriodOrInterval3 = "8I",
		};

		var actual = Map.MapObject<AST_AnimalReproductiveStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("t", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new AST_AnimalReproductiveStatus();
		//Required fields
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 3;
			subject.UnitOfTimePeriodOrInterval = "cB";
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 2;
			subject.UnitOfTimePeriodOrInterval2 = "8n";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 6;
			subject.UnitOfTimePeriodOrInterval3 = "8I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(3, "cB", true)]
	[InlineData(3, "", false)]
	[InlineData(0, "cB", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue(int testPeriodOrIntervalValue, string unitOfTimePeriodOrInterval, bool isValidExpected)
	{
		var subject = new AST_AnimalReproductiveStatus();
		//Required fields
		subject.YesNoConditionOrResponseCode = "t";
		//Test Parameters
		if (testPeriodOrIntervalValue > 0) 
			subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 2;
			subject.UnitOfTimePeriodOrInterval2 = "8n";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 6;
			subject.UnitOfTimePeriodOrInterval3 = "8I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "8n", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "8n", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue2(int testPeriodOrIntervalValue2, string unitOfTimePeriodOrInterval2, bool isValidExpected)
	{
		var subject = new AST_AnimalReproductiveStatus();
		//Required fields
		subject.YesNoConditionOrResponseCode = "t";
		//Test Parameters
		if (testPeriodOrIntervalValue2 > 0) 
			subject.TestPeriodOrIntervalValue2 = testPeriodOrIntervalValue2;
		subject.UnitOfTimePeriodOrInterval2 = unitOfTimePeriodOrInterval2;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 3;
			subject.UnitOfTimePeriodOrInterval = "cB";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 6;
			subject.UnitOfTimePeriodOrInterval3 = "8I";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(6, "8I", true)]
	[InlineData(6, "", false)]
	[InlineData(0, "8I", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue3(int testPeriodOrIntervalValue3, string unitOfTimePeriodOrInterval3, bool isValidExpected)
	{
		var subject = new AST_AnimalReproductiveStatus();
		//Required fields
		subject.YesNoConditionOrResponseCode = "t";
		//Test Parameters
		if (testPeriodOrIntervalValue3 > 0) 
			subject.TestPeriodOrIntervalValue3 = testPeriodOrIntervalValue3;
		subject.UnitOfTimePeriodOrInterval3 = unitOfTimePeriodOrInterval3;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 3;
			subject.UnitOfTimePeriodOrInterval = "cB";
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 2;
			subject.UnitOfTimePeriodOrInterval2 = "8n";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
