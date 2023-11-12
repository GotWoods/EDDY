using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class ANITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ANI*q*6qJTUv*tcghlc*2*eG*h*z*q80AcZ*a";

		var expected = new ANI_AnimalIdentification()
		{
			ReferenceIdentification = "q",
			Date = "6qJTUv",
			Date2 = "tcghlc",
			TestPeriodOrIntervalValue = 2,
			UnitOfTimePeriodOrInterval = "eG",
			ReferenceIdentification2 = "h",
			ReferenceIdentification3 = "z",
			Date3 = "q80AcZ",
			ReferenceIdentification4 = "a",
		};

		var actual = Map.MapObject<ANI_AnimalIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("q", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new ANI_AnimalIdentification();
		//Required fields
		subject.Date = "6qJTUv";
		subject.Date2 = "tcghlc";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 2;
			subject.UnitOfTimePeriodOrInterval = "eG";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("6qJTUv", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new ANI_AnimalIdentification();
		//Required fields
		subject.ReferenceIdentification = "q";
		subject.Date2 = "tcghlc";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 2;
			subject.UnitOfTimePeriodOrInterval = "eG";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("tcghlc", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new ANI_AnimalIdentification();
		//Required fields
		subject.ReferenceIdentification = "q";
		subject.Date = "6qJTUv";
		//Test Parameters
		subject.Date2 = date2;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 2;
			subject.UnitOfTimePeriodOrInterval = "eG";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(2, "eG", true)]
	[InlineData(2, "", false)]
	[InlineData(0, "eG", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue(int testPeriodOrIntervalValue, string unitOfTimePeriodOrInterval, bool isValidExpected)
	{
		var subject = new ANI_AnimalIdentification();
		//Required fields
		subject.ReferenceIdentification = "q";
		subject.Date = "6qJTUv";
		subject.Date2 = "tcghlc";
		//Test Parameters
		if (testPeriodOrIntervalValue > 0) 
			subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
