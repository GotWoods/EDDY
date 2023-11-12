using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class AOCTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "AOC*CX*7*Lj9VOBRx*8*ie";

		var expected = new AOC_AnimalOffspringCounts()
		{
			OffspringCountCode = "CX",
			Count = 7,
			Date = "Lj9VOBRx",
			TestPeriodOrIntervalValue = 8,
			UnitOfTimePeriodOrIntervalCode = "ie",
		};

		var actual = Map.MapObject<AOC_AnimalOffspringCounts>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("CX", true)]
	public void Validation_RequiredOffspringCountCode(string offspringCountCode, bool isValidExpected)
	{
		var subject = new AOC_AnimalOffspringCounts();
		//Required fields
		subject.Count = 7;
		//Test Parameters
		subject.OffspringCountCode = offspringCountCode;
		//At Least one
		subject.Date = "Lj9VOBRx";
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode))
		{
			subject.TestPeriodOrIntervalValue = 8;
			subject.UnitOfTimePeriodOrIntervalCode = "ie";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(7, true)]
	public void Validation_RequiredCount(int count, bool isValidExpected)
	{
		var subject = new AOC_AnimalOffspringCounts();
		//Required fields
		subject.OffspringCountCode = "CX";
		//Test Parameters
		if (count > 0) 
			subject.Count = count;
		//At Least one
		subject.Date = "Lj9VOBRx";
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode))
		{
			subject.TestPeriodOrIntervalValue = 8;
			subject.UnitOfTimePeriodOrIntervalCode = "ie";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", 0, false)]
	[InlineData("Lj9VOBRx", 8, true)]
	[InlineData("Lj9VOBRx", 0, true)]
	[InlineData("", 8, true)]
	public void Validation_AtLeastOneDate(string date, int testPeriodOrIntervalValue, bool isValidExpected)
	{
		var subject = new AOC_AnimalOffspringCounts();
		//Required fields
		subject.OffspringCountCode = "CX";
		subject.Count = 7;
		//Test Parameters
		subject.Date = date;
		if (testPeriodOrIntervalValue > 0) 
			subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode))
		{
			subject.TestPeriodOrIntervalValue = 8;
			subject.UnitOfTimePeriodOrIntervalCode = "ie";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.AtLeastOneIsRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "ie", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "ie", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue(int testPeriodOrIntervalValue, string unitOfTimePeriodOrIntervalCode, bool isValidExpected)
	{
		var subject = new AOC_AnimalOffspringCounts();
		//Required fields
		subject.OffspringCountCode = "CX";
		subject.Count = 7;
		//Test Parameters
		if (testPeriodOrIntervalValue > 0) 
			subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
		subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;
		//At Least one
		subject.Date = "Lj9VOBRx";
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
