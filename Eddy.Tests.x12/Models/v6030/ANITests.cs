using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.Tests.Models.v6030;

public class ANITests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "ANI*F*xgsNRPVJ*z4YIhUDG*7*tu*L*P*WoVpvbrG*6";

		var expected = new ANI_AnimalIdentification()
		{
			ReferenceIdentification = "F",
			Date = "xgsNRPVJ",
			Date2 = "z4YIhUDG",
			TestPeriodOrIntervalValue = 7,
			UnitOfTimePeriodOrIntervalCode = "tu",
			ReferenceIdentification2 = "L",
			ReferenceIdentification3 = "P",
			Date3 = "WoVpvbrG",
			ReferenceIdentification4 = "6",
		};

		var actual = Map.MapObject<ANI_AnimalIdentification>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("F", true)]
	public void Validation_RequiredReferenceIdentification(string referenceIdentification, bool isValidExpected)
	{
		var subject = new ANI_AnimalIdentification();
		//Required fields
		subject.Date = "xgsNRPVJ";
		subject.Date2 = "z4YIhUDG";
		//Test Parameters
		subject.ReferenceIdentification = referenceIdentification;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode))
		{
			subject.TestPeriodOrIntervalValue = 7;
			subject.UnitOfTimePeriodOrIntervalCode = "tu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xgsNRPVJ", true)]
	public void Validation_RequiredDate(string date, bool isValidExpected)
	{
		var subject = new ANI_AnimalIdentification();
		//Required fields
		subject.ReferenceIdentification = "F";
		subject.Date2 = "z4YIhUDG";
		//Test Parameters
		subject.Date = date;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode))
		{
			subject.TestPeriodOrIntervalValue = 7;
			subject.UnitOfTimePeriodOrIntervalCode = "tu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("z4YIhUDG", true)]
	public void Validation_RequiredDate2(string date2, bool isValidExpected)
	{
		var subject = new ANI_AnimalIdentification();
		//Required fields
		subject.ReferenceIdentification = "F";
		subject.Date = "xgsNRPVJ";
		//Test Parameters
		subject.Date2 = date2;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrIntervalCode))
		{
			subject.TestPeriodOrIntervalValue = 7;
			subject.UnitOfTimePeriodOrIntervalCode = "tu";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(7, "tu", true)]
	[InlineData(7, "", false)]
	[InlineData(0, "tu", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue(int testPeriodOrIntervalValue, string unitOfTimePeriodOrIntervalCode, bool isValidExpected)
	{
		var subject = new ANI_AnimalIdentification();
		//Required fields
		subject.ReferenceIdentification = "F";
		subject.Date = "xgsNRPVJ";
		subject.Date2 = "z4YIhUDG";
		//Test Parameters
		if (testPeriodOrIntervalValue > 0) 
			subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
		subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
