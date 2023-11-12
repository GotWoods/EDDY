using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class ANITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ANI*5*xeaZWvyW*07g8B0H3*4*Bm*1*w*WizLEjYO*H";

		var expected = new ANI_AnimalIdentification()
		{
			ReferenceIdentification = "5",
			Date = "xeaZWvyW",
			Date2 = "07g8B0H3",
			TestPeriodOrIntervalValue = 4,
			UnitOfTimePeriodOrInterval = "Bm",
			ReferenceIdentification2 = "1",
			ReferenceIdentification3 = "w",
			Date3 = "WizLEjYO",
			ReferenceIdentification4 = "H",
		};

		var actual = Map.MapObject<ANI_AnimalIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("5", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new ANI_AnimalIdentification();
		//Required fields
		subject.Date = "xeaZWvyW";
		subject.Date2 = "07g8B0H3";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 4;
			subject.UnitOfTimePeriodOrInterval = "Bm";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xeaZWvyW", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new ANI_AnimalIdentification();
		//Required fields
		subject.ReferenceIdentification = "5";
		subject.Date2 = "07g8B0H3";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 4;
			subject.UnitOfTimePeriodOrInterval = "Bm";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("07g8B0H3", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new ANI_AnimalIdentification();
		//Required fields
		subject.ReferenceIdentification = "5";
		subject.Date = "xeaZWvyW";
		//Test Parameters
		subject.Date2 = date2;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 4;
			subject.UnitOfTimePeriodOrInterval = "Bm";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "Bm", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "Bm", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue(int testPeriodOrIntervalValue, string unitOfTimePeriodOrInterval, bool isValidExpected)
	{
		var subject = new ANI_AnimalIdentification();
		//Required fields
		subject.ReferenceIdentification = "5";
		subject.Date = "xeaZWvyW";
		subject.Date2 = "07g8B0H3";
		//Test Parameters
		if (testPeriodOrIntervalValue > 0) 
			subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
