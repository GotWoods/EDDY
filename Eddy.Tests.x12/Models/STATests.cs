using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class STATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "STA*FG*1**h*9H*2*3*Li";

		var expected = new STA_Statistics()
		{
			StatisticCode = "FG",
			MeasurementValue = 1,
			CompositeUnitOfMeasure = "",
			MeasurementQualifier = "h",
			MeasurementReferenceIDCode = "9H",
			RangeMinimum = 2,
			RangeMaximum = 3,
			MeasurementSignificanceCode = "Li",
		};

		var actual = Map.MapObject<STA_Statistics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("FG", true)]
	public void Validation_RequiredStatisticCode(string statisticCode, bool isValidExpected)
	{
		var subject = new STA_Statistics();
		subject.MeasurementValue = 1;
		subject.StatisticCode = statisticCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(1, true)]
	public void Validation_RequiredMeasurementValue(decimal measurementValue, bool isValidExpected)
	{
		var subject = new STA_Statistics();
		subject.StatisticCode = "FG";
		if (measurementValue > 0)
		subject.MeasurementValue = measurementValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
