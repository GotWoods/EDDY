using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class ADTTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ADT*J*Md03JwgF*2*C1*0bzPPjYc*7*CF*w7Te*7*tk";

		var expected = new ADT_AnimalParturitionStatus()
		{
			ParturitionStatusCode = "J",
			Date = "Md03JwgF",
			TestPeriodOrIntervalValue = 2,
			UnitOfTimePeriodOrIntervalCode = "C1",
			Date2 = "0bzPPjYc",
			TestPeriodOrIntervalValue2 = 7,
			UnitOfTimePeriodOrIntervalCode2 = "CF",
			Time = "w7Te",
			TestPeriodOrIntervalValue3 = 7,
			UnitOfTimePeriodOrIntervalCode3 = "tk",
		};

		var actual = Map.MapObject<ADT_AnimalParturitionStatus>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("J", true)]
	public void Validation_RequiredParturitionStatusCode(string parturitionStatusCode, bool isValidExpected)
	{
		var subject = new ADT_AnimalParturitionStatus();
		//Required fields
		//Test Parameters
		subject.ParturitionStatusCode = parturitionStatusCode;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode))
		{
			subject.TestPeriodOrIntervalValue = 2;
			subject.UnitOfTimePeriodOrIntervalCode = "C1";
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode2))
		{
			subject.TestPeriodOrIntervalValue2 = 7;
			subject.UnitOfTimePeriodOrIntervalCode2 = "CF";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode3))
		{
			subject.TestPeriodOrIntervalValue3 = 7;
			subject.UnitOfTimePeriodOrIntervalCode3 = "tk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "C1", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "C1", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue(int testPeriodOrIntervalValue, string unitOfTimePeriodOrIntervalCode, bool isValidExpected)
	{
		var subject = new ADT_AnimalParturitionStatus();
		//Required fields
		subject.ParturitionStatusCode = "J";
		//Test Parameters
		if (testPeriodOrIntervalValue > 0) 
			subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
		subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode2))
		{
			subject.TestPeriodOrIntervalValue2 = 7;
			subject.UnitOfTimePeriodOrIntervalCode2 = "CF";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode3))
		{
			subject.TestPeriodOrIntervalValue3 = 7;
			subject.UnitOfTimePeriodOrIntervalCode3 = "tk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "CF", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "CF", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue2(int testPeriodOrIntervalValue2, string unitOfTimePeriodOrIntervalCode2, bool isValidExpected)
	{
		var subject = new ADT_AnimalParturitionStatus();
		//Required fields
		subject.ParturitionStatusCode = "J";
		//Test Parameters
		if (testPeriodOrIntervalValue2 > 0) 
			subject.TestPeriodOrIntervalValue2 = testPeriodOrIntervalValue2;
		subject.UnitOfTimePeriodOrIntervalCode2 = unitOfTimePeriodOrIntervalCode2;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode))
		{
			subject.TestPeriodOrIntervalValue = 2;
			subject.UnitOfTimePeriodOrIntervalCode = "C1";
		}
		if(subject.TestPeriodOrIntervalValue3 > 0 || subject.TestPeriodOrIntervalValue3 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode3))
		{
			subject.TestPeriodOrIntervalValue3 = 7;
			subject.UnitOfTimePeriodOrIntervalCode3 = "tk";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "tk", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "tk", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue3(int testPeriodOrIntervalValue3, string unitOfTimePeriodOrIntervalCode3, bool isValidExpected)
	{
		var subject = new ADT_AnimalParturitionStatus();
		//Required fields
		subject.ParturitionStatusCode = "J";
		//Test Parameters
		if (testPeriodOrIntervalValue3 > 0) 
			subject.TestPeriodOrIntervalValue3 = testPeriodOrIntervalValue3;
		subject.UnitOfTimePeriodOrIntervalCode3 = unitOfTimePeriodOrIntervalCode3;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode))
		{
			subject.TestPeriodOrIntervalValue = 2;
			subject.UnitOfTimePeriodOrIntervalCode = "C1";
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode2))
		{
			subject.TestPeriodOrIntervalValue2 = 7;
			subject.UnitOfTimePeriodOrIntervalCode2 = "CF";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
