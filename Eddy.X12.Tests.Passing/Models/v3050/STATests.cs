using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.Tests.Models.v3050;

public class STATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "STA*xS*2**1*20*8*3";

		var expected = new STA_Statistics()
		{
			StatisticCode = "xS",
			MeasurementValue = 2,
			CompositeUnitOfMeasure = null,
			MeasurementQualifier = "1",
			MeasurementReferenceIDCode = "20",
			RangeMinimum = 8,
			RangeMaximum = 3,
		};

		var actual = Map.MapObject<STA_Statistics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("xS", true)]
	public void Validation_RequiredStatisticCode(string statisticCode, bool isValidExpected)
	{
		var subject = new STA_Statistics();
		subject.MeasurementValue = 2;
		subject.StatisticCode = statisticCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(2, true)]
	public void Validation_RequiredMeasurementValue(decimal measurementValue, bool isValidExpected)
	{
		var subject = new STA_Statistics();
		subject.StatisticCode = "xS";
		if (measurementValue > 0)
			subject.MeasurementValue = measurementValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
