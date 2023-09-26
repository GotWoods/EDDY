using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.Tests.Models.v3070;

public class GDPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GDP*4**1*4*jD*8*UH";

		var expected = new GDP_GeneralDosingParameters()
		{
			MeasurementValue = 4,
			CompositeUnitOfMeasure = null,
			RouteOfAdministration = "1",
			TestPeriodOrIntervalValue = 4,
			UnitOfTimePeriodOrInterval = "jD",
			TestPeriodOrIntervalValue2 = 8,
			UnitOfTimePeriodOrInterval2 = "UH",
		};

		var actual = Map.MapObject<GDP_GeneralDosingParameters>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(4, true)]
	public void Validation_RequiredMeasurementValue(decimal measurementValue, bool isValidExpected)
	{
		var subject = new GDP_GeneralDosingParameters();
		//Required fields
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		//Test Parameters
		if (measurementValue > 0) 
			subject.MeasurementValue = measurementValue;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 4;
			subject.UnitOfTimePeriodOrInterval = "jD";
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 8;
			subject.UnitOfTimePeriodOrInterval2 = "UH";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("A", true)]
	public void Validation_RequiredCompositeUnitOfMeasure(string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new GDP_GeneralDosingParameters();
		//Required fields
		subject.MeasurementValue = 4;
		//Test Parameters
		if (compositeUnitOfMeasure != "") 
			subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 4;
			subject.UnitOfTimePeriodOrInterval = "jD";
		}
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 8;
			subject.UnitOfTimePeriodOrInterval2 = "UH";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(4, "jD", true)]
	[InlineData(4, "", false)]
	[InlineData(0, "jD", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue(int testPeriodOrIntervalValue, string unitOfTimePeriodOrInterval, bool isValidExpected)
	{
		var subject = new GDP_GeneralDosingParameters();
		//Required fields
		subject.MeasurementValue = 4;
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		//Test Parameters
		if (testPeriodOrIntervalValue > 0) 
			subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
		subject.UnitOfTimePeriodOrInterval = unitOfTimePeriodOrInterval;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue2 > 0 || subject.TestPeriodOrIntervalValue2 > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval2))
		{
			subject.TestPeriodOrIntervalValue2 = 8;
			subject.UnitOfTimePeriodOrInterval2 = "UH";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0, "", true)]
	[InlineData(8, "UH", true)]
	[InlineData(8, "", false)]
	[InlineData(0, "UH", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue2(int testPeriodOrIntervalValue2, string unitOfTimePeriodOrInterval2, bool isValidExpected)
	{
		var subject = new GDP_GeneralDosingParameters();
		//Required fields
		subject.MeasurementValue = 4;
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		//Test Parameters
		if (testPeriodOrIntervalValue2 > 0) 
			subject.TestPeriodOrIntervalValue2 = testPeriodOrIntervalValue2;
		subject.UnitOfTimePeriodOrInterval2 = unitOfTimePeriodOrInterval2;
		//If one filled, all required
		if(subject.TestPeriodOrIntervalValue > 0 || subject.TestPeriodOrIntervalValue > 0 || !string.IsNullOrEmpty(subject.UnitOfTimePeriodOrInterval))
		{
			subject.TestPeriodOrIntervalValue = 4;
			subject.UnitOfTimePeriodOrInterval = "jD";
		}
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
