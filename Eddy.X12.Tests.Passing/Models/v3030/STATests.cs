using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.Tests.Models.v3030;

public class STATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "STA*kR*6*My*8*K9*7*7";

		var expected = new STA_Statistics()
		{
			StatisticCode = "kR",
			MeasurementValue = 6,
			UnitOrBasisForMeasurementCode = "My",
			MeasurementQualifier = "8",
			MeasurementReferenceIDCode = "K9",
			RangeMinimum = 7,
			RangeMaximum = 7,
		};

		var actual = Map.MapObject<STA_Statistics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("kR", true)]
	public void Validation_RequiredStatisticCode(string statisticCode, bool isValidExpected)
	{
		var subject = new STA_Statistics();
		subject.MeasurementValue = 6;
		subject.StatisticCode = statisticCode;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

	[Theory]
	[InlineData(0, false)]
	[InlineData(6, true)]
	public void Validation_RequiredMeasurementValue(decimal measurementValue, bool isValidExpected)
	{
		var subject = new STA_Statistics();
		subject.StatisticCode = "kR";
		if (measurementValue > 0)
			subject.MeasurementValue = measurementValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
