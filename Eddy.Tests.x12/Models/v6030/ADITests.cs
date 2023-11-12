using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class ADITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ADI*GP*MloYJj4J*2*uq";

		var expected = new ADI_AnimalDisposition()
		{
			AnimalDispositionCode = "GP",
			Date = "MloYJj4J",
			TestPeriodOrIntervalValue = 2,
			UnitOfTimePeriodOrIntervalCode = "uq",
		};

		var actual = Map.MapObject<ADI_AnimalDisposition>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("GP", true)]
	public void Validation_RequiredAnimalDispositionCode(string animalDispositionCode, bool isValidExpected)
	{
		var subject = new ADI_AnimalDisposition();
		//Required fields
		subject.Date = "MloYJj4J";
		//Test Parameters
		subject.AnimalDispositionCode = animalDispositionCode;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode))
		{
			subject.TestPeriodOrIntervalValue = 2;
			subject.UnitOfTimePeriodOrIntervalCode = "uq";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("MloYJj4J", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new ADI_AnimalDisposition();
		//Required fields
		subject.AnimalDispositionCode = "GP";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode))
		{
			subject.TestPeriodOrIntervalValue = 2;
			subject.UnitOfTimePeriodOrIntervalCode = "uq";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "uq", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "uq", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue(int testPeriodOrIntervalValue, string unitOfTimePeriodOrIntervalCode, bool isValidExpected)
	{
		var subject = new ADI_AnimalDisposition();
		//Required fields
		subject.AnimalDispositionCode = "GP";
		subject.Date = "MloYJj4J";
		//Test Parameters
		if (testPeriodOrIntervalValue > 0) 
			subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
		subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
