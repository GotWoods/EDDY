using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.Tests.Models.v4010;

public class STATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "STA*qx*5**r*tC*2*6*Lg";

		var expected = new STA_Statistics()
		{
			StatisticCode = "qx",
			MeasurementValue = 5,
			CompositeUnitOfMeasure = null,
			MeasurementQualifier = "r",
			MeasurementReferenceIDCode = "tC",
			RangeMinimum = 2,
			RangeMaximum = 6,
			MeasurementSignificanceCode = "Lg",
		};

		var actual = Map.MapObject<STA_Statistics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("qx", true)]
	public void Validation_RequiredStatisticCode(string statisticCode, bool isValidExpected)
	{
		var subject = new STA_Statistics();
		subject.MeasurementValue = 5;
		subject.StatisticCode = statisticCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(5, true)]
	public void Validation_RequiredMeasurementValue(decimal measurementValue, bool isValidExpected)
	{
		var subject = new STA_Statistics();
		subject.StatisticCode = "qx";
		if (measurementValue > 0)
			subject.MeasurementValue = measurementValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
