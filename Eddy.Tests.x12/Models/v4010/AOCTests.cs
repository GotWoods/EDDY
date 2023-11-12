using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class AOCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AOC*rT*5*JttvMAOH*5*gS";

		var expected = new AOC_AnimalOffspringCounts()
		{
			OffspringCountCode = "rT",
			Count = 5,
			Date = "JttvMAOH",
			TestPeriodOrIntervalValue = 5,
			UnitOfTimePeriodOrInterval = "gS",
		};

		var actual = Map.MapObject<AOC_AnimalOffspringCounts>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("rT", true)]
	public void Validation_RequiredOffspringCountCode(string offspringCountCode, bool isValidExpected)
	{
		var subject = new AOC_AnimalOffspringCounts();
		//Required fields
		subject.Count = 5;
		//Test Parameters
		subject.OffspringCountCode = offspringCountCode;
		//At Least one
		subject.Date = "JttvMAOH";
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 5;
			subject.UnitOfTimePeriodOrInterval = "gS";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredCount(int count, bool isValidExpected)
	{
		var subject = new AOC_AnimalOffspringCounts();
		//Required fields
		subject.OffspringCountCode = "rT";
		//Test Parameters
		if (count > 0) 
			subject.Count = count;
		//At Least one
		subject.Date = "JttvMAOH";
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 5;
			subject.UnitOfTimePeriodOrInterval = "gS";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, false)]
	[InlineData("JttvMAOH", 5, true)]
	[InlineData("JttvMAOH", 0, true)]
	[InlineData("", 5, true)]
	public void Validation_AtLeastOneDate(string date, int testPeriodOrIntervalValue, bool isValidExpected)
	{
		var subject = new AOC_AnimalOffspringCounts();
		//Required fields
		subject.OffspringCountCode = "rT";
		subject.Count = 5;
		//Test Parameters
		subject.Date = date;
		if (testPeriodOrIntervalValue > 0) 
			subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 5;
			subject.UnitOfTimePeriodOrInterval = "gS";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "gS", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "gS", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue(int testPeriodOrIntervalValue, string unitOfTimePeriodOrInterval, bool isValidExpected)
	{
		var subject = new AOC_AnimalOffspringCounts();
		//Required fields
		subject.OffspringCountCode = "rT";
		subject.Count = 5;
		//Test Parameters
		if (testPeriodOrIntervalValue > 0) 
			subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		//At Least one
		subject.Date = "JttvMAOH";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
