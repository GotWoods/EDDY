using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class AOCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AOC*m8*2*ke7CVW*7*ZX";

		var expected = new AOC_AnimalOffspringCounts()
		{
			OffspringCountCode = "m8",
			Count = 2,
			Date = "ke7CVW",
			TestPeriodOrIntervalValue = 7,
			UnitOfTimePeriodOrInterval = "ZX",
		};

		var actual = Map.MapObject<AOC_AnimalOffspringCounts>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("m8", true)]
	public void Validation_RequiredOffspringCountCode(string offspringCountCode, bool isValidExpected)
	{
		var subject = new AOC_AnimalOffspringCounts();
		//Required fields
		subject.Count = 2;
		//Test Parameters
		subject.OffspringCountCode = offspringCountCode;
		//At Least one
		subject.Date = "ke7CVW";
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 7;
			subject.UnitOfTimePeriodOrInterval = "ZX";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredCount(int count, bool isValidExpected)
	{
		var subject = new AOC_AnimalOffspringCounts();
		//Required fields
		subject.OffspringCountCode = "m8";
		//Test Parameters
		if (count > 0) 
			subject.Count = count;
		//At Least one
		subject.Date = "ke7CVW";
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 7;
			subject.UnitOfTimePeriodOrInterval = "ZX";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, false)]
	[InlineData("ke7CVW", 7, true)]
	[InlineData("ke7CVW", 0, true)]
	[InlineData("", 7, true)]
	public void Validation_AtLeastOneDate(string date, int testPeriodOrIntervalValue, bool isValidExpected)
	{
		var subject = new AOC_AnimalOffspringCounts();
		//Required fields
		subject.OffspringCountCode = "m8";
		subject.Count = 2;
		//Test Parameters
		subject.Date = date;
		if (testPeriodOrIntervalValue > 0) 
			subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 7;
			subject.UnitOfTimePeriodOrInterval = "ZX";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "ZX", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "ZX", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue(int testPeriodOrIntervalValue, string unitOfTimePeriodOrInterval, bool isValidExpected)
	{
		var subject = new AOC_AnimalOffspringCounts();
		//Required fields
		subject.OffspringCountCode = "m8";
		subject.Count = 2;
		//Test Parameters
		if (testPeriodOrIntervalValue > 0) 
			subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		//At Least one
		subject.Date = "ke7CVW";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
