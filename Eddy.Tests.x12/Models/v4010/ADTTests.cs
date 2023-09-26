using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class ADTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ADT*R*dIiBVluU*9*0T*ukiHdRMS*5*1Q*V3Jx*1*Pf";

		var expected = new ADT_AnimalParturitionStatus()
		{
			ParturitionStatusCode = "R",
			Date = "dIiBVluU",
			TestPeriodOrIntervalValue = 9,
			UnitOfTimePeriodOrInterval = "0T",
			Date2 = "ukiHdRMS",
			TestPeriodOrIntervalValue2 = 5,
			UnitOfTimePeriodOrInterval2 = "1Q",
			Time = "V3Jx",
			TestPeriodOrIntervalValue3 = 1,
			UnitOfTimePeriodOrInterval3 = "Pf",
		};

		var actual = Map.MapObject<ADT_AnimalParturitionStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("R", true)]
	public void Validation_RequiredParturitionStatusCode(string parturitionStatusCode, bool isValidExpected)
	{
		var subject = new ADT_AnimalParturitionStatus();
		//Required fields
		//Test Parameters
		subject.ParturitionStatusCode = parturitionStatusCode;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 9;
			subject.UnitOfTimePeriodOrInterval = "0T";
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 5;
			subject.UnitOfTimePeriodOrInterval2 = "1Q";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 1;
			subject.UnitOfTimePeriodOrInterval3 = "Pf";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(9, "0T", true)]
	[InlineData(9, "", false)]
	[InlineData(0, "0T", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue(int testPeriodOrIntervalValue, string unitOfTimePeriodOrInterval, bool isValidExpected)
	{
		var subject = new ADT_AnimalParturitionStatus();
		//Required fields
		subject.ParturitionStatusCode = "R";
		//Test Parameters
		if (testPeriodOrIntervalValue > 0) 
			subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 5;
			subject.UnitOfTimePeriodOrInterval2 = "1Q";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 1;
			subject.UnitOfTimePeriodOrInterval3 = "Pf";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "1Q", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "1Q", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue2(int testPeriodOrIntervalValue2, string unitOfTimePeriodOrInterval2, bool isValidExpected)
	{
		var subject = new ADT_AnimalParturitionStatus();
		//Required fields
		subject.ParturitionStatusCode = "R";
		//Test Parameters
		if (testPeriodOrIntervalValue2 > 0) 
			subject.TestPeriodOrIntervalValue2 = testPeriodOrIntervalValue2;
		subject.UnitOfTimePeriodOrInterval2 = unitOfTimePeriodOrInterval2;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 9;
			subject.UnitOfTimePeriodOrInterval = "0T";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval3))
		{
			subject.TestPeriodOrIntervalValue3 = 1;
			subject.UnitOfTimePeriodOrInterval3 = "Pf";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(1, "Pf", true)]
	[InlineData(1, "", false)]
	[InlineData(0, "Pf", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue3(int testPeriodOrIntervalValue3, string unitOfTimePeriodOrInterval3, bool isValidExpected)
	{
		var subject = new ADT_AnimalParturitionStatus();
		//Required fields
		subject.ParturitionStatusCode = "R";
		//Test Parameters
		if (testPeriodOrIntervalValue3 > 0) 
			subject.TestPeriodOrIntervalValue3 = testPeriodOrIntervalValue3;
		subject.UnitOfTimePeriodOrInterval3 = unitOfTimePeriodOrInterval3;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 9;
			subject.UnitOfTimePeriodOrInterval = "0T";
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 5;
			subject.UnitOfTimePeriodOrInterval2 = "1Q";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
