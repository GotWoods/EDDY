using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class TSPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TSP*Fz*J*5*eB";

		var expected = new TSP_TestPeriodOrInterval()
		{
			TestPeriodOrIntervalQualifier = "Fz",
			AssignedIdentification = "J",
			TestPeriodOrIntervalValue = 5,
			UnitOfTimePeriodOrIntervalCode = "eB",
		};

		var actual = Map.MapObject<TSP_TestPeriodOrInterval>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Fz", true)]
	public void Validation_RequiredTestPeriodOrIntervalQualifier(string testPeriodOrIntervalQualifier, bool isValidExpected)
	{
		var subject = new TSP_TestPeriodOrInterval();
		//Required fields
		//Test Parameters
		subject.TestPeriodOrIntervalQualifier = testPeriodOrIntervalQualifier;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode))
		{
			subject.TestPeriodOrIntervalValue = 5;
			subject.UnitOfTimePeriodOrIntervalCode = "eB";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "eB", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "eB", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue(int testPeriodOrIntervalValue, string unitOfTimePeriodOrIntervalCode, bool isValidExpected)
	{
		var subject = new TSP_TestPeriodOrInterval();
		//Required fields
		subject.TestPeriodOrIntervalQualifier = "Fz";
		//Test Parameters
		if (testPeriodOrIntervalValue > 0) 
			subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
		subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
