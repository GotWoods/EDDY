using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class ADITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ADI*bE*WRX9ffUf*2*U7";

		var expected = new ADI_AnimalDisposition()
		{
			AnimalDispositionCode = "bE",
			Date = "WRX9ffUf",
			TestPeriodOrIntervalValue = 2,
			UnitOfTimePeriodOrInterval = "U7",
		};

		var actual = Map.MapObject<ADI_AnimalDisposition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("bE", true)]
	public void Validation_RequiredAnimalDispositionCode(string animalDispositionCode, bool isValidExpected)
	{
		var subject = new ADI_AnimalDisposition();
		//Required fields
		subject.Date = "WRX9ffUf";
		//Test Parameters
		subject.AnimalDispositionCode = animalDispositionCode;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 2;
			subject.UnitOfTimePeriodOrInterval = "U7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("WRX9ffUf", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new ADI_AnimalDisposition();
		//Required fields
		subject.AnimalDispositionCode = "bE";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 2;
			subject.UnitOfTimePeriodOrInterval = "U7";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "U7", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "U7", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue(int testPeriodOrIntervalValue, string unitOfTimePeriodOrInterval, bool isValidExpected)
	{
		var subject = new ADI_AnimalDisposition();
		//Required fields
		subject.AnimalDispositionCode = "bE";
		subject.Date = "WRX9ffUf";
		//Test Parameters
		if (testPeriodOrIntervalValue > 0) 
			subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
