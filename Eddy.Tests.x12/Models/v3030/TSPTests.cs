using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class TSPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "TSP*dQ*u*8*9G";

		var expected = new TSP_TestPeriodOrInterval()
		{
			TestPeriodOrIntervalQualifier = "dQ",
			AssignedIdentification = "u",
			TestPeriodOrIntervalValue = 8,
			UnitOfTimePeriodOrInterval = "9G",
		};

		var actual = Map.MapObject<TSP_TestPeriodOrInterval>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("dQ", true)]
	public void Validation_RequiredTestPeriodOrIntervalQualifier(string testPeriodOrIntervalQualifier, bool isValidExpected)
	{
		var subject = new TSP_TestPeriodOrInterval();
		//Required fields
		//Test Parameters
		subject.TestPeriodOrIntervalQualifier = testPeriodOrIntervalQualifier;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 8;
			subject.UnitOfTimePeriodOrInterval = "9G";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "9G", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "9G", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue(int testPeriodOrIntervalValue, string unitOfTimePeriodOrInterval, bool isValidExpected)
	{
		var subject = new TSP_TestPeriodOrInterval();
		//Required fields
		subject.TestPeriodOrIntervalQualifier = "dQ";
		//Test Parameters
		if (testPeriodOrIntervalValue > 0) 
			subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
