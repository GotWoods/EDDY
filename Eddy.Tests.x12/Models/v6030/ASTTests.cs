using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class ASTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AST*C*7*dRMKruZK*1*N5*zYgS1XkE*2*TJ*mM9E19nr*1*gE";

		var expected = new AST_AnimalReproductiveStatus()
		{
			YesNoConditionOrResponseCode = "C",
			ReferenceIdentification = "7",
			Date = "dRMKruZK",
			TestPeriodOrIntervalValue = 1,
			UnitOfTimePeriodOrIntervalCode = "N5",
			Date2 = "zYgS1XkE",
			TestPeriodOrIntervalValue2 = 2,
			UnitOfTimePeriodOrIntervalCode2 = "TJ",
			Date3 = "mM9E19nr",
			TestPeriodOrIntervalValue3 = 1,
			UnitOfTimePeriodOrIntervalCode3 = "gE",
		};

		var actual = Map.MapObject<AST_AnimalReproductiveStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("C", true)]
	public void Validation_RequiredYesNoConditionOrResponseCode(string yesNoConditionOrResponseCode, bool isValidExpected)
	{
		var subject = new AST_AnimalReproductiveStatus();
		//Required fields
		//Test Parameters
		subject.YesNoConditionOrResponseCode = yesNoConditionOrResponseCode;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode))
		{
			subject.TestPeriodOrIntervalValue = 1;
			subject.UnitOfTimePeriodOrIntervalCode = "N5";
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode2))
		{
			subject.TestPeriodOrIntervalValue2 = 2;
			subject.UnitOfTimePeriodOrIntervalCode2 = "TJ";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode3))
		{
			subject.TestPeriodOrIntervalValue3 = 1;
			subject.UnitOfTimePeriodOrIntervalCode3 = "gE";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "N5", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "N5", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue(int testPeriodOrIntervalValue, string unitOfTimePeriodOrIntervalCode, bool isValidExpected)
	{
		var subject = new AST_AnimalReproductiveStatus();
		//Required fields
		subject.YesNoConditionOrResponseCode = "C";
		//Test Parameters
		if (testPeriodOrIntervalValue > 0) 
			subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
		subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode2))
		{
			subject.TestPeriodOrIntervalValue2 = 2;
			subject.UnitOfTimePeriodOrIntervalCode2 = "TJ";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode3))
		{
			subject.TestPeriodOrIntervalValue3 = 1;
			subject.UnitOfTimePeriodOrIntervalCode3 = "gE";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "TJ", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "TJ", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue2(int testPeriodOrIntervalValue2, string unitOfTimePeriodOrIntervalCode2, bool isValidExpected)
	{
		var subject = new AST_AnimalReproductiveStatus();
		//Required fields
		subject.YesNoConditionOrResponseCode = "C";
		//Test Parameters
		if (testPeriodOrIntervalValue2 > 0) 
			subject.TestPeriodOrIntervalValue2 = testPeriodOrIntervalValue2;
		subject.UnitOfTimePeriodOrIntervalCode2 = unitOfTimePeriodOrIntervalCode2;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode))
		{
			subject.TestPeriodOrIntervalValue = 1;
			subject.UnitOfTimePeriodOrIntervalCode = "N5";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode3))
		{
			subject.TestPeriodOrIntervalValue3 = 1;
			subject.UnitOfTimePeriodOrIntervalCode3 = "gE";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "gE", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "gE", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue3(int testPeriodOrIntervalValue3, string unitOfTimePeriodOrIntervalCode3, bool isValidExpected)
	{
		var subject = new AST_AnimalReproductiveStatus();
		//Required fields
		subject.YesNoConditionOrResponseCode = "C";
		//Test Parameters
		if (testPeriodOrIntervalValue3 > 0) 
			subject.TestPeriodOrIntervalValue3 = testPeriodOrIntervalValue3;
		subject.UnitOfTimePeriodOrIntervalCode3 = unitOfTimePeriodOrIntervalCode3;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode))
		{
			subject.TestPeriodOrIntervalValue = 1;
			subject.UnitOfTimePeriodOrIntervalCode = "N5";
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode2))
		{
			subject.TestPeriodOrIntervalValue2 = 2;
			subject.UnitOfTimePeriodOrIntervalCode2 = "TJ";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
