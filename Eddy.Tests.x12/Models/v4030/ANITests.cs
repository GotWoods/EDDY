using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.Tests.Models.v4030;

public class ANITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ANI*0*gmgilXWm*Su5sQSYx*7*kE*T*n*PpqsdafU*6";

		var expected = new ANI_AnimalIdentification()
		{
			ReferenceIdentification = "0",
			Date = "gmgilXWm",
			Date2 = "Su5sQSYx",
			TestPeriodOrIntervalValue = 7,
			UnitOfTimePeriodOrInterval = "kE",
			ReferenceIdentification2 = "T",
			ReferenceIdentification3 = "n",
			Date3 = "PpqsdafU",
			ReferenceIdentification4 = "6",
		};

		var actual = Map.MapObject<ANI_AnimalIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("0", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new ANI_AnimalIdentification();
		//Required fields
		subject.Date = "gmgilXWm";
		subject.Date2 = "Su5sQSYx";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 7;
			subject.UnitOfTimePeriodOrInterval = "kE";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("gmgilXWm", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new ANI_AnimalIdentification();
		//Required fields
		subject.ReferenceIdentification = "0";
		subject.Date2 = "Su5sQSYx";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 7;
			subject.UnitOfTimePeriodOrInterval = "kE";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("Su5sQSYx", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new ANI_AnimalIdentification();
		//Required fields
		subject.ReferenceIdentification = "0";
		subject.Date = "gmgilXWm";
		//Test Parameters
		subject.Date2 = date2;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 7;
			subject.UnitOfTimePeriodOrInterval = "kE";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "kE", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "kE", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue(int testPeriodOrIntervalValue, string unitOfTimePeriodOrInterval, bool isValidExpected)
	{
		var subject = new ANI_AnimalIdentification();
		//Required fields
		subject.ReferenceIdentification = "0";
		subject.Date = "gmgilXWm";
		subject.Date2 = "Su5sQSYx";
		//Test Parameters
		if (testPeriodOrIntervalValue > 0) 
			subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
