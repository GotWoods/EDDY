using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class W20Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "W20*6*6*hc*9*q*w*3*3*Bo*k";

		var expected = new W20_LineItemDetailPacking()
		{
			Pack = 6,
			Size = 6,
			UnitOrBasisForMeasurementCode = "hc",
			Weight = 9,
			WeightQualifier = "q",
			WeightUnitCode = "w",
			UnitWeight = 3,
			Volume = 3,
			UnitOrBasisForMeasurementCode2 = "Bo",
			Color = "k",
		};

		var actual = Map.MapObject<W20_LineItemDetailPacking>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(6, "hc", true)]
	[InlineData(0, "hc", false)]
	[InlineData(6, "", false)]
	public void Validation_AllAreRequiredSize(decimal size, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new W20_LineItemDetailPacking();
		if (size > 0)
		subject.Size = size;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(3, "Bo", true)]
	[InlineData(0, "Bo", false)]
	[InlineData(3, "", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new W20_LineItemDetailPacking();
		if (volume > 0)
		subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
