using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;
using Eddy.x12.Models.Elements;

namespace Eddy.Tests.x12.Models;

public class GDPTests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "GDP*8**P*9*Qk*3*KK";

		var expected = new GDP_GeneralDosingParameters()
		{
			MeasurementValue = 8,
			CompositeUnitOfMeasure = null,
			RouteOfAdministration = "P",
			TestPeriodOrIntervalValue = 9,
			UnitOfTimePeriodOrIntervalCode = "Qk",
			TestPeriodOrIntervalValue2 = 3,
			UnitOfTimePeriodOrIntervalCode2 = "KK",
		};

		var actual = Map.MapObject<GDP_GeneralDosingParameters>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(8, true)]
	public void Validation_RequiredMeasurementValue(decimal measurementValue, bool isValidExpected)
	{
		var subject = new GDP_GeneralDosingParameters();
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		if (measurementValue > 0)
		subject.MeasurementValue = measurementValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("AB", true)]
	public void Validation_RequiredCompositeUnitOfMeasure(string compositeUnitOfMeasure, bool isValidExpected)
	{
		var subject = new GDP_GeneralDosingParameters();
		subject.MeasurementValue = 8;
		if (compositeUnitOfMeasure != "")
		    subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure() { UnitOrBasisForMeasurementCode = compositeUnitOfMeasure };
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(9, "Qk", true)]
	[InlineData(0, "Qk", false)]
	[InlineData(9, "", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue(int testPeriodOrIntervalValue, string unitOfTimePeriodOrIntervalCode, bool isValidExpected)
	{
		var subject = new GDP_GeneralDosingParameters();
		subject.MeasurementValue = 8;
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		if (testPeriodOrIntervalValue > 0)
		subject.TestPeriodOrIntervalValue = testPeriodOrIntervalValue;
		subject.UnitOfTimePeriodOrIntervalCode = unitOfTimePeriodOrIntervalCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(3, "KK", true)]
	[InlineData(0, "KK", false)]
	[InlineData(3, "", false)]
	public void Validation_AllAreRequiredTestPeriodOrIntervalValue2(int testPeriodOrIntervalValue2, string unitOfTimePeriodOrIntervalCode2, bool isValidExpected)
	{
		var subject = new GDP_GeneralDosingParameters();
		subject.MeasurementValue = 8;
		subject.CompositeUnitOfMeasure = new C001_CompositeUnitOfMeasure();
		if (testPeriodOrIntervalValue2 > 0)
		subject.TestPeriodOrIntervalValue2 = testPeriodOrIntervalValue2;
		subject.UnitOfTimePeriodOrIntervalCode2 = unitOfTimePeriodOrIntervalCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
