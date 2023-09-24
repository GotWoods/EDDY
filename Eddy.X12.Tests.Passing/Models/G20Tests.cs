using Eddy.Core.Validation;
using Eddy.x12.Mapping;
using Eddy.x12.Models;

namespace Eddy.Tests.x12.Models;

public class G20Tests
{
	[Fact]
	public void Parse_ShouldReturnCorrectObject()
	{
		string x12Line = "G20*3*9*6N*8*bF*1*RK*1*5";

		var expected = new G20_ItemPackingDetail()
		{
			Pack = 3,
			Size = 9,
			UnitOrBasisForMeasurementCode = "6N",
			Weight = 8,
			UnitOrBasisForMeasurementCode2 = "bF",
			Volume = 1,
			UnitOrBasisForMeasurementCode3 = "RK",
			Color = "1",
			InnerPack = 5,
		};

		var actual = Map.MapObject<G20_ItemPackingDetail>(x12Line, MapOptionsForTesting.x12DefaultEndsWithNewline);
		Assert.Equivalent(expected, actual);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(9, "6N", true)]
	[InlineData(0, "6N", false)]
	[InlineData(9, "", false)]
	public void Validation_AllAreRequiredSize(decimal size, string unitOrBasisForMeasurementCode, bool isValidExpected)
	{
		var subject = new G20_ItemPackingDetail();
		if (size > 0)
		subject.Size = size;
		subject.UnitOrBasisForMeasurementCode = unitOrBasisForMeasurementCode;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(8, "bF", true)]
	[InlineData(0, "bF", false)]
	[InlineData(8, "", false)]
	public void Validation_AllAreRequiredWeight(decimal weight, string unitOrBasisForMeasurementCode2, bool isValidExpected)
	{
		var subject = new G20_ItemPackingDetail();
		if (weight > 0)
		subject.Weight = weight;
		subject.UnitOrBasisForMeasurementCode2 = unitOrBasisForMeasurementCode2;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

	[Theory]
	[InlineData(0,"", true)]
	[InlineData(1, "RK", true)]
	[InlineData(0, "RK", false)]
	[InlineData(1, "", false)]
	public void Validation_AllAreRequiredVolume(decimal volume, string unitOrBasisForMeasurementCode3, bool isValidExpected)
	{
		var subject = new G20_ItemPackingDetail();
		if (volume > 0)
		subject.Volume = volume;
		subject.UnitOrBasisForMeasurementCode3 = unitOrBasisForMeasurementCode3;

		TestHelper.CheckValidationResults(subject, isValidExpected, ErrorCodes.IfOneIsFilledAllAreRequired);
	}

}
