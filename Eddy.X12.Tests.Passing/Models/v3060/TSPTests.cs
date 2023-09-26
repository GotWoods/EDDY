using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.Tests.Models.v3060;

public class TSPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TSP*8d*F*5*6D";

		var expected = new TSP_TestPeriodOrInterval()
		{
			TestPeriodOrIntervalQualifier = "8d",
			AssignedIdentification = "F",
			TestPeriodOrIntervalValue = 5,
			UnitOfTimePeriodOrInterval = "6D",
		};

		var actual = Map.MapObject<TSP_TestPeriodOrInterval>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("8d", true)]
	public void Validation_RequiredTestPeriodOrIntervalQualifier(string testPeriodOrIntervalQualifier, bool isValidExpected)
	{
		var subject = new TSP_TestPeriodOrInterval();
		//Required fields
		//Test Parameters
		subject.TestPeriodOrIntervalQualifier = testPeriodOrIntervalQualifier;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 5;
			subject.UnitOfTimePeriodOrInterval = "6D";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "6D", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "6D", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue(int testPeriodOrIntervalValue, string unitOfTimePeriodOrInterval, bool isValidExpected)
	{
		var subject = new TSP_TestPeriodOrInterval();
		//Required fields
		subject.TestPeriodOrIntervalQualifier = "8d";
		//Test Parameters
		if (testPeriodOrIntervalValue > 0) 
			subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
