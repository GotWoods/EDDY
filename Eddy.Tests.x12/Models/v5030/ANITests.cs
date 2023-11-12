using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v5030;

namespace Eddy.x12.Tests.Models.v5030;

public class ANITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ANI*y*a35O6GU8*YiShPHiI*4*5z*a*b*38kWdQmT*m";

		var expected = new ANI_AnimalIdentification()
		{
			ReferenceIdentification = "y",
			Date = "a35O6GU8",
			Date2 = "YiShPHiI",
			TestPeriodOrIntervalValue = 4,
			UnitOfTimePeriodOrInterval = "5z",
			ReferenceIdentification2 = "a",
			ReferenceIdentification3 = "b",
			Date3 = "38kWdQmT",
			ReferenceIdentification4 = "m",
		};

		var actual = Map.MapObject<ANI_AnimalIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("y", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new ANI_AnimalIdentification();
		//Required fields
		subject.Date = "a35O6GU8";
		subject.Date2 = "YiShPHiI";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 4;
			subject.UnitOfTimePeriodOrInterval = "5z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("a35O6GU8", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new ANI_AnimalIdentification();
		//Required fields
		subject.ReferenceIdentification = "y";
		subject.Date2 = "YiShPHiI";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 4;
			subject.UnitOfTimePeriodOrInterval = "5z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("YiShPHiI", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new ANI_AnimalIdentification();
		//Required fields
		subject.ReferenceIdentification = "y";
		subject.Date = "a35O6GU8";
		//Test Parameters
		subject.Date2 = date2;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 4;
			subject.UnitOfTimePeriodOrInterval = "5z";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "5z", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "5z", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue(int testPeriodOrIntervalValue, string unitOfTimePeriodOrInterval, bool isValidExpected)
	{
		var subject = new ANI_AnimalIdentification();
		//Required fields
		subject.ReferenceIdentification = "y";
		subject.Date = "a35O6GU8";
		subject.Date2 = "YiShPHiI";
		//Test Parameters
		if (testPeriodOrIntervalValue > 0) 
			subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
