using Eddy.Core.Validation;
using Eddy.Tests.x12;
using Eddy.x12.Mapping;
using Eddy.x12.Models.Elements;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.Tests.Models.v3010;

public class STATests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "STA*QB*2*4c*K*wC";

		var expected = new STA_Statistics()
		{
			StatisticCode = "QB",
			MeasurementValue = 2,
			UnitOfMeasurementCode = "4c",
			MeasurementQualifier = "K",
			MeasurementReferenceIDCode = "wC",
		};

		var actual = Map.MapObject<STA_Statistics>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData("", false)]
	[InlineData("QB", true)]
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
		subject.StatisticCode = "QB";
		if (measurementValue > 0)
			subject.MeasurementValue = measurementValue;
		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.Required);
	}

}
