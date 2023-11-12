using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class ADITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ADI*Ze*yKnIr9*5*pc";

		var expected = new ADI_AnimalDisposition()
		{
			AnimalDispositionCode = "Ze",
			Date = "yKnIr9",
			TestPeriodOrIntervalValue = 5,
			UnitOfTimePeriodOrInterval = "pc",
		};

		var actual = Map.MapObject<ADI_AnimalDisposition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Ze", true)]
	public void Validation_RequiredAnimalDispositionCode(string animalDispositionCode, bool isValidExpected)
	{
		var subject = new ADI_AnimalDisposition();
		//Required fields
		subject.Date = "yKnIr9";
		//Test Parameters
		subject.AnimalDispositionCode = animalDispositionCode;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 5;
			subject.UnitOfTimePeriodOrInterval = "pc";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("yKnIr9", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new ADI_AnimalDisposition();
		//Required fields
		subject.AnimalDispositionCode = "Ze";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 5;
			subject.UnitOfTimePeriodOrInterval = "pc";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(5, "pc", true)]
	[InlineData(5, "", false)]
	[InlineData(0, "pc", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue(int testPeriodOrIntervalValue, string unitOfTimePeriodOrInterval, bool isValidExpected)
	{
		var subject = new ADI_AnimalDisposition();
		//Required fields
		subject.AnimalDispositionCode = "Ze";
		subject.Date = "yKnIr9";
		//Test Parameters
		if (testPeriodOrIntervalValue > 0) 
			subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
